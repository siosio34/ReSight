using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ZedGraph;

using System.IO;

using System.IO.Ports;

namespace Resight_Program
{
    public partial class Form1 : Form
    {
        
        private SerialPort serialPort1 = new SerialPort();
        private SerialPort serialPort2 = new SerialPort();

        private delegate void TxtDelegate(TextBox txt,string sData);

        private void SetText(TextBox txt,string sData)
        {
            if (txt.InvokeRequired)
            {
                TxtDelegate temp = new TxtDelegate(SetText);
                txt.Invoke(temp,txt,sData);
            }

            else
            {
                txt.Text = sData;
            }              
        }
        
        int tickStart = 0;

        private byte[] Packet_Buffer_L = new byte[26];
        private int Packet_Index_L = 0;

        private byte[] Packet_Buffer_R = new byte[26];
        private int Packet_Index_R = 0;

        GraphPane[] Pressure_graph = new GraphPane[5];
        GraphPane[] Acc_graph = new GraphPane[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial_init();
            Pressure_init();
        }

        private void serial_init()
        {
            string[] Ports = SerialPort.GetPortNames();
            CB_Rport.Items.AddRange(Ports);
            CB_Lport.Items.AddRange(Ports);

            CB_Rbaud.Items.Add(9600);
            CB_Rbaud.Items.Add(115200);
            CB_Lbaud.Items.Add(9600);
            CB_Lbaud.Items.Add(115200);
        }

        private void BTN_Rcon_Click(object sender, EventArgs e)
        {
            if (BTN_Rcon.Text == "Connect")
            {
                if (serialPort1.IsOpen) serialPort1.Close();

                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

                if (CB_Rport.Text == "")
                {
                    MessageBox.Show("Select Port R");
                    return;
                }

                serialPort1.PortName = CB_Rport.Text;
                serialPort1.BaudRate = Convert.ToInt32(CB_Rbaud.Text);
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                try
                {
                    serialPort1.Open();
                    if (serialPort1.IsOpen) MessageBox.Show("Connected");
                    CB_Rport.Enabled = false;
                    CB_Rbaud.Enabled = false;
                    BTN_Start.Enabled = true;

                    BTN_Rcon.Text = "Disconnect";

                  
                }

                catch
                {
                    MessageBox.Show("Fail to Connect");
                }

               
            }

            else
            {
                Stop_Packet();

                if (serialPort1.IsOpen) serialPort1.Close();

                CB_Rport.Enabled = true;
                CB_Rbaud.Enabled = true;

                BTN_Rcon.Text = "Connect";
            }
        }

        private void BTN_Lcon_Click(object sender, EventArgs e)
        {
            if (BTN_Lcon.Text == "Connect")
            {
                if (serialPort2.IsOpen) serialPort2.Close();

                serialPort2.DataReceived += new SerialDataReceivedEventHandler(serialPort2_DataReceived);

                if (CB_Lport.Text == "")
                {
                    MessageBox.Show("Select Port L");
                    return;
                }

                serialPort2.PortName = CB_Lport.Text;
                serialPort2.BaudRate = Convert.ToInt32(CB_Lbaud.Text);
                serialPort2.DataBits = 8;
                serialPort2.StopBits = StopBits.One;
                serialPort2.Parity = Parity.None;

                try
                {
                    serialPort2.Open();
                    if (serialPort2.IsOpen)
                    {
                        MessageBox.Show("Connected");
                        BTN_Start.Enabled = true;

                        CB_Lport.Enabled = false;
                        CB_Lbaud.Enabled = false;

                        BTN_Lcon.Text = "Disconnect";
                        // 보드정보 가져오는 부분                   //all
                        //byte[] Packet = new byte[6] { 0xff, 0xff, 0x00, 0x11, 0xfe, 0xfe };

                        //serialPort2.Write(Packet, 0, 6);

                    }
                }

                catch
                {
                    MessageBox.Show("Fail to Connect");
                }


            }
            else
            {
                Stop_Packet();
                if (serialPort2.IsOpen) serialPort2.Close();

                CB_Lport.Enabled = true;
                CB_Lbaud.Enabled = true;

                BTN_Lcon.Text = "Connect";
            }
        }

        // 오른발 보드 
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int byteToRead = serialPort1.BytesToRead;

            if (byteToRead > 0)
            {
                byte[] Packet = new byte[byteToRead];
                int numberofBytesRead = serialPort1.Read(Packet, 0, Packet.Length);

                ParseReceivedData(Packet, numberofBytesRead, ref Packet_Buffer_R, ref Packet_Index_R);
            }
        }

        // 왼발 보드
        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int byteToRead = serialPort2.BytesToRead;

            if (byteToRead > 0)
            {
                byte[] Packet = new byte[byteToRead];
                int numberofBytesRead = serialPort2.Read(Packet, 0, Packet.Length);

                ParseReceivedData(Packet, numberofBytesRead, ref Packet_Buffer_L, ref Packet_Index_L);
            }
        }

        private void ParseReceivedData(byte[] rcvData, int numberOfBytesRead, ref byte[] Packet_Buffer, ref int Packet_Index)
        {
            byte buffer;

            for (int i = 0; i < numberOfBytesRead; i++)
            {
                buffer = rcvData[i];

                //stx1
                if (buffer == 0xff && Packet_Index == 0) Packet_Buffer[Packet_Index++] = buffer;

                //stx2
                else if (buffer == 0xff && Packet_Index == 1) Packet_Buffer[Packet_Index++] = buffer;

                //ID
                else if ((buffer == 0x02 && Packet_Index == 2) || (buffer == 0x01 && Packet_Index == 2)) Packet_Buffer[Packet_Index++] = buffer;

                //ext1
                else if (buffer == 0xfe && Packet_Index == 24) Packet_Buffer[Packet_Index++] = buffer;

                //etx2
                else if (buffer == 0xfe && Packet_Index == 25)
                {
                    Packet_Buffer[Packet_Index] = buffer;
                    Packet_Index = 0;

                    instruction_case(Packet_Buffer);
                }

                // 데이터 처리부분
                else
                {
                    // instrction
                    if (Packet_Index == 3) Packet_Buffer[Packet_Index++] = buffer;

                    else
                    {
                        if (Packet_Index > 3 && Packet_Index < 24)
                            Packet_Buffer[Packet_Index++] = buffer;
                    }
                }
            }

        }



        private void instruction_case(byte[] Buffer_Packet)
        {
            switch (Buffer_Packet[3])
            {
                //Pressure_Percen 10
                case 0x10:
                    UInt16[] Pressure_Per = new UInt16[10];
                    for (int i = 0; i < 10; i++) Pressure_Per[i] = Convert.ToUInt16(Buffer_Packet[i+4]);

                    string debug = Convert.ToString(Pressure_Per[0]) + ',';
                    for (int i = 1; i < 9; i++) debug += (Convert.ToString(Pressure_Per[i]) + ",");
                    debug += (Convert.ToString(Pressure_Per[9]));

                    //그래프 생성
                    if (Buffer_Packet[2] == 0x01)
                    {
                        SetText(TXT_Rpack, debug);
                        Draw_Pressure_Raw_R(Pressure_Per);


                    }
                    else if (Buffer_Packet[2] == 0x02)
                    {
                        SetText(TXT_Lpack, debug);
                        Draw_Pressure_Raw_L(Pressure_Per);
                    }
                    break;
                  
                //Pressure_Law 20
                case 0x11:
                    UInt16[] Pressure_Raw = new UInt16[10];
                    for (int i = 0; i < 10; i++) Pressure_Raw[i] = Convert.ToUInt16((Buffer_Packet[(2 * i) + 4] << 8) + Buffer_Packet[(2 * i + 1) + 4]);

                    string debug2 = Convert.ToString(Pressure_Raw[0]) + ',';
                    for (int i = 1; i < 9; i++) debug2 += (Convert.ToString(Pressure_Raw[i]) + ",");
                    debug2 += (Convert.ToString(Pressure_Raw[9]));

                    //그래프 생성
                    if (Buffer_Packet[2] == 0x01)
                    {
                        SetText(TXT_Rpack, debug2);
                        Draw_Pressure_Raw_R(Pressure_Raw);
                      

                    }
                    else if (Buffer_Packet[2] == 0x02)
                    {
                        SetText(TXT_Lpack, debug2);
                        Draw_Pressure_Raw_L(Pressure_Raw);
                    }
                    break;
                //Acc_Law 6
                case 0x12: //Draw_Acc(Packet);
                    break;
                //Walk_Step 2
                case 0x13:
                    break;
                //Center 2
                case 0x14:
                    break;
                //info
                case 0x20:
                    break;
                //State 1
                case 0x21:
                    break;
                //Battery 1
                case 0x22:
                    break;

                default: break;
            }

        }
        private void Pressure_init()
        {
            Pressure_graph[0] = Left_Top_graph.GraphPane;
            Pressure_graph[1] = Left_Bottom_graph.GraphPane;
            Pressure_graph[2] = Resight_6_graph.GraphPane;
            Pressure_graph[3] = Resight_4_graph.GraphPane;
            Pressure_graph[4] = Center_graph.GraphPane;

            Pressure_graph[0].Title.Text = "Left_Top";
            Pressure_graph[1].Title.Text = "Left_Bottom";
            Pressure_graph[2].Title.Text = "Resight_6";
            Pressure_graph[3].Title.Text = "Resight_4";
            Pressure_graph[4].Title.Text = "Center_Weight";

            RollingPointPairList[] Pressure_Left_list = new RollingPointPairList[10];
            RollingPointPairList[] Pressure_Right_list = new RollingPointPairList[10];
            RollingPointPairList Center_list = new RollingPointPairList(6000);

            for (int i = 0; i < 10; i++)
            {
                Pressure_Left_list[i] = new RollingPointPairList(6000);
                Pressure_Right_list[i] = new RollingPointPairList(6000);
            }

            //0:Left top   1:Left_bottom   2:Resight_6   3:Resight_4; 4:center
            LineItem[] Pressure_Curve = new LineItem[5];

            Color[] temp = new Color[6] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Yellow, Color.Purple };


            // Left Top initialize
            for (int i = 0; i < 6; i++)
            {
                Pressure_Curve[0] = Pressure_graph[0].AddCurve("Sensor" + Convert.ToString(i + 5), Pressure_Left_list[i + 4], temp[i], SymbolType.None);
                Pressure_Curve[0].Line.Width = 2;
                Pressure_Curve[0].Line.IsSmooth = true;
                Pressure_Curve[0].Line.SmoothTension = 0.5F;
                Pressure_Curve[0].Line.IsAntiAlias = true;
            }

            // Left Bottom initialize
            for (int i = 0; i < 4; i++)
            {
                Pressure_Curve[1] = Pressure_graph[1].AddCurve("Sensor" + Convert.ToString(i + 1), Pressure_Left_list[i], temp[i], SymbolType.None);
                Pressure_Curve[1].Line.Width = 2;
                Pressure_Curve[1].Line.IsSmooth = true;
                Pressure_Curve[1].Line.SmoothTension = 0.5F;
                Pressure_Curve[1].Line.IsAntiAlias = true;
            }

            // Right Top initialize
            for (int i = 0; i < 6; i++)
            {
                Pressure_Curve[2] = Pressure_graph[2].AddCurve("Sensor" + Convert.ToString(i + 5), Pressure_Right_list[i + 4], temp[i], SymbolType.None);
                Pressure_Curve[2].Line.Width = 2;
                Pressure_Curve[2].Line.IsSmooth = true;
                Pressure_Curve[2].Line.SmoothTension = 0.5F;
                Pressure_Curve[2].Line.IsAntiAlias = true;
            }

            // Right Bottom initialize
            for (int i = 0; i < 4; i++)
            {
                Pressure_Curve[3] = Pressure_graph[3].AddCurve("Sensor" + Convert.ToString(i + 1), Pressure_Right_list[i], temp[i], SymbolType.None);
                Pressure_Curve[3].Line.Width = 2;
                Pressure_Curve[3].Line.IsSmooth = true;
                Pressure_Curve[3].Line.SmoothTension = 0.5F;
                Pressure_Curve[3].Line.IsAntiAlias = true;
            }

            //center
            //Pressure_Curve[4] = Pressure_graph[4].add


            for (int i = 0; i < 5; i++)
            {
                Pressure_graph[i].XAxis.Title.Text = "X Axis - Sec";
                Pressure_graph[i].YAxis.Title.Text = "Y Axis - %";
                Pressure_graph[i].XAxis.Scale.Min = 0;
                Pressure_graph[i].XAxis.Scale.Max = 3;
                Pressure_graph[i].XAxis.Scale.MinorStep = 0.1;
                Pressure_graph[i].XAxis.Scale.MajorStep = 0.5;
                Pressure_graph[i].AxisChange();
            }

           // tickStart = Environment.TickCount;
        }

        private void Draw_Pressure_Raw_L(UInt16[] data)
        {
            if (Left_Top_graph.GraphPane.CurveList.Count <= 0)return;

            LineItem[] Curve_Left_Top = new LineItem[6];           
            LineItem[] Curve_Left_Bottom = new LineItem[4];

            IPointListEdit[] List_Left_Top = new IPointListEdit[6];
            IPointListEdit[] List_Left_Bottom = new IPointListEdit[4];

            double time = 0.0;

            // Time is measured in seconds
            time =(Environment.TickCount - tickStart) / 1000.0;

            for (int i = 0; i < 6; i++)
            {
                Curve_Left_Top[i] = Left_Top_graph.GraphPane.CurveList[i] as LineItem;
                if (Curve_Left_Top[i] == null) return;

                List_Left_Top[i] = Curve_Left_Top[i].Points as IPointListEdit;
                if (List_Left_Top[i] == null) return;

                List_Left_Top[i].Add(time, data[i + 4]);

               //List_Left_Top[i].Add(time, data[i+4]);
            }

            Scale xScale = Left_Top_graph.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 3.0;
            }

            Left_Top_graph.AxisChange();
            Left_Top_graph.Invalidate();

            for (int i = 0; i < 4; i++)
            {
                Curve_Left_Bottom[i] = Left_Bottom_graph.GraphPane.CurveList[i] as LineItem;
                if (Curve_Left_Bottom[i] == null) return;

                List_Left_Bottom[i] = Curve_Left_Bottom[i].Points as IPointListEdit;
                if (List_Left_Bottom[i] == null) return;

                List_Left_Bottom[i].Add(time, data[i]);
            }

            Save_L(data);

            Scale xScale2 = Left_Bottom_graph.GraphPane.XAxis.Scale;
            if (time > xScale2.Max - xScale2.MajorStep)
            {
                xScale2.Max = time + xScale2.MajorStep;
                xScale2.Min = xScale2.Max - 3.0;
            }

            Left_Bottom_graph.AxisChange();
            Left_Bottom_graph.Invalidate();

        }

        private void Draw_Pressure_Raw_R(UInt16[] data)
        {
            if (Resight_6_graph.GraphPane.CurveList.Count <= 0) return;

            LineItem[] Curve_Resight_6 = new LineItem[6];
            LineItem[] Curve_Resight_4 = new LineItem[4];

            IPointListEdit[] List_Resight_6 = new IPointListEdit[6];
            IPointListEdit[] List_Resight_4 = new IPointListEdit[4];

            double time = 0.0;

            // Time is measured in seconds
            time = (Environment.TickCount - tickStart) / 1000.0;

            for (int i = 0; i < 6; i++)
            {
                Curve_Resight_6[i] = Resight_6_graph.GraphPane.CurveList[i] as LineItem;
                if (Curve_Resight_6[i] == null) return;

                List_Resight_6[i] = Curve_Resight_6[i].Points as IPointListEdit;
                if (List_Resight_6[i] == null) return;

                List_Resight_6[i].Add(time, data[i + 4]);
            }

            Scale xScale = Resight_6_graph.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 3.0;
            }

            Resight_6_graph.AxisChange();
            Resight_6_graph.Invalidate();

            for (int i = 0; i < 4; i++)
            {
                Curve_Resight_4[i] = Resight_4_graph.GraphPane.CurveList[i] as LineItem;
                if (Curve_Resight_4[i] == null) return;

                List_Resight_4[i] = Curve_Resight_4[i].Points as IPointListEdit;
                if (List_Resight_4[i] == null) return;

                List_Resight_4[i].Add(time, data[i]);
            }

            Save_R(data);

            Scale xScale2 = Resight_4_graph.GraphPane.XAxis.Scale;
            if (time > xScale2.Max - xScale2.MajorStep)
            {
                xScale2.Max = time + xScale2.MajorStep;
                xScale2.Min = xScale2.Max - 3.0;
            }

            Resight_4_graph.AxisChange();
            Resight_4_graph.Invalidate();

        }

        private void Draw_Acc(byte[] data)
        {

        }

        private void TabPressure_Click(object sender, EventArgs e)
        {
            byte[] Packet = new byte[6] { 0xff, 0xff, 0x02, 0x10, 0xfe, 0xfe };

            serialPort1.Write(Packet, 0, 6);
        }

        private void TabAcc_Click(object sender, EventArgs e)
        {
            byte[] Packet = new byte[6] { 0xff, 0xff, 0x02, 0x12, 0xfe, 0xfe };

            serialPort1.Write(Packet, 0, 6);
        }

        private void Stop_Packet()
        {
            byte[] Packet = new byte[6] { 0xff, 0xff, 0x00, 0x30, 0xfe, 0xfe };

            if (serialPort1.IsOpen) serialPort1.Write(Packet, 0, 6);
            if (serialPort2.IsOpen) serialPort2.Write(Packet, 0, 6);
        }

        private void Start_Packet()
        {
            byte[] Packet = new byte[6] { 0xff, 0xff, 0x00, 0x10, 0xfe, 0xfe };

            if (serialPort1.IsOpen) serialPort1.Write(Packet, 0, 6);
            if (serialPort2.IsOpen) serialPort2.Write(Packet, 0, 6);
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            if (BTN_Start.Text == "START")
            {
                BTN_Start.Text = "STOP";
                tickStart = Environment.TickCount;

                Start_Packet();
            }

            else if (BTN_Start.Text == "STOP")
            {
                BTN_Start.Text = "START";
                Stop_Packet();

            }
            
        }

        //DateTime curTime = DateTime.Now;
        FileStream file_saveL = new FileStream("data_L.txt", FileMode.Create, FileAccess.ReadWrite);
        FileStream file_saveR = new FileStream("data_R.txt", FileMode.Create, FileAccess.ReadWrite);

        private void Save_L(UInt16[] data)
        {
            DateTime curTime = DateTime.Now;
            StreamWriter sWriter = new StreamWriter(file_saveL);

            try
            {
                sWriter.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", curTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt"), data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9]);
                sWriter.Flush();
            }
            catch
            {
                /* ignore error */
            }
        }

        private void Save_R(UInt16[] data)
        {
            DateTime curTime = DateTime.Now;
            StreamWriter sWriter = new StreamWriter(file_saveR);

            try
            {
                sWriter.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", curTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt"), data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9]);
                sWriter.Flush();
            }
            catch
            {
                /* ignore error */
            }
        }

        private void TXT_Lver_TextChanged(object sender, EventArgs e)
        {

        }

        private void Resight_6_graph_Load(object sender, EventArgs e)
        {

        }

        private void Resight_4_graph_Load(object sender, EventArgs e)
        {

        }
    }
}
