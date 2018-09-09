using System;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Management;
using System.IO;
public class HWID
{
    [Flags()]
    private enum DockInfo
    {
        DOCKINFO_DOCKED = 0x2,
        DOCKINFO_UNDOCKED = 0x1,
        DOCKINFO_USER_SUPPLIED = 0x4,
        DOCKINFO_USER_DOCKED = 0x5,
        DOCKINFO_USER_UNDOCKED = 0x6
    }

    [StructLayout(LayoutKind.Sequential)]
    private class HW_PROFILE_INFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public Int32 dwDockInfo;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 39)]
        public string szHwProfileGuid;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szHwProfileName;
    }

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool GetCurrentHwProfile(IntPtr lpHwProfileInfo);
    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    private static extern long GetVolumeInformationA(string PathName, StringBuilder VolumeNameBuffer, Int32 VolumeNameSize, ref Int32 VolumeSerialNumber, ref Int32 MaximumComponentLength, ref Int32 FileSystemFlags, StringBuilder FileSystemNameBuffer, Int32 FileSystemNameSize);



    private static string getVolumeSerialv1(string drive)
    {
        ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
        disk.Get();

        string volumeSerialv1 = disk["VolumeSerialNumber"].ToString();
        disk.Dispose();

        return volumeSerialv1;
    }



    private static string getCPUID()
    {

        string cpuInfov1 = "";
        ManagementClass managClass = new ManagementClass("win32_processor");
        ManagementObjectCollection managCollec = managClass.GetInstances();

        foreach (ManagementObject managObj in managCollec)
        {
            if (cpuInfov1 == "")
            {
                cpuInfov1 = managObj.Properties["processorID"].Value.ToString();
                break;
            }
        }

        return cpuInfov1;
    }


    private static string getUniqueID(string drive)
    {
        if (drive == string.Empty)
        {
            foreach (DriveInfo compDrive in DriveInfo.GetDrives())
            {
                if (compDrive.IsReady)
                {
                    drive = compDrive.RootDirectory.ToString();
                    break;
                }
            }
        }

        if (drive.EndsWith(":\\"))
        {
            //C:\ -> C
            drive = drive.Substring(0, drive.Length - 2);
        }

        string volumeSerial = getVolumeSerialv1(drive);
        string cpuID = getCPUID();

        return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
    }




    private static HW_PROFILE_INFO ProfileInfo()
    {
        HW_PROFILE_INFO profile = null;
        IntPtr profilePtr = IntPtr.Zero;
        try
        {
            profile = new HW_PROFILE_INFO();
            profilePtr = Marshal.AllocHGlobal(Marshal.SizeOf(profile));
            Marshal.StructureToPtr(profile, profilePtr, false);

            if (!GetCurrentHwProfile(profilePtr))
            {
                throw new Exception("Error cant get current hw profile!");
            }
            else
            {
                Marshal.PtrToStructure(profilePtr, profile);
                return profile;
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString());
        }
        finally
        {
            if (profilePtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(profilePtr);
            }
        }
    }

   
    private static string MD5(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        using (var md5 = new MD5CryptoServiceProvider())
            bytes = md5.ComputeHash(bytes);
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }

    /// <summary>
    /// Generates the computer's HWID based on elitepvpers algorithm.
    /// </summary>
    /// <returns>Returns the computer's HWID</returns>
    public static string Generate()
    {
        var profileInfo = ProfileInfo();
        var profileGuid = profileInfo.szHwProfileGuid.ToString();
        var volumeSerial = getUniqueID("C");

            
        return MD5(profileGuid + volumeSerial);


    }

}

