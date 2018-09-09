// X-LOADER MADE FOR X-HOOK
// Created by Maikel233
//Messy code should port to c++ but meh
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

using System.Text.RegularExpressions;
namespace UnityLoader
{
    public partial class Form1 : Form
    {
        Form opener;
        public Form1(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }
        public Form1(string user)
        {
            InitializeComponent();
            userlabel.Text = (user);
        }
        string dl;
        WebClient client = new WebClient();

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

        string selectedcheat; // process of the cheat

        private string retrievesubscriptions; // our string for the changelog
        private string retrievedetections; // our string for the detectionstatus
        private void Form1_Load(object sender, EventArgs e)
        {
            Check.Start();
            this.CenterToScreen();

            // Delete our .DLL Files
            string Loc = Path.GetTempPath();

            if (File.Exists(@Loc + "/shell32.dll"))
            {
                File.Delete(@Loc + "/shell32.dll");
            }

            if (File.Exists(@Loc + "/imageres.dll"))
            {
                File.Delete(@Loc + "/imageres.dll");
            }

            LoadProgress.ForeColor = Color.DodgerBlue;
            LoadProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            //offline
            IndexCoder.Text = ("Maikel233");

            //do stuff on the webz
            retrievesubscriptions = GET2("http://x-hook.xyz/loader/lso/webforum/active-subscription.php?username=" + userlabel.Text);
            retrievedetections = GET2("http://x-hook.xyz/loader/lso/webforum/detectionstatus.php");

            GetDetections(); // execute once

            int NumOfSupGames = retrievesubscriptions.Split(new string[] { "/n" }, StringSplitOptions.None).Length - 1;

            for (int x = 1; x <= NumOfSupGames; x++)
            {
                IndexCheat.Items.Add(retrievesubscriptions.Split(new string[] { "/n" }, StringSplitOptions.None)[x].Split(new string[] { "/n" }, StringSplitOptions.None)[0]);
            }

        }

        string getprocname(string findcheat)
        {
            LoadProgress.Value = (50); 
            ProgressLabel.Text = ("We found Proccess: " + selectedcheat);
            return (selectedcheat); 
        }
        string currentdll;
        string downloaddll(string findcheat)
        {

            LoadProgress.Value = (100);

            client.DownloadFile(dl, Path.GetTempPath() + currentdll + ".dll");  // Local + ".dll?raw=true"
            ProgressLabel.Text = ("Loader initiated!");
            Console.Write("Downloaded");
       //     MessageBox.Show(dl, Path.GetTempPath() + currentdll + ".dll");
            this.Hide();
            CheckProc.Start(); 
            return (Path.GetTempPath() + currentdll + ".dll");

        }
        public void SetTextForLabel(string Welcome)
        {
            this.userlabel.Text = Welcome;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://steamcommunity.com/groups/X-HOOK"); // Steam group
            Process.Start(sInfo);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        string CurrentPackage;
        private void button3_Click(object sender, EventArgs e)
        {
            string foo = IndexCheat.GetItemText(IndexCheat.SelectedItem);
            string subscribed = ("Error Subscribe to the Cheat: " + foo + " in order to use it");
            string Disabled = ("The cheat: " + foo + " is currently disabled and not available at the moment. Please try later again.");
            if (foo == ("Counter strike 1.6"))
            {
                MessageBox.Show(Disabled, "X-LOADER | Access not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectedcheat = "";
            }

            else if (foo == ("Counter strike Source"))
            {
                MessageBox.Show(Disabled, "X-LOADER | Access not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectedcheat = "";
            }

            else if (foo == ("World of Warcraft 3.35"))
            {

                MessageBox.Show(Disabled, "X-LOADER | Access not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectedcheat = "";
            }

            else if (foo == ("World of Warcraft 6.2"))
            {
                selectedcheat = "wow";
                CurrentPackage = "lvl2";
                start();
            }

            else if (foo == ("X-FrameWork"))
            {

                MessageBox.Show(Disabled, "X-LOADER | Access not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectedcheat = "";
            }

            else if (foo == ("Blackops Zombies"))
            {
                MessageBox.Show(Disabled, "X-LOADER | Access not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectedcheat = "";
            }

            else if (foo == (""))
            {
                ProgressLabel.Text = ("ERROR! NO GAME WAS FOUND! Please Select Game!");
                ProgressLabel.ForeColor = System.Drawing.Color.Orange;
                selectedcheat = "";
            }

            else if (foo == ("Left 4 Dead 2"))
            {
                CurrentPackage = "lvl2";
                selectedcheat = "left4dead2";
                start();
            }

            else if (foo == ("Team Fortress 2"))
            {
                CurrentPackage = "lvl2";
                selectedcheat = "hl2";
                start();
            }

            else if (foo == ("Counter strike Global offensive ESP"))
            {
                selectedcheat = "csgo";
                CurrentPackage = "lvl1";
                start();
            }
            else if (foo == ("Counter strike Global offensive League"))
            {
                MessageBox.Show(Disabled, "X-LOADER | Access not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectedcheat = "";
            }


            else if (foo == ("Counter strike Global offensive MM"))
            {
                CurrentPackage = "lvl2";
                selectedcheat = "csgo";
                start();
            }

        }
        string ConfirmString;
        private void start()
        {
            ProgressLabel.Text = (selectedcheat + " Is not running! Awaiting Injection.");
            ProgressLabel.ForeColor = System.Drawing.Color.Red; 
            // turning off our Process Checker
            CheckProc.Enabled = false;
          
            string Loc = Path.GetTempPath();

            // Delete our .DLL for the user security
            if (File.Exists(@Loc + "/shell32.dll"))
            {
                File.Delete(@Loc + "/shell32.dll");
            }

            if (File.Exists(@Loc + "/shell32.dll"))
            {
                File.Delete(@Loc + "/shell32.dll");
            }
            // check if a process exist
            if (Process.GetProcessesByName(selectedcheat).Length > 0)
            {
                //
                ProgressLabel.Text = (selectedcheat + " Is running! Awaiting Injection.");
                ProgressLabel.ForeColor = System.Drawing.Color.LimeGreen;


                if (CurrentPackage.Contains("lvl1"))
                {
                    currentdll = ("shell32.dll");
                    dl = ("http://x-hook.xyz/loader/lso/games/esp/" + selectedcheat + "/shell32.dll");
                }
                else if (CurrentPackage.Contains("lvl2"))
                {
                    currentdll = ("shell32.dll");
                    dl = ("http://x-hook.xyz/loader/lso/games/full/" + selectedcheat + "/shell32.dll");
                }

                DialogResult dr = MessageBox.Show("Some users are not able to run the cheat\rIf the cheat doesn't work try to click Yes\rIf you didn't had any issues before just press No!", "Force the cheat to work?", MessageBoxButtons.YesNo);

                switch (dr)
                {
                    case DialogResult.Yes:
                        ConfirmString = ("!@YesItsTrue@!");
                        currentdll = ("imageres.dll");
                        break;

                    case DialogResult.No:
                        ConfirmString = ("!@YesItsTrue@!");
                        currentdll = ("shell32.dll");
                        break;
                }

                if (CurrentPackage.Contains("lvl1") && (ConfirmString.Contains("!@YesItsTrue@!")))
                {
                    dl = ("http://x-hook.xyz/loader/lso/games/esp/" + selectedcheat + "/" + currentdll);
                }
                else if (CurrentPackage.Contains("lvl2") && (ConfirmString.Contains("!@YesItsTrue@!")))
                {
                    dl = ("http://x-hook.xyz/loader/lso/games/full/" + selectedcheat + "/" + currentdll);
                }

              //  MessageBox.Show(dl);

                if (IndexCheat.SelectedItem != null)
                {
                    DllInjector.GetInstance.Inject(getprocname((string)IndexCheat.SelectedItem), downloaddll((string)IndexCheat.SelectedItem));
                }
                else
                {
                    ProgressLabel.Text = ("ERROR! NO GAME WAS FOUND! Please Select Game!");
                    ProgressLabel.ForeColor = System.Drawing.Color.Orange;
                }
            }
        }

        string vac; 
        string faceit; 
        string esea; 
        //string Warden;                    // WoW Live ac status
        //string WoWServerSideAnticheat; // WoW 3.3.5 Serverside AC status
        //string BattleEye; 
        //string NoAntiCheat; 
        private void GetDetections()
        {
            //vac
            if (retrievedetections.Contains("VAC: UNDETECTED "))
            {
                vac = ("VAC: UNDETECTED");
                detectionindex.ForeColor = Color.LimeGreen;
            }

            else if (retrievedetections.Contains("VAC: DETECTED "))
            {
                vac = ("VAC: DETECTED");
                detectionindex.ForeColor = Color.Red;
            }
            else if (retrievedetections.Contains("VAC: UNKNOWN"))
            {
                vac = ("VAC: UNKNOWN");
                detectionindex.ForeColor = Color.Orange;
            }
            //end of vac

            if (retrievedetections.Contains("FACEIT: UNDETECTED "))
            {
                faceit = ("FACEIT: UNDETECTED");
                detectionindex2.ForeColor = Color.LimeGreen;
            }

            else if (retrievedetections.Contains("FACEIT: DETECTED "))
            {
                faceit = ("FACEIT: DETECTED");
                detectionindex2.ForeColor = Color.Red;

            }
            else if (retrievedetections.Contains("FACEIT: UNKNOWN"))
            {

                faceit = ("FACEIT: UNKNOWN");
                detectionindex2.ForeColor = Color.Orange;
            }
            if (retrievedetections.Contains("ESEA: UNDETECTED "))
            {
                esea = ("ESEA: UNDETECTED");
                detectionindex3.ForeColor = Color.LimeGreen;
            }

            else if (retrievedetections.Contains("ESEA: DETECTED "))
            {
                esea = ("ESEA: DETECTED");
                detectionindex3.ForeColor = Color.Red;
            }
            else if (retrievedetections.Contains("ESEA: UNKNOWN"))
            {
                esea = ("ESEA: UNKNOWN");
                detectionindex3.ForeColor = Color.Orange;

            }
            else
            {
                vac = ("#Connection issue");
                faceit = ("#Connection issue");
                esea = ("#Connection issue");
                //Warden = ("#Connection issue");
                //WoWServerSideAnticheat = ("#Connection issue"); 
                //BattleEye = ("#Connection issue");
                //NoAntiCheat = ("#Connection issue");
            }
        }
        private void CheatIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Local Version This should be handled by a Database or website.
            string foo = IndexCheat.GetItemText(IndexCheat.SelectedItem);
            if (foo == ("Counter strike 1.6"))
            {
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                detectionindex2.Text = (faceit); 
                 detectionindex3.Text = (esea);
                IndexList.Text = ("Game: Counter-Strike 1.6" + "\r\n" + "Engine: Source Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build 1.0" + "\r\n" + "Status: [DISABLED]");
            }

            else if (foo == ("Counter strike Source"))
            {
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                detectionindex2.Text = (faceit);
                detectionindex3.Text = (esea);
                IndexList.Text = ("Game: Counter strike Source" + "\r\n" + "Engine: Source Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build 1.0" + "\r\n" + "Status: [DISABLED]");
            }

            else if (foo == ("Counter strike Global offensive ESP"))
            {
                vac = ("VAC: UNKNOWN");
                detectionindex.ForeColor = Color.Orange;
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                detectionindex2.Text = (faceit);
                detectionindex3.Text = (esea);
                IndexList.Text = ("Game: CS:GO" + "\r\n" + "Engine: Source Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build 1.5" + "\r\n" + "Status: [DISABLED]");
            }
            else if (foo == ("Counter strike Global offensive League"))
            {
                vac = ("VAC: UNKNOWN");
                detectionindex.ForeColor = Color.Orange;
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                detectionindex2.Text = (faceit);
                detectionindex3.Text = (esea);
                IndexList.Text = ("Game: CS:GO" + "\r\n" + "Engine: Source Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build: 1.5" + "\r\n" + "Status: [DISABLED]");
            }
            else if (foo == ("Counter strike Global offensive MM"))
            {
                vac = ("VAC: UNKNOWN");
                detectionindex.ForeColor = Color.Orange;
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                detectionindex2.Text = (faceit);
                detectionindex3.Text = (esea);
                IndexList.Text = ("Game: CS:GO" + "\r\n" + "Engine: Source Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build: 1.5" + "\r\n" + "Status: [ENABLED]");
              
            }

            else if (foo == ("Left 4 Dead 2"))
            {
                vac = ("VAC: UNDETECTED");
                detectionindex.ForeColor = Color.LimeGreen;
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                detectionindex2.Text = (faceit);
                detectionindex3.Text = (esea);
                IndexList.Text = ("Game: L4D2" + "\r\n" + "Engine: Source Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build: 0.1" + "\r\n" + "Status: [ENABLED]");
               
            }

            else if (foo == ("Team Fortress 2"))
            {
                vac = ("VAC: UNDETECTED");
                detectionindex.ForeColor = Color.LimeGreen;
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                detectionindex2.Text = (faceit);
                detectionindex3.Text = (esea);
                IndexList.Text = ("Game: TF2" + "\r\n" + "Engine: Source Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build: 1.5" + "\r\n" + "Status: [ENABLED]");
       
            }
           
            else if (foo == ("Blackops Zombies"))
            {
                detectionindex.Text = (vac); // + "\r\n" + (faceit) + "\r\n" + (esea);
                IndexList.Text = ("Game: Blackops Zombies" + "\r\n" + "Engine: IW Engine" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build: 2.0" + "\r\n" + "Status: [DISABLED]");
            }

            else if (foo == ("World of Warcraft Live Server"))
            {
                vac = ("WARDEN: UNDETECTED");
                detectionindex.ForeColor = Color.LimeGreen;
                detectionindex.Text = ("Warden"); 
                IndexList.Text = ("Game: WOW Live" + "\r\n" + "Engine: WOW" + "\r\n" + "Cheat: X-HOOK" + "\r\n" + "Build 1.0" + "\r\n" + "Status: [DISABLED]");
               
            }

            else
            {
                IndexList.Text = ("");
            }

        }

        private void CheckProc_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(selectedcheat).Length > 0)
            {

            }
            else
            {
                string Loc = Path.GetTempPath();
                if (File.Exists(@Loc + "/shell32.dll"))
                {
                    File.Delete(@Loc + "/shell32.dll");
                }
                if (File.Exists(@Loc + "/imageres.dll"))
                {
                    File.Delete(@Loc + "/imageres.dll");
                }
                //Let's close our App
                Application.Exit();
            }
        }


        private void Hide_Tick_1(object sender, EventArgs e)
        {

        }

        private void DisableAll_Tick(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Our Website
            ProcessStartInfo sInfo = new ProcessStartInfo("http://x-hook.xyz");
            Process.Start(sInfo);
        }

        private void letsego_Tick(object sender, EventArgs e)
        {

        }

        private void Check_Tick(object sender, EventArgs e)
        {

        }

        private void Exit_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        int checkpoint;
        private void Check_Tick_1(object sender, EventArgs e)
        {
            checkpoint++;

            if (checkpoint >= 2) // after 2 hours close the loader
            {
                Application.Exit();
            }
        }

        private void IndexCoder_TextChanged(object sender, EventArgs e)
        {

        }

        private void DelayInjection_CheckedChanged(object sender, EventArgs e)
        {
            if (DelayInjection.Checked == true)
            {

                button3.Enabled = false;
                AutoInjectionTimer.Start();
               
            }
            else if (DelayInjection.Checked == false)
                {
                button3.Enabled = true;
                AutoInjectionTimer.Stop();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AutoInjectionTimer_Tick(object sender, EventArgs e)
        {       
            AutoInjectionTimer.Interval = ((int)InjectionIntervall.Value);
            if (Process.GetProcessesByName(selectedcheat).Length > 0)
            {
                button3_Click(true, e);
            }
         }
    }
}
