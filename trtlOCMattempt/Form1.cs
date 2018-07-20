﻿using System;
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

namespace trtlOCM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1200;

            startBtn.Enabled = false;
            startBtn.Text = "Initializing pools...";

            addressTb.Text = trtlOCM.Properties.Settings.Default.savedAddress;
            cpuMiningCheck.Checked = trtlOCM.Properties.Settings.Default.cpuCb;
            nvidiaMiningCheck.Checked = trtlOCM.Properties.Settings.Default.nvCb;
            amdMiningCheck.Checked = trtlOCM.Properties.Settings.Default.amdCb;
            gpuMiningCheck.Checked = trtlOCM.Properties.Settings.Default.gpuCb;
            cpuUsageNum.Value = trtlOCM.Properties.Settings.Default.cpuPerc;
            hardwareCb.SelectedIndex = trtlOCM.Properties.Settings.Default.hwType;
            refreshTimeNum.Value = trtlOCM.Properties.Settings.Default.statsSecs;
            writeLogCheck.Checked = trtlOCM.Properties.Settings.Default.logCb;
            showCLICheck.Checked = trtlOCM.Properties.Settings.Default.cliCb;
            minerSelectionCb.SelectedIndex = trtlOCM.Properties.Settings.Default.minerPreference;

            initPools();
        }

        string currentPoolList;
        Queue<Process> activeMiners = new Queue<Process>();

        private void initPools()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(writePoolsToList);
            wc.DownloadStringAsync(new Uri("https://raw.githubusercontent.com/turtlecoin/turtlecoin-pools-json/master/v2/turtlecoin-pools.json"));
        }

        private async void writePoolsToList(object sender, DownloadStringCompletedEventArgs e)
        {
            currentPoolList = e.Result;
            List<string[]> poolInfoList;
            Task<List<string[]>> poolInfoTask = new Task<List<string[]>>(GetPoolInfo);
            poolInfoTask.Start();
            poolInfoList = await poolInfoTask;

            foreach (string[] poolInfo in poolInfoList)
            {
                if (poolInfo[0] != "" && poolInfo[1] != "")
                {
                    PoolEntry entryElement = new PoolEntry(poolInfo[0], poolInfo[1], poolInfo[2]);
                    entryElement.setAutoUpdate(poolStatsUpdateCb.Checked);
                    entryElement.selectedCb.Enabled = selectionModeCb.Text == "manual selection" ? true : false;

                    entryElement.selectedCb.Checked = trtlOCM.Properties.Settings.Default.savedPools.Contains(poolInfo[2]);

                    entryElement.Dock = DockStyle.Top;
                    poolListPanel.Controls.Add(entryElement);
                }
            }

            startBtn.Enabled = true;
            startBtn.Text = "Start mining!";
        }

        private List<string[]> GetPoolInfo()
        {
            List<string[]> res = new List<string[]>();

            string[] poolListElements = currentPoolList.Split('{');
            foreach(string poolInfoEntry in poolListElements)
            {
                // can only support forknote pools this way
                if (poolInfoEntry.Contains("url") && poolInfoEntry.Contains("api") && poolInfoEntry.Contains("forknote"))
                { 
                    string[] pool = new string[3];

                    pool[0] = poolInfoEntry.Split('"')[7];
                    pool[1] = poolInfoEntry.Split('"')[11];
                    pool[2] = poolInfoEntry.Split('"')[19];

                    res.Add(pool);
                }
            }

            return res;
        }

        private List<string> GetSelectedPools()
        {
            List<string> selectedPools = new List<string>();

            foreach (PoolEntry pe in poolListPanel.Controls)
            {
                if (pe.selectedCb.Checked)
                {
                    selectedPools.Add(pe.getMiningAddress());
                }
            }

            return selectedPools;
        }

        private void AnalyzePoolsByCondition(object sender, EventArgs e)
        {
            switch (selectionModeCb.Text)
            {
                case "lower ping":
                    //int pingAvg = 0;

                    //foreach (PoolEntry pe in poolListPanel.Controls)
                    //{
                    //    pe.selectedCb.Enabled = false;
                    //    if (pe.getPing() != -1) pingAvg = pingAvg == 0 ? pe.getPing() : (pingAvg + pe.getPing()) / 2;
                    //}

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        pe.selectedCb.Enabled = false;
                        if (pe.getPing() != -1)
                        {
                            if (pe.getPing() < 50)
                            {
                                pe.selectedCb.Checked = true;
                            }
                            else pe.selectedCb.Checked = false;
                        }
                        else pe.selectedCb.Checked = false;
                    }

                    break;
                case "smaller payouts":
                    //double payAvg = 0;

                    //foreach (PoolEntry pe in poolListPanel.Controls)
                    //{
                    //    pe.selectedCb.Enabled = false;
                    //    if (pe.getMinPayout() != -1) payAvg = payAvg == 0 ? pe.getMinPayout() : (payAvg + pe.getMinPayout()) / 2;
                    //}

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        pe.selectedCb.Enabled = false;
                        if (pe.getMinPayout() != -1) { 
                            if (pe.getMinPayout() < 500) { 
                                pe.selectedCb.Checked = true;
                            }
                            else pe.selectedCb.Checked = false;
                        }
                        else pe.selectedCb.Checked = false;
                    }

                    break;
                case "larger payouts":
                    //payAvg = 0;

                    //foreach (PoolEntry pe in poolListPanel.Controls)
                    //{
                    //    pe.selectedCb.Enabled = false;
                    //    if (pe.getMinPayout() != -1) payAvg = payAvg == 0 ? pe.getMinPayout() : (payAvg + pe.getMinPayout()) / 2;
                    //}

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        pe.selectedCb.Enabled = false;
                        if (pe.getMinPayout() != -1) { 
                            if (pe.getMinPayout() >= 500) { 
                                pe.selectedCb.Checked = true;
                            }
                            else pe.selectedCb.Checked = false;
                        }
                        else pe.selectedCb.Checked = false;
                    }
                    break;
                case "lower hashrate":
                    int hashAvg = 0;

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        pe.selectedCb.Enabled = false;
                        if (pe.getHashrate() != -1) hashAvg = hashAvg == 0 ? pe.getHashrate() : (hashAvg + pe.getHashrate()) / 2;
                    }

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        if (pe.getHashrate() != -1) { 
                            if (pe.getHashrate() < hashAvg) { 
                                pe.selectedCb.Checked = true;
                            }
                            else pe.selectedCb.Checked = false;
                        }
                        else pe.selectedCb.Checked = false;
                    }

                    break;
                case "higher hashrate":
                    hashAvg = 0;

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        pe.selectedCb.Enabled = false;
                        if (pe.getHashrate() != -1) hashAvg = hashAvg == 0 ? pe.getHashrate() : (hashAvg + pe.getHashrate()) / 2;
                    }

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        if (pe.getHashrate() != -1) { 
                            if (pe.getHashrate() > hashAvg) { 
                                pe.selectedCb.Checked = true;
                            }
                            else pe.selectedCb.Checked = false;
                        }
                        else pe.selectedCb.Checked = false;
                    }

                    break;
                case "lower fee":
                    //double feeAvg = 0;

                    //foreach (PoolEntry pe in poolListPanel.Controls)
                    //{
                    //    pe.selectedCb.Enabled = false;
                    //    if (pe.getFee() != -1) feeAvg = feeAvg == 0 ? pe.getFee() : (feeAvg + pe.getFee()) / 2;
                    //}

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        if (pe.getFee() != -1) {
                            pe.selectedCb.Enabled = false;
                            if (pe.getFee() <= 0.1) { 
                                pe.selectedCb.Checked = true;
                            }
                            else pe.selectedCb.Checked = false;
                        }
                        else pe.selectedCb.Checked = false;
                    }

                    break;
                case "higher fee":
                    //feeAvg = 0;

                    //foreach (PoolEntry pe in poolListPanel.Controls)
                    //{
                    //    pe.selectedCb.Enabled = false;
                    //    if (pe.getFee() != -1) feeAvg = feeAvg == 0 ? pe.getFee() : (feeAvg + pe.getFee()) / 2;
                    //}

                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        pe.selectedCb.Enabled = false;
                        if (pe.getFee() != -1) { 
                            if (pe.getFee() > 0.1) { 
                                pe.selectedCb.Checked = true;
                            }
                            else pe.selectedCb.Checked = false;
                        }
                        else pe.selectedCb.Checked = false;
                    }

                    break;
                case "manual selection":
                    foreach (PoolEntry pe in poolListPanel.Controls)
                    {
                        pe.selectedCb.Enabled = true;
                    }
                    break;
                default:
                    break;
            }

            trtlOCM.Properties.Settings.Default.poolPreference = selectionModeCb.SelectedIndex;
        }
        
        private string MinerExecutableNotFound(string filename)
        {
            if(MessageBox.Show("The miner's executable could not be found at " + filename + ". Please check the folder structure or if an Anti-Virus program removed the file at that place. If you want to locate " + filename + " click OK, otherwise click Cancel.", "Miner not found", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                OpenFileDialog openMiner = new OpenFileDialog();
                openMiner.Filter = "Executable|*.exe";
                openMiner.Multiselect = false;
                openMiner.Title = "Locate miner executable";
                if (openMiner.ShowDialog() == DialogResult.OK)
                {
                    return openMiner.FileName;
                }
            }

            return "";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start mining!")
            {
                if (addressRb.Checked && !addressTb.Text.StartsWith("TRTL") && addressTb.Text.Length != 99)
                {
                    MessageBox.Show("Please check your TurtleCoin receiving address.");
                    return;
                }

                if (GetSelectedPools().Count == 0)
                {
                    AnalyzePoolsByCondition(sender, e);
                }

                if (GetSelectedPools().Count == 0)
                {
                    MessageBox.Show("No pools selected to mine on! Please check your pool selection.");
                    return;
                }

                string chosenPort = "";

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

                if (minerSelectionCb.Text == "XMRig")
                {
                    string arguments = "";

                    ProcessStartInfo cpuMinerInfo = new ProcessStartInfo();
                    ProcessStartInfo amdMinerInfo = new ProcessStartInfo();
                    ProcessStartInfo nvidiaMinerInfo = new ProcessStartInfo();

                    arguments += "-a cryptonight-lite ";
                    if (!showCLICheck.Checked) arguments += "-B ";
                    arguments += "--donate-level 1 ";

                    foreach(string pool in GetSelectedPools())
                    {
                        arguments += "-o " + pool + chosenPort + " -u " + addressTb.Text + " -p x --variant 1 -k ";
                    }

                    if (cpuMiningCheck.Checked)
                    {
                        string cpuArguments = arguments;
                        Process miner = new Process();

                        if (writeLogCheck.Checked) arguments += "-l logcpu.txt ";
                        cpuArguments += "--api-port 6666 ";
                        cpuArguments += "--max-cpu-usage " + cpuUsageNum.Value + " ";

                        cpuMinerInfo.WorkingDirectory = Directory.GetCurrentDirectory();

                        cpuMinerInfo.FileName = trtlOCM.Properties.Settings.Default.xmrigCPUpath; // @"miners\xmrig\xmrig.exe";
                        cpuMinerInfo.Arguments = cpuArguments;
                        if (showCLICheck.Checked)
                        {
                            cpuMinerInfo.WindowStyle = ProcessWindowStyle.Normal;
                        }
                        else
                        {
                            cpuMinerInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        }
                        miner.StartInfo = cpuMinerInfo;

                        try
                        {
                            miner.Start();
                        }
                        catch (Exception excep)
                        {
                            string location = MinerExecutableNotFound(miner.StartInfo.FileName);
                            if (location != "")
                            {
                                miner.StartInfo.FileName = location;
                                trtlOCM.Properties.Settings.Default.xmrigCPUpath = location;
                                miner.Start();
                            }
                            else
                            {
                                MessageBox.Show("Couldn't start xmrig CPU miner. Please check your configuration and folder structure.");
                                return;
                            }
                        }

                        activeMiners.Enqueue(miner);
                    }
                    if (amdMiningCheck.Checked)
                    {
                        string amdArguments = arguments;
                        Process miner = new Process();

                        if (writeLogCheck.Checked) arguments += "-l logamd.txt ";
                        amdArguments += "--api-port 6667 ";

                        amdMinerInfo.WorkingDirectory = Directory.GetCurrentDirectory();

                        amdMinerInfo.FileName = trtlOCM.Properties.Settings.Default.xmrigAMDpath; //@"miners\xmrigamd\xmrig-amd.exe";
                        amdMinerInfo.Arguments = amdArguments;
                        if (showCLICheck.Checked)
                        {
                            amdMinerInfo.WindowStyle = ProcessWindowStyle.Normal;
                        }
                        else
                        {
                            amdMinerInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        }
                        miner.StartInfo = amdMinerInfo;

                        try
                        {
                            miner.Start();
                        }
                        catch (Exception excep)
                        {
                            string location = MinerExecutableNotFound(miner.StartInfo.FileName);
                            if (location != "")
                            {
                                miner.StartInfo.FileName = location;
                                trtlOCM.Properties.Settings.Default.xmrigAMDpath = location;
                                miner.Start();
                            }
                            else
                            {
                                MessageBox.Show("Couldn't start xmrig AMD miner. Please check your configuration and folder structure.");
                                return;
                            }
                        }

                        activeMiners.Enqueue(miner);
                    }
                    if (nvidiaMiningCheck.Checked)
                    {
                        string nvidiaArguments = arguments;
                        Process miner = new Process();

                        if (writeLogCheck.Checked) arguments += "-l lognvidia.txt ";
                        nvidiaArguments += "--api-port 6668 ";

                        nvidiaMinerInfo.WorkingDirectory = Directory.GetCurrentDirectory();

                        nvidiaMinerInfo.FileName = trtlOCM.Properties.Settings.Default.xmrigNVpath; //@"miners\xmrignvidia\xmrig-nvidia.exe";
                        nvidiaMinerInfo.Arguments = nvidiaArguments;
                        if (showCLICheck.Checked)
                        {
                            nvidiaMinerInfo.WindowStyle = ProcessWindowStyle.Normal;
                        }
                        else
                        {
                            nvidiaMinerInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        }
                        miner.StartInfo = nvidiaMinerInfo;

                        try
                        {
                            miner.Start();
                        }
                        catch (Exception excep)
                        {
                            string location = MinerExecutableNotFound(miner.StartInfo.FileName);
                            if (location != "")
                            {
                                miner.StartInfo.FileName = location;
                                trtlOCM.Properties.Settings.Default.xmrigNVpath = location;
                                miner.Start();
                            }
                            else
                            {
                                MessageBox.Show("Couldn't start xmrig nvidia miner. Please check your configuration and folder structure.");
                                return;
                            }
                        }

                        activeMiners.Enqueue(miner);
                    }
                }
                else if (minerSelectionCb.Text == "XMR-stak")
                {
                    Process miner = new Process();
                    ProcessStartInfo minerInfo = new ProcessStartInfo();
                    string arguments = "--noUAC";

                    if (!cpuMiningCheck.Checked)
                    {
                        arguments += " --noCPU";
                    }
                    if (!gpuMiningCheck.Checked)
                    {
                        arguments += " --noAMD --noNVIDIA";
                    }

                    arguments += " --currency cryptonight_lite_v7";
                    arguments += " -i 6777 -r trtlocm";

                    foreach (string pool in GetSelectedPools())
                    {
                        arguments += " -o " + pool + chosenPort + " -u " + addressTb.Text + " -p x";
                    }

                    if (showCLICheck.Checked)
                    {
                        minerInfo.WindowStyle = ProcessWindowStyle.Normal;
                    }
                    else
                    {
                        minerInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    }

                    minerInfo.WorkingDirectory = Directory.GetCurrentDirectory();

                    minerInfo.FileName = trtlOCM.Properties.Settings.Default.xmrstakpath; //@"miners\xmr-stak\xmr-stak.exe";
                    minerInfo.Arguments = arguments;

                    miner.StartInfo = minerInfo;

                    try
                    {
                        miner.Start();
                    }
                    catch (Exception excep)
                    {
                        string location = MinerExecutableNotFound(miner.StartInfo.FileName);
                        if (location != "")
                        {
                            miner.StartInfo.FileName = location;
                            trtlOCM.Properties.Settings.Default.xmrstakpath = location;
                            miner.Start();
                        }
                        else
                        {
                            MessageBox.Show("Couldn't start xmrstak miner. Please check your configuration and folder structure.");
                            return;
                        }
                    }

                    activeMiners.Enqueue(miner);
                }
                
                if(activeMiners.Count == 0)
                {
                    MessageBox.Show("No miners to start! Please check your hardware selection.");
                    return;
                }

                trtlOCM.Properties.Settings.Default.Save();

                timer1.Start();

                startBtn.Text = "Stop mining!";
            } else
            {
                try
                {
                    while(activeMiners.Count > 0)
                    {
                        activeMiners.Dequeue().Kill();
                    }
                    timer1.Stop();

                    hashrateLbl.Text = "Stats - Hashrate: STOPPED";
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
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Always mine at your own risk for your hardware!\nYour computer might become unresponsive while mining.\nThe program automatically selects the best pool according to its ping time or other selectable parameters.\nThe integrated miners (xmr-stak by fireice-uk and xmrig by psychocrypt) both licensed GPL contain a\ndev fee. I decided to keep them as they're nice pieces of software that deserve help.", "Read this first!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("With the CPU/GPU checkboxes you can (de)select which hardware xmrig/xmr-stak are supposed to mine on.\nPlease also select your hardware range to mine on certain ports with suitable difficulties.\nMine to address tells the pool to payout the mined TRTLs to the given address in the textbox.\nMine to raindance sends all generated TRTLs to the TurtleRainBot which divides the Turtlecoins between participating users on the official Turtlecoin Discord community. (currently disabled, please consider donations to RainBorg as described on our Discord server)\nAdvanced options are the possibility to enable logs by the miners and to view their CLIs. More are currently hidden which might change with the next releases. If you want to change specific tuning settings, please use the config files created by the miners in their folders.", "Settings explained", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This One Click Miner for TurtleCoin programmed by Encrypted Unicorn is a graphical interface for mining TRTL on pools in the network using xmrig by psychocrypt or xmr-stak by fireice-uk. You can find the ocm's source code on TurtleCoin's GitHub and source codes for the bundled miners on their corresponding GitHub pages. Not related to xmr-stak or xmrig.\nVersion 1.0 beta 2", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (minerSelectionCb.Text == "XMRig")
                {
                    WebClient w = new WebClient();

                    double hashrate = 0;
                    int shares = 0;
                    int shares_total = 0;
                    int diff = 0;
                    int best = 0;
                    string connectedto = "";

                    if (cpuMiningCheck.Checked)
                    {
                        string cpu_json = w.DownloadString("http://localhost:6666/");

                        hashrate += double.Parse(cpu_json.Substring(cpu_json.IndexOf(@"""total"": [")).Split('[')[1].Split(',')[0]);

                        shares += int.Parse(cpu_json.Substring(cpu_json.IndexOf(@"""shares_good"":")).Split(':')[1].Split(',')[0]);
                        shares_total += int.Parse(cpu_json.Substring(cpu_json.IndexOf(@"""shares_total"":")).Split(':')[1].Split(',')[0]);

                        diff += int.Parse(cpu_json.Substring(cpu_json.IndexOf(@"""diff_current"":")).Split(':')[1].Split(',')[0]);

                        int pbest = int.Parse(cpu_json.Substring(cpu_json.IndexOf(@"""best"": [")).Split('[')[1].Split(',')[0]);
                        best = best < pbest ? pbest : best;

                        connectedto += cpu_json.Substring(cpu_json.IndexOf(@"""pool"":")).Split(':')[1].Split(',')[0];
                    }
                    if (amdMiningCheck.Checked)
                    {
                        string amd_json = w.DownloadString("http://localhost:6667/");

                        hashrate += double.Parse(amd_json.Substring(amd_json.IndexOf(@"""total"": [")).Split('[')[1].Split(',')[0]);

                        shares += int.Parse(amd_json.Substring(amd_json.IndexOf(@"""shares_good"":")).Split(':')[1].Split(',')[0]);
                        shares_total += int.Parse(amd_json.Substring(amd_json.IndexOf(@"""shares_total"":")).Split(':')[1].Split(',')[0]);

                        diff += int.Parse(amd_json.Substring(amd_json.IndexOf(@"""diff_current"":")).Split(':')[1].Split(',')[0]);

                        int pbest = int.Parse(amd_json.Substring(amd_json.IndexOf(@"""best"": [")).Split('[')[1].Split(',')[0]);
                        best = best < pbest ? pbest : best;

                        string cnt = amd_json.Substring(amd_json.IndexOf(@"""pool"":")).Split(':')[1].Split(',')[0];
                        connectedto += connectedto == cnt ? "" : cnt;
                    }
                    if (nvidiaMiningCheck.Checked)
                    {
                        string nvidia_json = w.DownloadString("http://localhost:6668/");

                        hashrate += double.Parse(nvidia_json.Substring(nvidia_json.IndexOf(@"""total"": [")).Split('[')[1].Split(',')[0]);

                        shares += int.Parse(nvidia_json.Substring(nvidia_json.IndexOf(@"""shares_good"":")).Split(':')[1].Split(',')[0]);
                        shares_total += int.Parse(nvidia_json.Substring(nvidia_json.IndexOf(@"""shares_total"":")).Split(':')[1].Split(',')[0]);

                        diff += int.Parse(nvidia_json.Substring(nvidia_json.IndexOf(@"""diff_current"":")).Split(':')[1].Split(',')[0]);

                        int pbest = int.Parse(nvidia_json.Substring(nvidia_json.IndexOf(@"""best"": [")).Split('[')[1].Split(',')[0]);
                        best = best < pbest ? pbest : best;

                        string cnt = nvidia_json.Substring(nvidia_json.IndexOf(@"""pool"":")).Split(':')[1].Split(',')[0];
                        connectedto += connectedto == cnt ? "" : cnt;
                    }

                    hashrateLbl.Text = "Stats - Hashrate: " +  (hashrate / 100.0).ToString() + " H/s";
                    double sh_perc = ((double)shares / (double)shares_total) * 100.0;
                    shareCountLbl.Text = "Shares: " + shares.ToString() + " / " + shares_total.ToString() + " (" + sh_perc.ToString() + "%)";
                    bestShareLbl.Text = "Best: " + best.ToString();
                    difficultyLbl.Text = "Difficulty: " + diff.ToString();
                    connectedServerLbl.Text = "Connected to: " + connectedto.Replace('"', ' ');
                }
                else if (minerSelectionCb.Text == "XMR-stak")
                {
                    WebClient w = new WebClient();

                    string hashrate = w.DownloadString("http://localhost:6777/h");
                    hashrate = "Stats - Hashrate: " + (hashrate.Substring(hashrate.IndexOf("Totals:</th><td>")).Split('>')[2]).Split('<')[0] + " H/s";
                    hashrateLbl.Text = hashrate;
                    
                    string resultPage = w.DownloadString("http://localhost:6777/r");
                    
                    string shareCount = "Shares: " + (resultPage.Substring(resultPage.IndexOf("Good results</th><td>")).Split('>')[2]).Split('<')[0];
                    string bestShare = "Best: " + (resultPage.Substring(resultPage.IndexOf("1</th><td>")).Split('>')[2]).Split('<')[0];
                    string diff = "Difficulty: " + (resultPage.Substring(resultPage.IndexOf("Difficulty</th><td>")).Split('>')[2]).Split('<')[0];
                    shareCountLbl.Text = shareCount;
                    bestShareLbl.Text = bestShare;
                    difficultyLbl.Text = diff;

                    string connectionPage = w.DownloadString("http://localhost:6777/c");
                    connectionPage = "Connected to: " + (connectionPage.Substring(connectionPage.IndexOf("Pool address</th><td>")).Split('>')[2]).Split('<')[0];
                    connectedServerLbl.Text = connectionPage;
                }
            } catch (Exception excp)
            {
                MessageBox.Show("An error occured while fetching miner's api data: " + excp.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            addressRb.Checked = true;
            raindanceRb.Checked = false;

            trtlOCM.Properties.Settings.Default.savedAddress = addressTb.Text;
        }

        private void advancedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (advancedCheck.Checked)
            {
                this.Width = 1200;
            } else
            {
                this.Width = 560;
            }
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
            timer1.Interval = (int)refreshTimeNum.Value * 1000;

            trtlOCM.Properties.Settings.Default.statsSecs = (int)refreshTimeNum.Value;
        }

        private void poolStatsUpdateCb_CheckedChanged(object sender, EventArgs e)
        {
            foreach(PoolEntry pe in poolListPanel.Controls)
            {
                pe.setAutoUpdate(poolStatsUpdateCb.Checked);
            }
        }

        private void removePoolBtn_Click(object sender, EventArgs e)
        {
            int index = poolListPanel.Controls.Count - 1;
            poolListPanel.Controls.RemoveAt(index);
        }
        
        private void minerSelectionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(minerSelectionCb.Text == "XMRig")
            {
                amdMiningCheck.Enabled = true;
                nvidiaMiningCheck.Enabled = true;
                gpuMiningCheck.Enabled = false;
                cpuUsageNum.Enabled = true;
            } else
            {
                amdMiningCheck.Enabled = false;
                nvidiaMiningCheck.Enabled = false;
                gpuMiningCheck.Enabled = true;
                cpuUsageNum.Enabled = false;
            }

            trtlOCM.Properties.Settings.Default.minerPreference = minerSelectionCb.SelectedIndex;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (PoolEntry pe in poolListPanel.Controls)
            {
                pe.UpdateStats();
            }
        }

        private void cpuMiningCheck_CheckedChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.cpuCb = cpuMiningCheck.Checked;
        }

        private void gpuMiningCheck_CheckedChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.gpuCb = gpuMiningCheck.Checked;
        }

        private void amdMiningCheck_CheckedChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.amdCb = amdMiningCheck.Checked;
        }

        private void nvidiaMiningCheck_CheckedChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.nvCb = nvidiaMiningCheck.Checked;
        }

        private void hardwareCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.hwType = hardwareCb.SelectedIndex;
        }

        private void writeLogCheck_CheckedChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.logCb = writeLogCheck.Checked;
        }

        private void showCLICheck_CheckedChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.cliCb = showCLICheck.Checked;
        }

        private void cpuUsageNum_ValueChanged(object sender, EventArgs e)
        {
            trtlOCM.Properties.Settings.Default.cpuPerc = (int)cpuUsageNum.Value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            trtlOCM.Properties.Settings.Default.Save();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(MessageBox.Show("You are about to reset all settings and saved properties, are sure to continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            trtlOCM.Properties.Settings.Default.savedPools = "";
            trtlOCM.Properties.Settings.Default.savedAddress = "";
            trtlOCM.Properties.Settings.Default.cpuCb = true;
            trtlOCM.Properties.Settings.Default.nvCb = false;
            trtlOCM.Properties.Settings.Default.amdCb = false;
            trtlOCM.Properties.Settings.Default.gpuCb = true;
            trtlOCM.Properties.Settings.Default.cpuPerc = 100;
            trtlOCM.Properties.Settings.Default.hwType = 0;
            trtlOCM.Properties.Settings.Default.statsSecs = 10;
            trtlOCM.Properties.Settings.Default.logCb = false;
            trtlOCM.Properties.Settings.Default.cliCb = false;
            trtlOCM.Properties.Settings.Default.minerPreference = 0;
            trtlOCM.Properties.Settings.Default.poolPreference = 0;
            trtlOCM.Properties.Settings.Default.xmrigCPUpath = @"miners\xmrig\xmrig.exe";
            trtlOCM.Properties.Settings.Default.xmrigAMDpath = @"miners\xmrigamd\xmrig-amd.exe";
            trtlOCM.Properties.Settings.Default.xmrigNVpath = @"miners\xmrignvidia\xmrig-nvidia.exe";
            trtlOCM.Properties.Settings.Default.xmrstakpath = @"miners\xmr-stak\xmr-stak.exe";


            addressTb.Text = trtlOCM.Properties.Settings.Default.savedAddress;
            cpuMiningCheck.Checked = trtlOCM.Properties.Settings.Default.cpuCb;
            nvidiaMiningCheck.Checked = trtlOCM.Properties.Settings.Default.nvCb;
            amdMiningCheck.Checked = trtlOCM.Properties.Settings.Default.amdCb;
            gpuMiningCheck.Checked = trtlOCM.Properties.Settings.Default.gpuCb;
            cpuUsageNum.Value = trtlOCM.Properties.Settings.Default.cpuPerc;
            hardwareCb.SelectedIndex = trtlOCM.Properties.Settings.Default.hwType;
            refreshTimeNum.Value = trtlOCM.Properties.Settings.Default.statsSecs;
            writeLogCheck.Checked = trtlOCM.Properties.Settings.Default.logCb;
            showCLICheck.Checked = trtlOCM.Properties.Settings.Default.cliCb;
            minerSelectionCb.SelectedIndex = trtlOCM.Properties.Settings.Default.minerPreference;
            selectionModeCb.SelectedIndex = trtlOCM.Properties.Settings.Default.poolPreference;

            poolListPanel.Controls.Clear();
            initPools();

            trtlOCM.Properties.Settings.Default.Save();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("In this section you can see the statistics of the miners.\nThe 'Hashrate' is the number of hashes the miner computes in one second, which depends on the performance of your PC.\n'Shares' count the number of (valid/total) Proof-of-Work solutions the miners found and submitted to the pool.\n'Connected to' displays the currently active connection to a mining pool.\n'Best' views the difficulty of the best found share (PoW solution).\n'Difficulty' displays the current difficulty the pool assigned to your miner(s) to find a valid share.\nIf more than one mining process has been launched, the stats of all running miners are added (shares, difficulty) / redundancies discarded (connection, best share) after comparison.");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Here you have to select what kind of hardware you have and which you want to mine with. Please check whether you want to use the miner for CPU and/or GPU (xmrstak) or which GPU brand you have (xmrig).\nPlease also select the hardware type of your PC as pools offer different difficulties for low or high end computers.\nEnter the TurtleCoin address you want to mine to in the text box, it will be saved unless you change it again.\nYou can also set the frequency of updates to the mining statistics above.");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("In this section you can see information about available mining pools and select under which consideration pools will be chosen automatically by the program or select the pool(s) you want to mine on manually.\nUsually, pools with a low ping time are to be preferred. If you are a slow miner, you can select a pool with a lower payment threshold or the other way around for faster computers. Pools that have a high hashrate usually find blocks faster a produce payments sooner. To keep the network decentralized, it's better to not over-power leading pools though. Selecting multiple pools only gives you the possibility to have a backup selection in case of one of your selected pools going down.\nPlease wait for all stats and pings to load.\nPools that can't be pinged or don't respond to the API request are automatically discarded by the program right now, sorry for that!");
        }
    }
}
