//X-LOADER MADE FOR X-HOOK
//Created by Maikel233
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;
using System.Threading; // program is running
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using XLOADER;
namespace UnityLoader
{

    public partial class XHOOKACCESS : Form
    {

        public XHOOKACCESS()
        {
            InitializeComponent();
        }

        const int DBG_CONTINUE = 0x00010002;
        const int DBG_EXCEPTION_NOT_HANDLED = unchecked((int)0x80010001);

        enum DebugEventType : int
        {
            CREATE_PROCESS_DEBUG_EVENT = 3, //Reports a create-process debugging event. The value of u.CreateProcessInfo specifies a CREATE_PROCESS_DEBUG_INFO structure.
            CREATE_THREAD_DEBUG_EVENT = 2, //Reports a create-thread debugging event. The value of u.CreateThread specifies a CREATE_THREAD_DEBUG_INFO structure.
            EXCEPTION_DEBUG_EVENT = 1, //Reports an exception debugging event. The value of u.Exception specifies an EXCEPTION_DEBUG_INFO structure.
            EXIT_PROCESS_DEBUG_EVENT = 5, //Reports an exit-process debugging event. The value of u.ExitProcess specifies an EXIT_PROCESS_DEBUG_INFO structure.
            EXIT_THREAD_DEBUG_EVENT = 4, //Reports an exit-thread debugging event. The value of u.ExitThread specifies an EXIT_THREAD_DEBUG_INFO structure.
            LOAD_DLL_DEBUG_EVENT = 6, //Reports a load-dynamic-link-library (DLL) debugging event. The value of u.LoadDll specifies a LOAD_DLL_DEBUG_INFO structure.
            OUTPUT_DEBUG_STRING_EVENT = 8, //Reports an output-debugging-string debugging event. The value of u.DebugString specifies an OUTPUT_DEBUG_STRING_INFO structure.
            RIP_EVENT = 9, //Reports a RIP-debugging event (system debugging error). The value of u.RipInfo specifies a RIP_INFO structure.
            UNLOAD_DLL_DEBUG_EVENT = 7, //Reports an unload-DLL debugging event. The value of u.UnloadDll specifies an UNLOAD_DLL_DEBUG_INFO structure.
        }

        [StructLayout(LayoutKind.Sequential)]
        struct DEBUG_EVENT
        {
            [MarshalAs(UnmanagedType.I4)]
            public DebugEventType dwDebugEventCode;
            public int dwProcessId;
            public int dwThreadId;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            public byte[] bytes;
        }

        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern bool DebugActiveProcess(int dwProcessId);
        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern bool WaitForDebugEvent([Out] out DEBUG_EVENT lpDebugEvent, int dwMilliseconds);
        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern bool ContinueDebugEvent(int dwProcessId, int dwThreadId, int dwContinueStatus);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public static string login(string username)
        {
            string s = string.Empty;
            try
            {
                WebClient client = new WebClient();
                string url = "http://x-hook.xyz/loader/lso/webforum/getdate.php";
                byte[] html = client.DownloadData(url);
                UTF8Encoding utf = new UTF8Encoding();
                string stringdate = utf.GetString(html);


                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://x-hook.xyz/loader/lso/webforum/login.php?username=" + username + "&HWID=" + HWID.Generate() + "&TIME=" + stringdate);
                StreamReader sr = new StreamReader(wr.GetResponse().GetResponseStream());
                s = sr.ReadToEnd();
            }
            catch (Exception ex) { }
            return s;
        }
        public string forum = ("http://x-hook.xyz/forum/");
        int loginTries = 0; // After a few failed logins. Notify Database and exit or delete application?
        private void button2_Click(object sender, EventArgs e)
        {
            msgtext.Text = ("Please wait");
            LoadProgress.Value = 0;

            if (Usernametextbox.Text.Length == (0) || Passwordtextbox.Text.Length == (0))
            {
                MessageBox.Show("Please fill in your credentials!", "X-LOADER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                msgtext.Text = ("Status: IDLE");
                LoadProgress.Value = 0;
            }
            else
            {
                msgtext.Text = ("Status: Please wait");
                LoadProgress.Value = 0;
                HttpWebRequest httpWebRequest = null;
                HttpWebResponse httpWebResponse = null;
                Stream stream = null;
                StreamReader streamReader = null;
                Byte[] postBytes;

                CookieContainer cookieContainer = new CookieContainer();
                string sPostData = "&username=" + Usernametextbox.Text + "&password=" + Passwordtextbox.Text + "&remember=yes&submit=Login&action=do_login&url=/member.php?action=login";
                string sFinalData = null;

                msgtext.Text = ("Status: Please wait.");
                LoadProgress.Value = 15;

                try
                {
                    httpWebRequest = (HttpWebRequest)WebRequest.Create("http://x-hook.xyz/forum/member.php?action=login");
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    postBytes = Encoding.UTF8.GetBytes(sPostData);
                    httpWebRequest.ContentLength = postBytes.Length;
                    httpWebRequest.CookieContainer = cookieContainer;

                    stream = httpWebRequest.GetRequestStream();
                    stream.Write(postBytes, 0, postBytes.Length);

                    stream.Close();
                    stream = null;

                    LoadProgress.Value = 35;
                    httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.ASCII);

                    sFinalData = streamReader.ReadToEnd();

                    msgtext.Text = ("Status: Please wait..");
                    LoadProgress.Value = 50;

                    if (sFinalData.Contains("X-HOOK Forum") & (sFinalData.Contains("You have successfully been logged in.") & sFinalData.Contains("You will now be taken back to where you came from.") & sFinalData.Contains("Click here if you don't want to wait any longer.")))
                    {


                        WebClient client = new WebClient();
                        string url = "http://x-hook.xyz/loader/lso/webforum/login.php?username=" + Usernametextbox.Text /*+ "&password=" + password*/ + "&HWID=" + HWID.Generate();//if the username and password field's r NOT empty";
                        byte[] html = client.DownloadData(url);
                        UTF8Encoding utf = new UTF8Encoding();
                        string mystring = utf.GetString(html);

                        msgtext.Text = ("Status: Please wait...");
                        LoadProgress.Value = 65;

                        string Reply = new WebClient().DownloadString("http://x-hook.xyz/loader/lso/webforum/version.php");
                        msgtext.Text = ("Checking for updates...");
                        if (version == Reply)
                        {
                            MessageBox.Show("Version: " + Reply + "\nHas been released", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                        LoadProgress.Value = 80;


                        //Check HWID, subscription other stuff
                        if (XHOOKACCESS.login(Usernametextbox.Text).Contains("Username does not exist!"))
                        {
                            MessageBox.Show("Login unsuccessful! Please check your credentials!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            Usernametextbox.Clear();
                            Passwordtextbox.Clear();
                            Usernametextbox.Focus();
                            msgtext.Text = ("Status: Error");
                            LoadProgress.Value = 0;               
                        }

                        else if (XHOOKACCESS.login(Usernametextbox.Text).Contains("reason: "))
                        {
                            MessageBox.Show("You are banned check the forum for more information.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            msgtext.Text = ("Status: Error");
                            LoadProgress.Value = 0;
                        }

                        else if (XHOOKACCESS.login(Usernametextbox.Text).Contains("An other computer is activated with this account!"))
                        {
                            MessageBox.Show("This account is already bound to another computer. \nRequest a HWID unlock to continue", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            msgtext.Text = ("Status: Error");
                            LoadProgress.Value = 0;
                        }

                        else if (XHOOKACCESS.login(Usernametextbox.Text).Contains("we cant do shit!"))
                        {
                            LoadProgress.Value = 100;

                            Form1 f1 = new Form1(Usernametextbox.Text);
                            this.Hide();
                            f1.Show();

                            var XLOADERSETTINGS = new MyProg.IniFile("XLOADER.ini");
                            XLOADERSETTINGS.Write("Username", Usernametextbox.Text, "Username");
                            XLOADERSETTINGS.Write("Password", Passwordtextbox.Text, "Password");
                        }

                        else if (XHOOKACCESS.login(Usernametextbox.Text).Contains("No Active subscription."))
                        {
                            MessageBox.Show("No Active subscription was found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            msgtext.Text = ("Status: Error");
                            LoadProgress.Value = 0;
                            Application.Exit();
                        }

                        else if (XHOOKACCESS.login(Usernametextbox.Text).Contains("New Device activation!"))
                        {
                            MessageBox.Show("welcome!/nYour HWID has been submited. try to relog.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            msgtext.Text = ("Status: Please Relog.");
                            LoadProgress.Value = 0;
                        }


                        else if (XHOOKACCESS.login(Usernametextbox.Text).Contains(""))
                        {
                            MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            msgtext.Text = ("Status: Error");
                            LoadProgress.Value = 0;
                        }
                    }
                    else
                    {

                        MessageBox.Show("Login unsuccessful! Please check your credentials!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        msgtext.Text = ("Status: Error");
                        LoadProgress.Value = 0;
                    }
                }
                catch (Exception exception)
                {
                    //To be sure...
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Passwordcheck.Checked == true)
            {
                Passwordtextbox.PasswordChar = '\0';  // note: a pair of SINGLE quotes not one double quote.
                Passwordcheck.Text = ("Hide Password");
            }
            else if (Passwordcheck.Checked == false)
            {
                Passwordtextbox.PasswordChar = '*';
                Passwordcheck.Text = ("Show Password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LoginBox_Enter(object sender, EventArgs e)
        {
        }

        private static string GET2(string Url)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        static void KillOnExit(object process)
        {
            ((Process)process).WaitForExit();
            Environment.Exit(1);
        }
        
        public static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
 
        }

            private void Downloaded(object sender, AsyncCompletedEventArgs e)
        {
          //  Application.Exit();
        }
        public static string dllstatus;
        static System.Threading.Mutex singleton = new Mutex(true, "Xloader");
        string version = "1.3"; // our current version + 0.1 // GHETTO!!!
        private void XHOOKACCESS_Load(object sender, EventArgs e)
        {
            bool isDebuggerPresent = false;
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);

            if (isDebuggerPresent == true)
            {
                Application.Exit();
            }
            else
            {

                var XLOADERSETTINGS = new MyProg.IniFile("XLOADER.ini");
                var UsernameIni = XLOADERSETTINGS.Read("Username", "Username");
                var PasswordIni = XLOADERSETTINGS.Read("Password", "Password");

                Usernametextbox.Text = UsernameIni;
                Passwordtextbox.Text = PasswordIni;

                // anti dbg check flags

                // IsAlreadyRunning();
                /* Configure timer */

                /* Configure anti Debug*/
                Antidbg.Start();

                /* Center Form on screen */
                this.CenterToScreen();

                string Reply = new WebClient().DownloadString("http://x-hook.xyz/loader/lso/webforum/version.php");

                if (Reply.Contains(version)) // ghetto way but for some reason i cant download strings nor using other functions after hours of searching and trying...
                {

                    toolStripTextBox1.Text = ("Version: ") + (version);
                    MessageBox.Show("A new version of X-HOOK has been released \n Click OK to download a new version. \n This might take a minute.", "X-HOOK | A Update is required!");
                    try
                    {
                        Name = ("XLOADER.zip");
                        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), Name);
                        WebClient webClient = new WebClient();
                        {
                            webClient.DownloadFile("http://www.x-hook.xyz/app/loader/program/XLOADER.zip", Name);
                        }

                        string version = "1.3";
                        MessageBox.Show("Download successful. Current Version: " + version + "\nDownloaded Version: " + Reply, "X-LOADER");

                        string path = Environment.CurrentDirectory + "\\XLOADER.exe";

                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.Arguments = string.Format("/c del \"{0}\"", path);
                        process.Start();

                        Application.Exit();
                    }

                    catch
                    {
                        MessageBox.Show("Failed To Download! Delete the current X-LOADER.ZIP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Application.Exit();
                    }
                }
                else
                {
                    toolStripTextBox1.Text = ("Version: ") + (Reply);
                }

                //Probably smart to Encrypt the strings
                string Loc = Path.GetTempPath();
                string Shell32 = "/shell32.dll";
                string Imageres = "/imageres.dll";
                if (File.Exists(@Loc + Shell32))
                {
                    File.Delete(@Loc + Shell32);
                }
                if (File.Exists(@Loc + Imageres))
                {
                    File.Delete(@Loc + Imageres);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void XHOOKACCESS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
      
        }
        private void remember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://x-hook.xyz/forum");
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string checkchangelog; // our string for the changelog

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            checkchangelog = GET2("http://x-hook.xyz/loader/lso/webforum/lenta.php"); // Changelog
            MessageBox.Show(checkchangelog);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://x-hook.xyz");
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void msgtext_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Antidbg_Tick(object sender, EventArgs e)
        {
            foreach (Process pro in Process.GetProcesses())
            {
                if (pro.ProcessName.ToLower().Contains("cheat") && pro.ProcessName.ToLower().Contains("engine"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("OLLY") && pro.ProcessName.ToLower().Contains("DBG"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("IDA") && pro.ProcessName.ToLower().Contains("PRO"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("HEX") && pro.ProcessName.ToLower().Contains("Rays"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("redgate") && pro.ProcessName.ToLower().Contains("reflector"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("wire") && pro.ProcessName.ToLower().Contains("shark"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("tcp") && pro.ProcessName.ToLower().Contains("dump"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("net") && pro.ProcessName.ToLower().Contains("cat"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("Intercepter") && pro.ProcessName.ToLower().Contains("NG"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("hook") && pro.ProcessName.ToLower().Contains("shark"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("idag"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("idag64"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("MPGH Virus Scan Tool v6"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("Process") && pro.ProcessName.ToLower().Contains("Hacker"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("joeboxserver"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("joeboxcontrol"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("windbg"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("tcpview"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("lordpe"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("regmon"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("procmon"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("sniff_hit"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("ImportREC"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("autorunsc"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("autorun"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("procedure"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("dumpcap"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("ImmunityDebugger"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("procedure"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("dumpcap"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("hook") && pro.ProcessName.ToLower().Contains("Explorer"))
                {
                    Application.Exit();
                }

                else if (pro.ProcessName.ToLower().Contains("sys") && pro.ProcessName.ToLower().Contains("Analyzer"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("sys") && pro.ProcessName.ToLower().Contains("Inspector"))
                {
                    Application.Exit();
                }
                else if (pro.ProcessName.ToLower().Contains("proc_") && pro.ProcessName.ToLower().Contains("analyzer"))
                {
                    Application.Exit();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void copyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://x-hook.xyz");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
