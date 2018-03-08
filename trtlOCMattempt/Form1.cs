using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trtlOCMattempt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            addressRb.Checked = true;
            raindanceRb.Checked = false;
        }

        private void advancedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (advancedCheck.Checked)
            {
                this.Height = 763;
            } else
            {
                this.Height = 547;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 547;

            
        }

        void writeConfigs()
        {
            //build config.txt

            string configtxt = "";

            string chosenPool = getBestPool();
            string chosenPort;
            switch (hardwareCb.Text)
            {
                case "Low end":
                    chosenPort = ":3333";
                    break;
                case "Mid range":
                    chosenPort = ":5555";
                    break;
                case "High end":
                    chosenPort = ":7777";
                    break;
                default:
                    chosenPort = ":3333";
                    break;
            }

            configtxt +=
                @"""pool_list"" :
[
   
    { ""pool_address"" : """ + chosenPool+chosenPort + @""", ""wallet_address"" : """ + (raindanceRb.Checked ? "TRTLv3nW7vX3WXx5CRprf1ifYcY26yYPiVK9E6ocN91DKpUmqADA17n9qcE9QBCgJriGZZcbHuwwKFC8RomYVPDZah8dBN32BbZ" : addressTb.Text) + @""", ""pool_password"" : ""x"", ""use_nicehash"" : false, ""use_tls"" : false, ""tls_fingerprint"" : """", ""pool_weight"" : 1 },
],";


            configtxt += @"""currency"" : ""monero"",";
            configtxt += @"""call_timeout"" : 10,";
            configtxt += @"""retry_time"" : 30,";
            configtxt += @"";
            configtxt += @"""giveup_limit"" : 0,";
            configtxt += @"""verbose_level"" : 3,";
            configtxt += @"""print_motd"" : true,";
            configtxt += @"""h_print_time"" : 60,";
            configtxt += @"""aes_override"" : " + aesCb.Text + ",";
            configtxt += @"""use_slow_memory"" : ""warn"",";
            configtxt += @"""tls_secure_algo"" : true,";
            configtxt += @"""daemon_mode"" : false,";
            configtxt += @"""flush_stdout"" : false,";
            //configtxt += writeLogCheck.Checked ? (@"""output_file"" : """ + writeLogFileTb.Text + @""",") : "";
            configtxt += @"""output_file"" : """ + writeLogFileTb.Text + @""",";
            configtxt += @"""httpd_port"" : 4567,";
            configtxt += @"""http_login"" : """",";
            configtxt += @"""http_pass"" : """",";
            configtxt += @"""prefer_ipv4"" : true,";

            try
            {
                File.WriteAllText(@"config.txt", configtxt);
            } catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            //manual settings to be done yet/amd testing missing
            if (!autoConfigCheck.Checked)
            {
                string cputxt = "";

                cputxt += @"""cpu_threads_conf"" :[";
                for (int i = 0; i < cpuThreadNum.Value; i++)
                {
                    cputxt += @"{ ""low_power_mode"" : " + (cpuLowPowerCheck.Checked ? "true" : "false") + @", ""no_prefetch"" : true, ""affine_to_cpu"" : false },";
                }

                cputxt += @"],";

                try
                {
                    File.WriteAllText(@"cpu.txt", cputxt);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

                string nvidiatxt = "";
            }
            
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start mining!")
            {
                if (addressRb.Checked && !addressTb.Text.StartsWith("TRTL") && addressTb.Text.Length != 99)
                {
                    MessageBox.Show("Please check your Turtlecoin receiving address.");
                    return;
                }

                startBtn.Text = "Selecting pool...";

                var minerInfo = new ProcessStartInfo();

                string arguments = "";

                if (!cpuMiningCheck.Checked)
                {
                    arguments += " --noCPU";
                }
                if (!gpuMiningCheck.Checked)
                {
                    arguments += " --noAMD --noNVIDIA";
                }

                writeConfigs();

                //old console command based execution
                /*
                if (raindanceRb.Checked)
                {
                    arguments += " - u TRTLv3nW7vX3WXx5CRprf1ifYcY26yYPiVK9E6ocN91DKpUmqADA17n9qcE9QBCgJriGZZcbHuwwKFC8RomYVPDZah8dBN32BbZ -p x";
                }
                else
                {
                    arguments += " -u " + addressTb.Text + " -p x";
                }

                string chosenPool = getBestPool();
                string chosenPort;
                switch (hardwareCb.Text)
                {
                    case "Low end":
                        chosenPort = ":3333";
                        break;
                    case "Mid range":
                        chosenPort = ":5555";
                        break;
                    case "High end":
                        chosenPort = ":7777";
                        break;
                    default:
                        chosenPort = ":3333";
                        break;
                }

                connectedServerLbl.Text = "Connected to: " + chosenPool + chosenPort;
                arguments += " -o " + chosenPool + chosenPort;
                arguments += " --currency monero";
                */

                arguments += " --noUAC";
                
                minerInfo.WorkingDirectory = Directory.GetCurrentDirectory();

                minerInfo.FileName = @"xmr-stak\xmr-stak.exe";
                minerInfo.Arguments = arguments;
                if (showCLICheck.Checked)
                {
                    minerInfo.WindowStyle = ProcessWindowStyle.Normal;
                    //minerInfo.UseShellExecute = true;
                    //minerInfo.RedirectStandardOutput = false;
                } else
                {
                    minerInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //minerInfo.UseShellExecute = false;
                    //minerInfo.RedirectStandardOutput = true;
                }
                miner.StartInfo = minerInfo;

                miner.Start();

                timer1.Start();

                startBtn.Text = "Stop mining!";
            } else
            {
                try
                {
                    miner.Kill();
                    timer1.Stop();
                    //Process[] stak = Process.GetProcessesByName("xmr-stak");
                    //if (stak.Length != 0) stak[0].Kill();

                    startBtn.Text = "Start mining!";
                }
                catch
                {
                    MessageBox.Show("No miner was running anymore. It was either manually closed by the user or did not start due to a bug.");
                    timer1.Stop();

                    startBtn.Text = "Start mining!";
                }
            }
        }

        string pingpools()
        {
            string res = "";

            foreach (string url in pools)
            {
                long pingTime = ping(url);
                res += url + ": " + (pingTime == -1 ? "not available\n" : (pingTime/10000).ToString() + "ms\n");
            }

            return res;
        }

        string getBestPool()
        {
            string res = "";
            long bestPing = 100000000;

            foreach (string url in pools)
            {
                long pingTime = ping(url);
                if (pingTime != -1)
                {
                    if (pingTime < bestPing)
                    {
                        bestPing = pingTime;
                        res = url;
                    }
                }
            }
            return res;
        }

        //Implementation pending
        string[] getBestPools()
        {
            return null;
        }

        long ping(string url)
        {
            Ping sender = new Ping();
            long start = DateTime.Now.Ticks;
            PingReply res = sender.Send(url);
            if(res.Status == IPStatus.Success)
            {
                return DateTime.Now.Ticks - start;
            }

            return -1;
        }

        //with
        //556; 763
        //without
        //556; 547

        Process miner = new Process();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Always mine at your own risk for your hardware!\nYour computer might become unresponsive while mining.\nThe program automatically selects the best pool according to its ping time.\nThe integrated xmr-stak by fireice-uk licensed GPL contains a\ndev fee of 2% which I kept as it's a nice piece of software\nthat deserves help.", "Read this first!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("With the CPU/GPU checkboxes you can (de)select which hardware xmr-stak is supposed to mine on.\nPlease also select your hardware range to mine on certain ports with suitable difficulties.\nMine to address tells the pool to proceed the mined TRTLs to the given address in the textbox.\nMine to raindance sends all generated TRTLs to the TurtleRainBot which divides the Turtlecoins between participating users on the official Turtlecoin Discord community.\nShow advanced options views additional seetings for xmr-stak that can further optimize the mining process (for experts).", "Settings explained", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This One Click Miner for Turtlecoin programmed by Encrypted Unicorn is an unofficial graphical interface for mining TRTL on pools in the network using xmr-stak by fireice-uk. It is not related nor endorsed by the Turtlecoin Team or xmr-stak developers.\nVersion 1.0 alpha", "Read this first!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //string[] pools = { "trtl.ninja", "trtl.mine2gether.com", "trtl.flashpool.club", "turtle.mining.garden", "turtlecoinpool.ml", "eu.turtlepool.space", "auspool.turtleco.in",
        //    "trtl.blockchainera.net", "slowandsteady.fun", "us.turtlepool.space", "etnchina.io", "trtlpool.ninja", "hk.turtlepool.space" };

            //removed not working pools
        string[] pools = { "trtl.ninja", "turtlecoinpool.ml", "eu.turtlepool.space", "auspool.turtleco.in",
            "trtl.blockchainera.net", "slowandsteady.fun", "us.turtlepool.space", "etnchina.io", "trtlpool.ninja", "hk.turtlepool.space" };


        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show(pingpools() + "\n" + getBestPool());
            MessageBox.Show(pingpools());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                WebClient w = new WebClient();

                string hashrate = w.DownloadString("http://localhost:4567/h");
                hashrate = "Stats - Hashrate: " + (hashrate.Substring(hashrate.IndexOf("Totals:</th><td>")).Split('>')[2]).Split('<')[0] + " H/s";
                hashrateLbl.Text = hashrate;


                // MessageBox.Show(hashrate);

                string resultPage = w.DownloadString("http://localhost:4567/r");

               // MessageBox.Show(resultPage);

                string shareCount = "Shares: " + (resultPage.Substring(resultPage.IndexOf("Good results</th><td>")).Split('>')[2]).Split('<')[0];
                string bestShare = "Best: " + (resultPage.Substring(resultPage.IndexOf("1</th><td>")).Split('>')[2]).Split('<')[0];
                string diff = "Difficulty: " + (resultPage.Substring(resultPage.IndexOf("Difficulty</th><td>")).Split('>')[2]).Split('<')[0];
                shareCountLbl.Text = shareCount;
                bestShareLbl.Text = bestShare;
                difficultyLbl.Text = diff;

                string connectionPage = w.DownloadString("http://localhost:4567/c");
                connectionPage = "Connected to: " + (connectionPage.Substring(connectionPage.IndexOf("Pool address</th><td>")).Split('>')[2]).Split('<')[0];
                connectedServerLbl.Text = connectionPage;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            writeConfigs();
        }

        private void autoConfigCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (autoConfigCheck.Checked)
            {
                cpuThreadNum.Enabled = false;
                cpuLowPowerCheck.Enabled = false;
                aesCb.Enabled = false;
            }
            else
            {
                cpuThreadNum.Enabled = true;
                cpuLowPowerCheck.Enabled = true;
                aesCb.Enabled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value * 1000;
        }
    }
}
