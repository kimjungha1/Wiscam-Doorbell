using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Management;
using RAK420_Config_Tool;
using CodeProject.Dialog;
using System.Configuration;

namespace Wiscam
{
    public partial class Form1 : Form
    {
        //WIFI scan and configuration variables
        UdpClient myUdpclient = null;
        TcpClient mytcpclient = null;
        NetworkStream mytcpclientStream = null;
        string scancmd = "@LT_WIFI_DEVICE@";
        string scancmd_ack = "@LT_WIFI_CONFIRM@";
        byte[] scanbytes = { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0x2a, 0 };
        byte[] uartbytes = new byte[7];
        byte Source = 0x00; //0 :Represents the current command from the computer or APP etc  1：Represents the current command from the IFTTT   2：Represents the current command from the Alexa Skill 
        byte Set_Get = 0x01; // 1-set device related parameters  2-get device related parameters
        byte BoxID = 0x00; //Used to distinguish between different command content, in order to increase in order
        byte Status = 0x01;//0：Invalid or ignored，No resolution is required as a send command  1：Success   2：Error
        byte DataLength = 0x07; //Used to represent the length of the transmit / receive data, the length of the parameter is 2Byte, the 16 hexadecimal representation, the high 8 bit in front, and the lower 8 bits in the back
        int searchdesport = 5570;
        int searchsrcport = 55556;
        int DC_value = 0;
        //int uartport = 0x50;
        int uartport = 502;
        private Thread UDPThread = null;
        private Thread TCPThread = null;
        private bool isConnection=false;
        int selecteds = 0;
        IPEndPoint myUDPCIpe = null;
        private Thread UDPThread_LTSP = null;
        bool myUdpclientOPEN = false;
        bool UDPThread_LTSP_Enable = false;
        private int line_count = 0;
        private byte timerretry_count = 0;
        string[] Module_MAC_List = new string[100];//Declares a temporary array to store the current list of MAC addresses
        bool Search_Timeout = false;//Scan timeout mark
        RAK420 RAK420_INFO = new RAK420();//Declare the RAK420_INFO information structure in the RAK420 class
        byte[] empty = new byte[0];//Defines an empty byte array

        byte[] receiveStr;
        byte[] KeyName = new byte[100];//keyword
        byte[] Val = new byte[100];//Configuring data information
        bool reset_time = false;//Determine whether the reset has been successful
        bool facreset_time = false;//Determine whether to receive recovery factory settings successfully
        public bool IsConnection = false;
        private bool ch_en = false;//False stands for Chinese; true stands for English
        string BoardCastIP = "";
        FileStream file_bin = null;
        string Post_ip = "POST /update_success.html HTTP/1.1\r\nHost: ";
        string Post_length = "\r\nConnection: Keep-Alive\r\nContent-Length: ";
        string Post_admin = "\r\nAuthorization: Basic ";
        string Post_end = "\r\n-----------------------------7de19a322d0eee\r\nContent-Disposition: form-data; name=\"files\"; filename=\"RAK415.bin\"";
        private Thread Thread_TCP = null;

        TcpClient Tcp_socket = null;
        NetworkStream Tcp_stream = null;

        TcpClient Tcp_socket1 = null;
        NetworkStream Tcp_stream1 = null;

        TcpClient Tcp_socket2 = null;
        NetworkStream Tcp_stream2 = null;

        TcpClient Tcp_socket3 = null;
        NetworkStream Tcp_stream3 = null;

        TcpClient Tcp_socket4 = null;
        NetworkStream Tcp_stream4 = null;

        TcpClient Tcp_socket5 = null;
        NetworkStream Tcp_stream5 = null;

        TcpClient Tcp_socket6 = null;
        NetworkStream Tcp_stream6 = null;

        TcpClient Tcp_socket7 = null;
        NetworkStream Tcp_stream7 = null;

        TcpClient Tcp_socket8 = null;
        NetworkStream Tcp_stream8 = null;

        TcpClient Tcp_socket9 = null;
        NetworkStream Tcp_stream9 = null;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer4 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer5 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer6 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer7 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer8 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer9 = new System.Windows.Forms.Timer();

        System.Windows.Forms.Timer timerout = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerload = new System.Windows.Forms.Timer();
         public Form1()
        {
            InitializeComponent();
            vlc_init(false);
        }

         /***************************************************************************************************************
          ** Function Description: query the subnet mask and gateway address, calculate the broadcast address and return
          ***************************************************************************************************************/
         public string GetSubnetAndGateway()
        {
            string strIP, strSubnet, strGateway, strDNS;
            strIP = "0.0.0.0";
            strSubnet = "0.0.0.0";
            strGateway = "0.0.0.0";
            strDNS = "0.0.0.0";
            BoardCastIP = "";
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection nics = mc.GetInstances();
                foreach (ManagementObject nic in nics)
                {
                    try
                    {
                        if (Convert.ToBoolean(nic["IPEnabled"]) == true)
                        {

                            if ((nic["IPAddress"] as String[]).Length > 0 && strIP == "0.0.0.0")
                            {
                                strIP = (nic["IPAddress"] as String[])[0];
                            }
                            if ((nic["IPSubnet"] as String[]).Length > 0 && strSubnet == "0.0.0.0")
                            {
                                strSubnet = (nic["IPSubnet"] as String[])[0];
                            }
                            if ((nic["DefaultIPGateway"] as String[]).Length > 0 && strGateway == "0.0.0.0")
                            {
                                strGateway = (nic["DefaultIPGateway"] as String[])[0];
                            }
                            if ((nic["DNSServerSearchOrder"] as String[]).Length > 0 && strDNS == "0.0.0.0")
                            {
                                strDNS = (nic["DNSServerSearchOrder"] as String[])[0];
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
            string[] Subnet = strSubnet.Split(new Char[] { '.' });
            string[] GateWay = strGateway.Split(new Char[] { '.' });
            if (GateWay[0] + GateWay[1] + GateWay[2] + GateWay[3] == "0000")
            {
                BoardCastIP = "255.255.255.255";
                return BoardCastIP;
            }
            if ((Subnet.Length != 4) || (GateWay).Length != 4)
            {
                return BoardCastIP;
            }
            int x1 = (~(Convert.ToByte(Subnet[0])) | (Convert.ToByte(GateWay[0]))) & 0x000000FF;
            int x2 = (~(Convert.ToByte(Subnet[1])) | (Convert.ToByte(GateWay[1]))) & 0x000000FF;
            int x3 = (~(Convert.ToByte(Subnet[2])) | (Convert.ToByte(GateWay[2]))) & 0x000000FF;
            int x4 = (~(Convert.ToByte(Subnet[3])) | (Convert.ToByte(GateWay[3]))) & 0x000000FF;
            BoardCastIP = x1.ToString() + "." + x2.ToString() + "." + x3.ToString() + "." + x4.ToString();
            //return "IP address" + strIP + "\n" + "Subnet mask " + strSubnet + "\n" + "Default gateway " + strGateway + "\n" + "DNS server " + strDNS;
            return BoardCastIP;
        }



         /*********************************************************************************************************
          ** Function Description: query the native IP address
          ********************************************************************************************************/
         int errorcode = 0; //Errorcode is defined as returning the actual error value. If not 0 represents an error, and if 0 it means no error
        System.Net.IPAddress GetHost_IPAddresses()   
        {
            System.Net.IPAddress[] addressListUDP = Dns.GetHostAddresses(Dns.GetHostName());//All addresses will be returned, including IPv4 and IPv6
            System.Net.IPAddress[] AddressList_IP = { null, null, null, null, null, null, null, null, null, null };//Will return, IPv4 address
            int n = 0;
#if  DEBUG
            Console.Write("IP(IPV4&IPV6):" + addressListUDP.Length.ToString() + "\r\n");
            for (int i = 0; i < addressListUDP.Length; i++)
            {
                Console.Write(i.ToString() + "-->AddressFamily:" + addressListUDP[i].AddressFamily + "\r\n");
                Console.Write("IP Address:" + addressListUDP[i].ToString() + "\r\n");

            }
#endif
            for (int i = 0; i < addressListUDP.Length; i++)
            {

                //Filter out the IP address of the IPv4 type from the IP address list
                //AddressFamily.InterNetwork Indicates that this IP is IPv4,
                //AddressFamily.InterNetworkV6 Indicates that this IP is IPv6,
                if (addressListUDP[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    AddressList_IP[n] = addressListUDP[i];
                    n++;
                }
            }
#if  DEBUG
            Console.Write("IP Count:" + n.ToString() + "\r\n");
#endif
            if (n > 0)
            {
                errorcode = 0;
                // ipAddrUDP = AddressList_IP[1];
                return AddressList_IP[n - 1];

            }
            else
            {
                errorcode = -1;
                return null;
            }
        }

        int search_count = 0;//Scan times
        /*********************************************************************************************************
         ** Function Description: send scan command
         ********************************************************************************************************/
        void send_search_cmd()
        {
           
            BoardCastIP = GetSubnetAndGateway();
            if (BoardCastIP == "")
                return;
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(BoardCastIP), searchdesport);


            //byte[] bytes = ASCIIEncoding.ASCII.GetBytes(scancmd);
            myUdpclient.Send(scanbytes, scanbytes.Length, iep);//Send scan information
        }


        /*********************************************************************************************************
         ** Function Description:Scan module
         ********************************************************************************************************/
        bool search = false;//Is it in the search process?
        private void buttonScan_Click(object sender, System.EventArgs e)
        {

            try
            {
                search = true;
                search_count = 0;
                buttonScan.Enabled = false;
                dataGVscan.Enabled = false;
                dataGVscan.Rows.Clear();//clear list
                Search_Timeout = false;//Clear scan timeout

                for (int m = 0; m < line_count; m++)//Empty the MAC string array
                {
                    Module_MAC_List[m] = null;
                }
                line_count = 0;//List row count cleared

                if (myUdpclientOPEN == true)//open the unicast receive thread
                {
                    UDPThread_LTSP.Abort();//Close the unicast receive thread                    
                }

               if (myUdpclient == null)
                    myUdpclient = new UdpClient(searchsrcport);
               send_search_cmd();//Send scan information
                search_count++;
                UDPThread = new Thread(new ThreadStart(Search_Thread));
                UDPThread.IsBackground = true;//Automatically closes the thread when the window is closed
                timersearch.Start();
                UDPThread.Start();
               
                
            }
            catch (ArgumentNullException ae)
            {
                //Display exception information to clients.
                MessageBox.Show(ae.Message);
            }
        }

        /*********************************************************************************************************
         ** Function Description: scan thread
         ********************************************************************************************************/
        void Search_Thread()
        {
            IPEndPoint ipe = new IPEndPoint(GetHost_IPAddresses(), searchsrcport);

            if (errorcode != 0)
            {
                if (ch_en)
                    MsgBox.Show("Please check network connecting.");
                else
                    MsgBox.Show("Please verify that the network is connected");
                return;
            }
            errorcode = 0;
            while (true)
            {
                if ((myUdpclient != null) && (Search_Timeout == false))
                {
                    if (myUdpclient.Available > 0)
                    {
                        byte[] bytes = myUdpclient.Receive(ref ipe);//Receive scanned data
                        if (bytes != null)
                        {
                            this.Invoke((EventHandler)(delegate
                            {
                                bool MAC_NEW = true;
                                if ((bytes.Length > 43) && (bytes[1] == 0x80) && (bytes[3] == 0x01))
                                {
                                    string Module_MAC_List_temp = null;
                                    if (bytes[18] == 0x01)
                                    {
                                        int index = 19;
                                        for (index = 19; index < bytes.Length; index++)
                                        {
                                            if (bytes[index] == 0)
                                            {
                                                break;
                                            }
                                        }
                                        Module_MAC_List_temp = ASCIIEncoding.ASCII.GetString(bytes, 19, index - 19);
                                    }

                                    //Determine whether the MAC address is the same  
                                    for (int m = 0; m < line_count; m++)
                                    {
                                        if (Module_MAC_List_temp == Module_MAC_List[m])
                                        {
                                            MAC_NEW = false;//If the same indicates that the new MAC is not new, there is no need to add a list of new rows
                                            break;
                                        }
                                    }
                                    if (MAC_NEW == true)//If not the same, the representation is new MAC and needs to be added to a list of rows
                                    {
                                        //The MAC that records the list of new rows
                                        Module_MAC_List[line_count] = Module_MAC_List_temp;

                                        //Add a list of rows
                                        if ((line_count >= 0))
                                        {
                                            dataGVscan.Rows.Add();
                                        }
                                        string ipstring = ipe.Address.ToString();

                                        //Fill list
                                        this.dataGVscan.Rows[line_count].Cells[0].Value = line_count + 1;//Serial number
                                        this.dataGVscan.Rows[line_count].Cells[1].Value = ipstring;//IP address
                                        this.dataGVscan.Rows[line_count].Cells[2].Value = Module_MAC_List_temp;//MAC address
                                        this.dataGVscan.Rows[line_count].Cells[4].Value = "Choose then Apply";
                                        line_count++;//next row
                                    }
                                }
                            }));
                        }
                    }
                }
            }
        }

        /*********************************************************************************************************
        ** Function Description: determines if the scan is out of time
        ********************************************************************************************************/
        int ver_num = 0;
        private void timersearch_Tick(object sender, EventArgs e)
        {
            if (search_count < 5)
                send_search_cmd();//Send scan information            
            if (search_count >= 7)
            {
                timersearch.Stop();
                search = false;
                myUdpclientOPEN = false;
                Search_Timeout = true;
                UDPThread.Abort();
                this.Invoke((EventHandler)(delegate
                {
                    buttonScan.Enabled = true;
                    dataGVscan.Enabled = true;
                }));
                string admin_data = "user_name=" + textBoxadmin.Text + "&user_password=" + textBoxpsk.Text;//Entire authentication information - string
                byte[] admin = new byte[admin_data.Length];
                ver_num = 0;
                admin = ASCIIEncoding.ASCII.GetBytes(admin_data); //Whole authentication information -- byte array
                string param = "<request><param1></param1></request>";
                string method = "GET";
                byte[] barray = Encoding.Default.GetBytes(textBoxadmin.Text + ":" + textBoxpsk.Text);
                basic = "Authorization: Basic " + Convert.ToBase64String(barray);
                Action<HttpStatusCode, string> onComplete = null;
                for (int i = 0; i < dataGVscan.RowCount; i++)
                {
                    if (dataGVscan.Rows[i].Cells[1].Value != null)
                    {
                        string ip = dataGVscan.Rows[i].Cells[1].Value.ToString();//Get target IP address
                       
                        confirm = true;
                       
                    }
                }
            }
            search_count++;
        }


        /*********************************************************************************************************
        ** Function Description: XOR function and XOR check function
        ********************************************************************************************************/
        private byte Xor_Sum(byte[] Xor_SumArray, int Xor_SumLen)
        {
            int xor_sum = 0;
            int i = 0;
            for (i = 0; i < Xor_SumLen - 1; i++)
            {
                xor_sum ^= Xor_SumArray[i];
            }
            return ((byte)xor_sum);
        }
        //The XOR generation function specifies the location to start the checksum
        private byte Xor_Sum_start(byte[] Xor_SumArray, byte Xor_SumLen,byte start)
        {
            byte xor_sum = 0;
            byte i = 0;
            for (i = start; i < Xor_SumLen ; i++)
            {
                xor_sum ^= Xor_SumArray[i];
            }
            return ((byte)xor_sum);
        }

        //XOR check function
        private bool Xor(byte[] XorArray, int XorLen)
        {
            bool xor_successful = false;
            int xor_sum = 0;
            try
            {
                for (int i = 0; i < XorLen - 1; i++)
                {
                    xor_sum ^= XorArray[i];
                }
                if (xor_sum == XorArray[XorLen - 1]) //XOR success
                    xor_successful = true;
                else                             //XOR failure
                    xor_successful = false;
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                xor_successful = false;
            }
            return xor_successful;//Returns verification results
        }
        /*********************************************************************************************************
        ** Function Description: unicast interacts with modules for data
        ********************************************************************************************************/
        public void LTSP_CMD(byte CMD, byte[] data, IPAddress Destip)
        {
            byte[] sendata = new byte[6 + data.Length + 1];
            //Initialization command
            sendata[0] = CMD;
            sendata[1] = 0x00;
            //data length
            sendata[2] = (byte)(data.Length & 0xFF);
            sendata[3] = (byte)((data.Length >> 8) & 0xFF);
            //Response code
            sendata[4] = 0x00;
            sendata[5] = 0x00;
            //Data content
            for (int i = 0; i < data.Length; i++)
            {
                sendata[6 + i] = data[i];
            }
            //Checkout
            sendata[6 + data.Length] = Xor_Sum(sendata, sendata.Length);
            //if (myUdpclient == null)
            //    myUdpclient = new UdpClient(searchsrcport);
            myUDPCIpe = new IPEndPoint(Destip, searchdesport);
            myUdpclient.Send(sendata, sendata.Length, myUDPCIpe);

            UDPThread_LTSP = new Thread(new ThreadStart(LTSPCMD_Thread));//UDP unicast receive data thread
            UDPThread_LTSP.IsBackground = true;

            if (myUdpclientOPEN == false)//close unicast receive thread
            {
                UDPThread_LTSP.Start();//Open unicast receive thread
                myUdpclientOPEN = true;
            }
        }
        /*********************************************************************************************************
       ** Function Description: UDP unicast receives data thread
       *********************************************************************************************************/
        bool confirm = false;
        bool getversion = false;
        void LTSPCMD_Thread()
        {
            IPEndPoint ipe = new IPEndPoint(GetHost_IPAddresses(), searchsrcport);
            if (errorcode != 0)
            {
                if (ch_en)
                    MsgBox.Show("Please check network connecting.");
                else
                    MsgBox.Show("Please verify that the network is connected");
                return;
            }
            errorcode = 0;
            while (search == false)//Non scanning process
            {
                if (myUdpclient != null)
                {
                    if (myUdpclient.Available > 0)
                    {
                        byte[] buf = myUdpclient.Receive(ref ipe);
                        if (buf != null)
                        {
                            this.Invoke((EventHandler)(delegate
                            {
                                if (Xor(buf, buf.Length) == true)//Receive data check successful
                                {
                                    if (buf[0] == 0xF)//The authentication reply received by the module: authentication successful
                                    {
                                        confirm = false;
                                        timerout.Enabled = false;//Start clocking                                     
                                        if (buf[4] == 0xFE)//Module authentication failed
                                        {
                                            this.dataGVscan.Rows[ver_num].Cells[6].Value = "Authentication failed";
                                            ver_num++;
                                            if (ver_num < this.dataGVscan.RowCount - 1)
                                            {
                                                string admin_data = "user_name=" + textBoxadmin.Text + "&user_password=" + textBoxpsk.Text;//Entire authentication information - string
                                                byte[] admin = new byte[admin_data.Length];
                                                admin = ASCIIEncoding.ASCII.GetBytes(admin_data); //Whole authentication information -- byte array
                                                string ip = dataGVscan.Rows[ver_num].Cells[3].Value.ToString();//Get target IP address
                                                LTSP_CMD(0xF, admin, IPAddress.Parse(ip)); //Send authentication information 
                                                confirm = true;
                                                timerout.Enabled = true;//Start clocking
                                            }
                                        }
                                        else
                                        {
                                            if (this.dataGVscan.Rows[ver_num].Cells[3].Value.ToString() != null)
                                            {
                                                LTSP_CMD(0x06, empty, IPAddress.Parse(this.dataGVscan.Rows[ver_num].Cells[3].Value.ToString())); //Get module version number
                                                getversion = true;
                                                timerout.Enabled = true;//Start clocking
                                            }
                                        }
                                    }
                                    if (buf[0] == 0x06)//Gets version information to the module
                                    {
                                        getversion = false;
                                        timerout.Enabled = false;//Start clocking
                                        byte[] version = new byte[buf[3] * 256 + buf[2] - 15];//Version number data length
                                        for (int i = 0; i < version.Length; i++)
                                        {
                                            version[i] = buf[21 + i];//Get version number data
                                        }
                                        this.dataGVscan.Rows[ver_num].Cells[6].Value = System.Text.Encoding.ASCII.GetString(version);//Version number is shown in TextBox
                                        ver_num++;
                                        if (ver_num < this.dataGVscan.RowCount - 1)
                                        {
                                            string admin_data = "user_name=" + textBoxadmin.Text + "&user_password=" + textBoxpsk.Text;//Entire authentication information - string
                                            byte[] admin = new byte[admin_data.Length];
                                            admin = ASCIIEncoding.ASCII.GetBytes(admin_data); //Whole authentication information -- byte array
                                            string ip = dataGVscan.Rows[ver_num].Cells[3].Value.ToString();//Get target IP address
                                            LTSP_CMD(0xF, admin, IPAddress.Parse(ip)); //Send authentication information
                                            confirm = true;
                                            timerout.Enabled = true;//Start clocking
                                        }
                                    }
                                }

                            }));
                        }
                    }
                }
            }
        }


        bool Is_Over(bool enable_count, int c)
        {
            bool ret = false;
            if (enable_count == false)
            {
                ret = true;
            }
            else if (enable_count && (c == 0))
            {
                ret = true;
            }
            return ret;
        }

        /*****************************************************************************************************
         **Establishing TCP connection communication
         ****************************************************************************************************/
        string basic = "";
        void tcp_connect()
        {

            string admin_data = "user_name=" + textBoxadmin.Text + "&user_password=" + textBoxpsk.Text;//Entire authentication information - string
            byte[] admin = new byte[admin_data.Length];
            //ver_num = 0;
            admin = ASCIIEncoding.ASCII.GetBytes(admin_data); //Whole authentication information -- byte array
            string param = "<request><param1></param1></request>";
            string method = "GET";
            byte[] barray = Encoding.Default.GetBytes(textBoxadmin.Text + ":" + textBoxpsk.Text);
            basic = "Authorization: Basic " + Convert.ToBase64String(barray);
            Action<HttpStatusCode, string> onComplete = null;
            // bool is_choose = false;
            for (int i = 0; i < dataGVscan.RowCount; i++)
            {

                if ((this.dataGVscan.Rows[i].Cells[5].EditedFormattedValue.ToString() == "True"))
                {
                    //is_choose = true;
                    //butn.Enabled = true;
                    if (dataGVscan.Rows[i].Cells[1].Value != null)
                    {
                        string ip = dataGVscan.Rows[i].Cells[1].Value.ToString();//Get target IP address
                        //string ip = "192.168.100.107";//调试IP地址

                        if ((mytcpclient == null) || (IsConnection == false))
                        {
                            mytcpclient = new TcpClient();
                            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), uartport);
                            mytcpclient.Connect(serverEndPoint);
                            //mytcpclientStream = mytcpclient.GetStream();
                        }

                    }


                }
            }
          
        }

        /***************************************************************************
         ** open request
         ****************************************************************************/
        private void open_Click(object sender, EventArgs e)
        {
             DC_value = 160;
             try
             {
                 //mytcpclient = new TcpClient();
                 if (mytcpclient != null)
                 {
                     mytcpclient.Close();
                 }
                 //Thread.Sleep(10);
                 tcp_connect();
                 send_urat_cmd();//Send serial information
             }
            catch
            {

                // MsgBox.Show("send succeed！");
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            DC_value = 0;
            try
            {
                //mytcpclient = new TcpClient();
                if (mytcpclient != null)
                {
                    mytcpclient.Close();
                }
                //Thread.Sleep(10);
                tcp_connect();
                send_urat_cmd();//Send serial information
            }
            catch
            {

                // MsgBox.Show("send succeed！");
            }
        }

        private void Received_Click(object sender, EventArgs e)
        {
             try
             {
                 //mytcpclient = new TcpClient();
                 if (mytcpclient != null)
                 {
                     mytcpclient.Close();
                 }
                 //Thread.Sleep(10);
                 tcp_connect();
                 Thread TCPThread = new Thread(Thread_TCP_Receive); ;//Send serial information
                 TCPThread.IsBackground = true;
                 TCPThread.Start();
             }
            catch
            {

                // MsgBox.Show("send succeed！");
            }
        }

        /*******************************************************************************************************
         ** Function Description: send UART serial command
        ********************************************************************************************************/
        void send_urat_cmd()
        {
            try
            {
               
                uartbytes[0] = Source;
                uartbytes[1] = Set_Get;
                uartbytes[2] = BoxID;
                uartbytes[3] = Status;
                uartbytes[4] = 0x01;
                uartbytes[5] = (byte)DC_value;
                uartbytes[6] = Xor_Sum_start(uartbytes, (byte)(uartbytes[4] + 5), 0);
                mytcpclientStream = mytcpclient.GetStream();
                mytcpclientStream.Write(uartbytes, 0, uartbytes.Length);//Send serial command
               
            }
            catch
            {
                IsConnection = false;
                //mytcpclient.Close();
                MsgBox.Show("TCP No Connection！");
            }
         
        }
       

        /*********************************************************************************************************
        **Function Description: tcp unicast receives data thread
        *********************************************************************************************************/
        void Thread_TCP_Receive()
        {
            byte[] readBuffer = new byte[10];
            //byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    mytcpclientStream = mytcpclient.GetStream();
                    mytcpclientStream.Read(readBuffer, 0, readBuffer.Length);
                    //textrec.Text = readBuffer.ToString();
                    string strRec = Encoding.Default.GetString(readBuffer, 0, readBuffer.Length);
                    this.Invoke((EventHandler)(delegate
                    {
                        //textrec.Text = strRec + "\r\n";
                        textrec.AppendText(strRec);
                        if (textrec.Text == "2356")
                        {
                           display_wiscam();
                        }
                    }));
                    
                }
                catch
                {
                  
                }
            }
        }
        private void dataGVscan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGVscan.CurrentRow.Cells[5].EditedFormattedValue.ToString() == "True")
            {
                this.dataGVscan.CurrentRow.Cells[5].Value = false;
            }
            else
            {
                for (int i = 0; i < this.dataGVscan.RowCount; i++)
                {
                    this.dataGVscan.Rows[i].Cells[5].Value = false;
                }
                this.dataGVscan.CurrentRow.Cells[5].Value = true;
                // tcp_connect();

            }
        }
        /*****************************************************************
         **Specified play
         *****************************************************************/
        private VlcPlayer vlc_player_1;
        //private VlcPlayer vlc_player_2;
        private bool is_playinig_1;
        //private bool is_playinig_2;

        public void vlc_init(bool is_record)
        {
            string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
            vlc_player_1 = new VlcPlayer(pluginPath, is_record);
            //vlc_player_2 = new VlcPlayer(pluginPath, is_record);
            IntPtr render_wnd1 = this.panel1.Handle; //this.panel1.Handle;
            vlc_player_1.SetRenderWindow((int)render_wnd1);
            is_playinig_1 = false;
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                vlc_player_1.PlayFile(ofd.FileName);
                is_playinig_1 = true;
            }
            /*if (ofd.ShowDialog() == DialogResult.OK)
            {
                vlc_player_2.PlayFile(ofd.FileName);
                is_playinig_2 = true;
            }*/
        }
        /********************************************************
         ********Close the play window
         *******************************************************/
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (is_playinig_1)
            {
                vlc_player_1.Stop();
                is_playinig_1 = false;
            }
        }

        void display_wiscam()
        {
            string admin_data = "user_name=" + textBoxadmin.Text + "&user_password=" + textBoxpsk.Text;
            byte[] admin = new byte[admin_data.Length];
            //ver_num = 0;
            admin = ASCIIEncoding.ASCII.GetBytes(admin_data);
            string param = "<request><param1></param1></request>";
            string method = "GET";
            byte[] barray = Encoding.Default.GetBytes(textBoxadmin.Text + ":" + textBoxpsk.Text);
            basic = "Authorization: Basic " + Convert.ToBase64String(barray);
            Action<HttpStatusCode, string> onComplete = null;
            for (int i = 0; i < dataGVscan.RowCount; i++)
            {
                if (dataGVscan.Rows[i].Cells[1].Value != null)
                {
                    string ip = dataGVscan.Rows[i].Cells[1].Value.ToString();
                    string rtsp1 = "rtsp://admin:admin@" + ip + "/cam1/mpeg4";
                    textBox1.Text = rtsp1;
                    vlc_player_1.PlayFile_rtsp(rtsp1);
                    is_playinig_1 = true;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string admin_data = "user_name=" + textBoxadmin.Text + "&user_password=" + textBoxpsk.Text;
            byte[] admin = new byte[admin_data.Length];
            //ver_num = 0;
            admin = ASCIIEncoding.ASCII.GetBytes(admin_data); 
            string param = "<request><param1></param1></request>";
            string method = "GET";
            byte[] barray = Encoding.Default.GetBytes(textBoxadmin.Text + ":" + textBoxpsk.Text);
            basic = "Authorization: Basic " + Convert.ToBase64String(barray);
            Action<HttpStatusCode, string> onComplete = null;
            for (int i = 0; i < dataGVscan.RowCount; i++)
            {
                if (dataGVscan.Rows[i].Cells[1].Value != null)
                {
                    string ip = dataGVscan.Rows[i].Cells[1].Value.ToString();
                    string rtsp1 = "rtsp://admin:admin@" + ip + "/cam1/mpeg4";
                    textBox1.Text = rtsp1;
                    vlc_player_1.PlayFile_rtsp(rtsp1);
                    is_playinig_1 = true;
                }
            }
            
           //string rtsp1 = textBox1.Text;//"rtsp://admin:admin@192.168.1.116/cam1/h264 :network-caching=450";// "rtsp://192.168.0.45/ip7";//"rtsp://192.168.0.45/ip7";//  :network-caching=3000
            //vlc_player_1.PlayFile_rtsp(rtsp1);
            //is_playinig_1 = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (is_playinig_1 == true)
            vlc_player_1.Stop();
            vlc_player_1.Vlc_release();
           
        
        }
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse double click");
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            string admin_data = "user_name=" + textBoxadmin.Text + "&user_password=" + textBoxpsk.Text;
                byte[] admin = new byte[admin_data.Length];
                //ver_num = 0;
                admin = ASCIIEncoding.ASCII.GetBytes(admin_data); 
                string param = "<request><param1></param1></request>";
                string method = "GET";
                byte[] barray = Encoding.Default.GetBytes(textBoxadmin.Text + ":" + textBoxpsk.Text);
                basic = "Authorization: Basic " + Convert.ToBase64String(barray);
                Action<HttpStatusCode, string> onComplete = null;
                for (int i = 0; i < dataGVscan.RowCount; i++)
                {
                    if (dataGVscan.Rows[i].Cells[1].Value != null)
                    {
                        string ip = dataGVscan.Rows[i].Cells[1].Value.ToString();//Get target IP address
                        string url0 = ip + "/restart.cgi";
                        string rcv0= HTTP.Request(method, url0, basic, param, onComplete);
                    }
                }
        } 
       
    }
}
