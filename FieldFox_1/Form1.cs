using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using MccDaq;
using System.Threading;
using System.Diagnostics;


namespace FieldFox_1
{
    public partial class Form1 : Form
    {
        string hostName = "192.168.0.1";
        TelnetConnection tc = new TelnetConnection();
        string basicPath = @"C:\FieldFox";
        string folderName = "";
        MccBoard myBoard = new MccBoard(0);
        MccDaq.ScanOptions Options;
        MccDaq.Range Range;
        ushort dataValue;
        List<float> engUnits;
        int counterMeas = 0;
        int ms = 0;
        Thread oThread;
        private IntPtr MemHandle = IntPtr.Zero;
        int pointsNumOnGraph = 3 * 200;
        int NumPoints = 600;
        int numOfPointsPerGraphPoint = 60;
        ushort[] ADData;
        Stopwatch sw = new Stopwatch();
        System.Timers.Timer fieldFoxTimer = new System.Timers.Timer();
        int fieldFoxTimerTickCounter = 0;
        int switchFolderFilesNumber = 50;
        int folderNumber = 0;
        int numOfIterations = -1;
        DateTime finalTime;
        string pathString = "";
        string logLine = "";
        int chartPulseTimerCounter = 0;

        public List<float> AveragePoints(ushort[] data)
        {
            List<float> newGrpahPoints = new List<float>();
            float tempSum = 0;
            int ind = 0;
            foreach (ushort i in data)
            {
                if (ind == numOfPointsPerGraphPoint - 1)
                {
                    newGrpahPoints.Add((tempSum / numOfPointsPerGraphPoint));
                    ind = 0;
                    tempSum = 0;
                }
                ind++;
                tempSum = tempSum + i;
            }
            return newGrpahPoints;
        }


        public void CountMeas()
        {
            while (true)
            {
                sw = new Stopwatch();
                sw.Start();
                int Rate = 5000;
                //myBoard.AIn(0, MccDaq.Range.Bip10Volts, out dataValue);
                //myBoard.ToEngUnits(MccDaq.Range.Bip1Volts, dataValue, out engUnits);
                myBoard.AInScan(0, 0, NumPoints, ref Rate, Range, MemHandle, Options);
                MccDaq.MccService.WinBufToArray(MemHandle, ADData, 0, NumPoints);
                //engUnits  = (float)ADData.Select(x => (int)x).Average();
                if (folderName.Length!=0)
                {
                    string timeStr = ((DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();
                    string result = timeStr + " " + string.Join(" ", ADData);
                    string pathString = System.IO.Path.Combine(basicPath, folderName);

                    using (StreamWriter w = File.AppendText(System.IO.Path.Combine(pathString, "log.txt")))
                    {
                        w.WriteLine(result);
                    }
                }
                engUnits = AveragePoints(ADData);
                sw.Stop();
            }
        }

       

        public Form1()
        {
            oThread = new Thread(new ThreadStart(CountMeas));
            InitializeComponent();

            chart1.ChartAreas[0].AxisY.Maximum = 3;
            chart1.ChartAreas[0].AxisY.Minimum = 2;
            ADData = new ushort[NumPoints];
            MemHandle = MccDaq.MccService.WinBufAllocEx(NumPoints);
            //Options = MccDaq.ScanOptions.ConvertData;
            Options = MccDaq.ScanOptions.BurstIo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tc.ReadTimeout = 10000; // 10 sec

            Start_Freq_textBox.Text = "2";
            End_Freq_textBox.Text = "6000";
            Points_num_textBox.Text = "201";
            IF_bandW_textBox.Text = "300";
            Avg_num_textBox.Text = "1";
            Sweep_radioButton.Checked = true;
            stopMeasByTime_radioButton.Checked = true;
            Folder_name_textBox.Text = "";
            Meas_time_textBox.Text = "20";
            betweenMeasDelay_textBox.Text = "60";
            numOfIterations_textBox.Text = "1";
            startStopFreq_checkBox.Checked = true;
            freqCenter_textBox.Text = "3000";
            freqSpan_textBox.Text = "0";
            freqCenter_textBox.Enabled = false;
            freqSpan_textBox.Enabled = false;
            radioButton_S11.Checked = true;
        }

        private void Send_param_button_Click(object sender, EventArgs e)
        {

            try
            {
                string avgMode = "SWEEP";

                // open socket on hostName, which can be an IP address, or use host name (e.g. "A-N9912A-22762") used in lieu of IP address
                tc.Open(hostName);
                if (tc.IsOpen)
                {

                    Write("SYST:PRES;*OPC?");
                    Write("*IDN?");
                    string sParam = groupBox_sParam.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
                    Write("CALC:PAR:DEF " + sParam);
                    if (startStopFreq_checkBox.Checked)
                    {
                        Write("SENS:FREQ:START " + (Convert.ToDouble(Start_Freq_textBox.Text) * 1e6).ToString());
                        Write("SENS:FREQ:STOP " + (Convert.ToDouble(End_Freq_textBox.Text) * 1e6).ToString());
                    }
                    else
                    {
                        Write("SENS:FREQ:CENTER " + (Convert.ToDouble(freqCenter_textBox.Text) * 1e6).ToString());
                        Write("SENS:FREQ:SPAN " + (Convert.ToDouble(freqSpan_textBox.Text) * 1e6).ToString());
                    }
                    Write("SENS:SWEEP:POINTS " + (Convert.ToInt32(Points_num_textBox.Text)).ToString());
                    Write("SENS:BWID " + (Convert.ToInt32(IF_bandW_textBox.Text)).ToString());
                    Write("AVER:COUNt " + (Convert.ToInt32(Avg_num_textBox.Text)).ToString());
                    if (Point_radioButton.Checked)
                    {
                        avgMode = "POINT";
                    }
                    Write("AVERage:MODE " + avgMode);
                    Thread.Sleep(3000);
                    Write("DISP:WIND:TRAC1:Y:AUTO");
                    Write("SYST:ERR?");

                    tc.Dispose();

                }
                else
                {
                    UpdateLog("Error opening " + hostName);

                }
                //FieldFox Programming Guide 5
            }
            catch (Exception exep)
            {
                UpdateLog(exep.ToString() + "\n");

            }

        }

        void StopFieldFoxMeasurement()
        {
            fieldFoxTimer.Stop();
            UpdateLog("Going to sleep 10 seconds before start uploading the files");
            Thread.Sleep(10 * 1000);

            //Iterate over the temporary folders
            for (int tempFolder = 0; tempFolder <= folderNumber; tempFolder++)
            {
                Write("MMEM:CDIR \"[INTERNAL]:\\" + folderName + "\\" + tempFolder.ToString() + "\"");
                //Get files list
                string fileList = Write("MMEM:CAT?");
                List<string> names = fileList.Split(',').ToList<string>();

                //Copy file to PC
                foreach (string fileName in names)
                {
                    if (fileName.Contains("s2p"))
                    {
                        string cleanFileName = fileName.Replace("\"", "").Replace("\\", "");
                        string cmd = "MMEM:DATA? \"" + cleanFileName + "\"";
                        var temp = Write(cmd, false);
                        FileStream fs1 = new FileStream(pathString + "\\" + cleanFileName, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs1);
                        writer.Write(temp);
                        writer.Close();
                    }
                }
            }
            //Remove the folder on NA                        

            Write("MMEM:CDIR \"[INTERNAL]:\\\"");
            Write("MMEM:RDIR \"" + folderName + "\",\"recursive\"");
        }

        void fieldFoxTimer_TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if ((fieldFoxTimerTickCounter % switchFolderFilesNumber) == 0)
                {
                    Write("MMEMory:MDIRectory \"[INTERNAL]:\\" + folderName + "\\" + folderNumber.ToString() + "\"");

                    //Move to temp folder
                    Write("MMEM:CDIR \"[INTERNAL]:\\" + folderName + "\\" + folderNumber.ToString() + "\"");
                    folderNumber++;
                }
                string fileName = DateTime.Now.ToString("HHmmssffff") + "_" + fieldFoxTimerTickCounter.ToString() + ".s2p";

                Write("MMEMory:STORe:SNP \"" + fileName + "\"");
                fieldFoxTimerTickCounter++;

                if (stopMeasByTime_radioButton.Checked)
                {
                    if (DateTime.Now >= finalTime)
                        StopFieldFoxMeasurement();

                }
                else
                {
                    if (fieldFoxTimerTickCounter >= numOfIterations)
                        StopFieldFoxMeasurement();
                }
            }
            catch (Exception exep)
            {
                UpdateLog(exep.ToString());

            }
        }

        private void Measure_button_Click(object sender, EventArgs e)
        {
            if (Folder_name_textBox.Text.Length < 4)
            {
                System.Windows.Forms.MessageBox.Show("You have to enter valid test name!");
            }
            else
            {
                if (MessageBox.Show("Are you sure that the current sweep time is correct?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        tc.Open(hostName);
                        if (tc.IsOpen)
                        {
                            //Create folder on NA
                            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                            folderName = timeStamp + "_" + Folder_name_textBox.Text;

                            Write("MMEMory:MDIRectory \"[INTERNAL]:\\" + folderName + "\"");

                            //Create folder on PC
                            pathString = System.IO.Path.Combine(basicPath, folderName);
                            Directory.CreateDirectory(pathString);

                            //Save on PC measurement parameters
                            string centerFreq = Write("SENS:FREQ:CENTER?");
                            string spanFreq = Write("SENS:FREQ:SPAN?");
                            string pointsNum = Write("SENS:SWEEP:POINTS?");
                            string sweepTime = Write("SENS:SWEEP:MTIME?");
                            string[] lines = { "centerFreq=" + centerFreq, "spanFreq=" + spanFreq, "pointsNum=" + pointsNum, "sweepTime=" + sweepTime };
                            System.IO.File.WriteAllLines(System.IO.Path.Combine(pathString, "NAParam.dat"), lines);

                            //Start from beginning - walk around to start reading buffer from beginning 
                            Write("AVER:COUNT 20");
                            Write("AVER:COUNT 1;");

                            //Save files
                            finalTime = DateTime.Now.AddSeconds(Convert.ToDouble(Meas_time_textBox.Text));
                            numOfIterations = Convert.ToInt32(numOfIterations_textBox.Text);
                            fieldFoxTimer.Interval = Convert.ToInt32(betweenMeasDelay_textBox.Text);
                            fieldFoxTimer.AutoReset = true;
                            fieldFoxTimer.Elapsed += new System.Timers.ElapsedEventHandler(fieldFoxTimer_TimerElapsed);
                            fieldFoxTimer.Start();
                        }

                    }
                    catch (Exception exep)
                    {
                        UpdateLog(exep.ToString());

                    }
                }
            }
        }

        public string Write(string s, bool writeToLog = true)
        {
            string ret = "";
            UpdateLog(s);

            tc.Write1(s);
            if (s.IndexOf('?') >= 0)
                ret = Read(writeToLog);
            return ret;
        }

        public string Read(bool writeToLog = true)
        {
            string res = "";
            try
            {
                res = tc.Read();
                if (writeToLog)
                {
                    UpdateLog(res);
                }
            }
            catch (Exception exep)
            {
                UpdateLog("Error during reading!");
                UpdateLog(exep.ToString());
            }
            return res;
        }

        private void startStopFreq_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startStopFreq_checkBox.Checked)
            {
                Start_Freq_textBox.Enabled = true;
                End_Freq_textBox.Enabled = true;
                freqCenter_textBox.Enabled = false;
                freqSpan_textBox.Enabled = false;
            }
            else
            {
                Start_Freq_textBox.Enabled = false;
                End_Freq_textBox.Enabled = false;
                freqCenter_textBox.Enabled = true;
                freqSpan_textBox.Enabled = true;
            }
        }

        private void button_pulseMeter_Click_1(object sender, EventArgs e)
        {
            oThread.Start();
            timer1.Start();
        }

        delegate void SetGraphCallback();
        delegate void SetLogCallBack();

        private void UpdateLog(string str)
        {
            logLine = str;
            updateLogCB();
            logLine = "";
        }

        private void updateLogCB()
        {
            if (this.Log_textBox.InvokeRequired)
            {
                SetLogCallBack d = new SetLogCallBack(updateLogCB);
                this.Invoke(d, new object[] { });
            }
            else
            {
                Log_textBox.AppendText(logLine + "\n");
            }
        }

        private void updatePlot()
        {
            if (this.chart1.InvokeRequired)
            {
                SetGraphCallback d = new SetGraphCallback(updatePlot);
                this.Invoke(d, new object[] { });
            }
            else
            {
                if (engUnits != null)
                {
                    int newPointsNumber = NumPoints / numOfPointsPerGraphPoint;
                    counterMeas = counterMeas + newPointsNumber;
                    //myBoard.AIn(0, MccDaq.Range.Bip10Volts,out dataValue);
                    //myBoard.ToEngUnits(MccDaq.Range.Bip10Volts, dataValue, out engUnits);
                    //label1.Text = engUnits.ToString();
                    if (counterMeas > pointsNumOnGraph)
                    {
                        for (int i = 0; i < newPointsNumber; i++)
                            chart1.Series[0].Points.RemoveAt(0);// (counterMeas, (double)engUnits);
                    }
                    for (int i = 0; i < newPointsNumber; i++)
                        chart1.Series[0].Points.AddY(engUnits[i]);
                    // label1.Text = (sw.ElapsedMilliseconds).ToString();

                    chart1.Update();
                    chartPulseTimerCounter++;
                }
                if (chartPulseTimerCounter == 5)
                {
                    double max1 = chart1.Series[0].Points.FindMaxByValue().YValues[0];
                    double min1 = chart1.Series[0].Points.FindMinByValue().YValues[0];
                    double delta = Math.Abs(max1 * 0.001);
                    chart1.ChartAreas[0].AxisY.Maximum = max1 + delta;
                    chart1.ChartAreas[0].AxisY.Minimum = min1 - delta;
                    chartPulseTimerCounter = 0;
                }
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            updatePlot();
        }

        

        


    }

    #region TelnetConnection - no need to edit

    /// <summary>
    /// Telnet Connection on port 5025 to an instrument
    /// </summary>
    public class TelnetConnection : IDisposable
    {
        TcpClient m_Client;
        NetworkStream m_Stream;
        bool m_IsOpen = false;
        string m_Hostname;
        int m_ReadTimeout = 10000; // ms
        public delegate void ConnectionDelegate();
        public event ConnectionDelegate Opened;
        public event ConnectionDelegate Closed;
        public bool IsOpen { get { return m_IsOpen; } }
        public TelnetConnection() { }
        public TelnetConnection(bool open) : this("localhost", true) { }
        public TelnetConnection(string host, bool open)
        {
            if (open)
                Open(host);
        }
        void CheckOpen()
        {
            if (!IsOpen)
                throw new Exception("Connection not open.");
        }
        public string Hostname
        {
            get { return m_Hostname; }
        }
        public int ReadTimeout
        {
            set { m_ReadTimeout = value; if (IsOpen) m_Stream.ReadTimeout = value; }
            get { return m_ReadTimeout; }
        }
        public void Write(string str)
        {
            //FieldFox Programming Guide 6
            CheckOpen();
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            m_Stream.Write(bytes, 0, bytes.Length);
            m_Stream.Flush();
        }
        public void Write1(string str)
        {
            //FieldFox Programming Guide 6
            str = str + "\n";
            CheckOpen();
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            m_Stream.Write(bytes, 0, bytes.Length);
            m_Stream.Flush();
        }
        public void WriteLine(string str)
        {
            CheckOpen();
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            m_Stream.Write(bytes, 0, bytes.Length);
            WriteTerminator();
        }
        void WriteTerminator()
        {
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes("\r\n\0");
            m_Stream.Write(bytes, 0, bytes.Length);
            m_Stream.Flush();
        }
        public string Read()
        {
            CheckOpen();
            return System.Text.ASCIIEncoding.ASCII.GetString(ReadBytes());
        }

        /// <summary>
        /// Reads bytes from the socket and returns them as a byte[].
        /// </summary>
        /// <returns></returns>
        public byte[] ReadBytes()
        {
            int i = m_Stream.ReadByte();
            byte b = (byte)i;
            int bytesToRead = 0;
            var bytes = new List<byte>();
            if ((char)b == '#')
            {
                bytesToRead = ReadLengthHeader();
                if (bytesToRead > 0)
                {
                    i = m_Stream.ReadByte();
                    if ((char)i != '\n') // discard carriage return after length header.
                        bytes.Add((byte)i);
                }
            }
            if (bytesToRead == 0)
            {
                while (i != -1 && b != (byte)'\n')
                {
                    bytes.Add(b);
                    i = m_Stream.ReadByte();
                    b = (byte)i;
                }
            }
            else
            {
                int bytesRead = 0;
                while (bytesRead < bytesToRead && i != -1)
                {
                    i = m_Stream.ReadByte();
                    if (i != -1)
                    {
                        bytesRead++;
                        // record all bytes except \n if it is the last char.
                        if (bytesRead < bytesToRead || (char)i != '\n')
                            bytes.Add((byte)i);
                    }
                }
            }
            return bytes.ToArray();
        }

        int ReadLengthHeader()
        {
            int numDigits = Convert.ToInt32(new string(new char[] { (char)m_Stream.ReadByte() }));
            string bytes = "";
            for (int i = 0; i < numDigits; ++i)
                bytes = bytes + (char)m_Stream.ReadByte();

            return Convert.ToInt32(bytes);
        }


        public void Open(string hostname)
        {
            if (IsOpen)
                Close();
            m_Hostname = hostname;
            m_Client = new TcpClient(hostname, 5025);
            m_Stream = m_Client.GetStream();
            m_Stream.ReadTimeout = ReadTimeout;
            m_IsOpen = true;
            if (Opened != null)
                Opened();
        }
        public void Close()
        {
            if (!m_IsOpen)
                //FieldFox Programming Guide 7
                return;
            m_Stream.Close();
            m_Client.Close();
            m_IsOpen = false;
            if (Closed != null)
                Closed();
        }
        public void Dispose()
        {
            Close();
        }
    }
    #endregion

}
