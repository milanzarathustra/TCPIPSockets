/*
-------------------------------------------------
|   Created by Milan Conhye                     |
|   University of Greenwich                     |   
|                                               |
|   Website: www.milanconhye.com                |
|   GitHub: https://github.com/milanconhye      |
|                                               |
-------------------------------------------------

Copyright (c) 2016 Milan Conhye

* Permission to use, copy, modify, and distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

* The software is provided "as is" and the author disclaims all warranties with regard 
to this software including all implied warranties of merchantability and fitness. 
This software, does not encrypt the information sent across the network.
In no event shall the author be liable for any special, direct, indirect, or consequential 
damages or any damages whatsoever resulting from loss of use, data or profits, whether in an 
action of contract, negligence or other tortious action, arising out of or in connection with 
the use or performance of this software. Please acknowledge and agree to this agreement 
before using this software.

*/

using System;
using System.Text;
using System.Windows.Forms;

//Imports for Sockets Programming
using System.Net;
using System.Net.Sockets;

namespace TCPIPServer
{
    public partial class Server : Form
    {
        //Create TCP Listener
        TcpListener mTCPListener;

        //Create TCP Client
        TcpClient mTCPClient;

        //Create byte Array to store data
        byte[] mRx;

        public Server()
        {
            InitializeComponent();

            //Prevent the console output being selected as default. -Read Only
            tbConsoleOutput.TabStop = false;
        }

        //Find IP Address of computer
        IPAddress findMyIPV4Address()
        {
            //Define objects and make sure they are completely empty
            string strThisHostName = string.Empty;
            IPHostEntry thisHostDNSEntry = null;
            IPAddress[] allIPsOfThisHost = null;
            IPAddress ipv4Ret = null;

            try
            {
                //Get The host name of the system and store it in a string 
                strThisHostName = System.Net.Dns.GetHostName();
                //Print the host name on the console
                printLine("Host Name: " + strThisHostName);
                //Get the host entry from the domain name server ans store it in a IPHostEntry
                thisHostDNSEntry = System.Net.Dns.GetHostEntry(strThisHostName);
                //Get All IP Addressed and store it within the host entry object 
                allIPsOfThisHost = thisHostDNSEntry.AddressList;

                //Loop through all the Addresses and find the first IPV4 Address
                for(int idx = allIPsOfThisHost.Length - 1; idx > 0; idx--)
                {
                    //if an IPV4 address is found, return the address
                    if (allIPsOfThisHost[idx].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipv4Ret = allIPsOfThisHost[idx];
                        break;
                    }
                }

            } catch (Exception exc)
            {
                //If IP Address could not be found
                MessageBox.Show("Could not find your IPv4 Address, please manually enter and press Listen", "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Return with IPV4 Address
            return ipv4Ret;
        }

        //When Form Loads
        private void Form1_Load(object sender, EventArgs e)
        {
            //Create Object and store null value
            IPAddress Ipa = null;

            //Call Method and loop through the address
            Ipa = findMyIPV4Address();

            //If there is an IP address found, then print it out on the textbox
            if (Ipa != null)
            {
                tbIPAddress.Text = Ipa.ToString();
                //MessageBox.Show("IPv4 Address Detected...", "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Fix Close Button from looking like a normal button
            btnClose.TabStop = false;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
        }

        // Draggable window - Allows borderless window to be dragged.
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        //

        private void btnStartListening_Click(object sender, EventArgs e)
        {
            //Create Object IPAddress and an Integer for the port number
            IPAddress ipaddr;
            int nPort;

            //We check if the iPAddress and port number provided is valid.
            if (!int.TryParse(tbPort.Text, out nPort))
            {
                //Set Defaults
                nPort = 23000;
                tbPort.Text = Convert.ToString(nPort);
            }

            if (!IPAddress.TryParse(tbIPAddress.Text, out ipaddr))
            {
                //Warn Server
                MessageBox.Show("Invalid IPv4 address supplied.", "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            //We double check if we are still able to connect to the TCPListener
            try
            {
                //If all goes well then we will create a TcpListener parsing the ipaddress and port
                mTCPListener = new TcpListener(ipaddr, nPort);

                //Start the connection
                mTCPListener.Start();

                //We begin accepting connections from the client
                mTCPListener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, mTCPListener);

                //Enable and Disable functionality
                msgControls.Enabled = true;
                configurationGroup.Enabled = false;
                tbPayLoad.Select();

                printLine("Server is listening and waiting for client to connect...");

            } catch (Exception exc)
            {
                MessageBox.Show("Invalid IPv4 Or Local Host address supplied!", "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
            }

        }
        
        //A seperate method has been created in order to accept a call back
        void onCompleteAcceptTcpClient(IAsyncResult iar)
        {

            byte[] tx = new byte[512];

            //We convert the status of the iar to the casted TcpListener
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            try
            {    
                //We must call this within every AsyncCall so that the connection is accepted continuesly
                mTCPClient = tcpl.EndAcceptTcpClient(iar);

                //Get Todays date and time
                DateTime dateTime = DateTime.Now;

                tx = Encoding.ASCII.GetBytes("You are now connected to the server. You are listening to: " + tbIPAddress.Text +
                    ":" + tbPort.Text + ". \r\n" + "Chat started on: " + dateTime.ToString() + Environment.NewLine);
                printLine("\r\nChat started on: " + dateTime.ToString());
                mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);

                //While one client is connected, we can allow other clients to also connect
                tcpl.BeginAcceptTcpClient(onCompleteAcceptTcpClient, tcpl);

                //Set the default amount of bytes allowed
                mRx = new byte[512];
                mTCPClient.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, mTCPClient);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void onCompleteReadFromTCPClientStream(IAsyncResult iar)
        {
            //Open a TCPClient connection
            TcpClient tcpc;

            //Store nothing in the Read Bytes
            int nCountReadBytes = 0;

            //Data Recived
            string strRecv;

            try
            {
                //We sync the result to the tcpclient
                tcpc = (TcpClient) iar.AsyncState;

                //Calculate the ReadBytes and store in integer
                nCountReadBytes = tcpc.GetStream().EndRead(iar);
                
                //Here we will check if there is still packets going through.
                if (nCountReadBytes <= 0)
                {
                    printLine("Client has been disconnected. Idle for too long...");
                    printLine("__________________________");
                    return;
                }
                
                //We store all bites wich are read into a string
                strRecv = Encoding.ASCII.GetString(mRx, 0, nCountReadBytes);
                
                //We print out the string in the textbox
                printLine(strRecv);
                
                //We clear the buffer so clients can continously send packets
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, tcpc);

            }
            catch (Exception ex)
            {
                MessageBox.Show("A Client has Disconnected!", "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Server is still listening for incoming connections...", "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                printLine("__________________________");
            }
        }

        //When the PayLoad button is clicked.
        private void btnSend_Click(object sender, EventArgs e)
        {
            //A byte array would be used as a buffer to transmit data
            byte[] tx = new byte[512];

            //If the message box is empty
            if (string.IsNullOrEmpty(tbPayLoad.Text))
            {
                MessageBox.Show("There is nothing to send as your message box is empty!", "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                //We check if the tcp client is still connected to a remote peer or not
                if (mTCPClient != null)
                {
                    if (mTCPClient.Client.Connected) {

                        //We convert the textbox of payload into bytes
                        tx = Encoding.ASCII.GetBytes("Server" + DateTime.Now.ToString(" [h:mm:ss] ") + ": " + tbPayLoad.Text);
                        printLine("Server" + DateTime.Now.ToString(" [h:mm:ss] ") + ": " + tbPayLoad.Text);
                        tbPayLoad.Clear();
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);

                    }
                }

            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //When its been written to the client stream
        private void onCompleteWriteToClientStream(IAsyncResult iar)
        {
            //Here all we need to do is end the operation when the packets are sent
            try
            {
                TcpClient tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);

            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "TCP/IP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //When the about button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        //When the close button is clicked
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //When the logo is clicked 
        private void btnlogoabt_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        //A method has been created in order to print out the text in the appropriate area
        public void printLine(string _strPrint)
        {
            tbConsoleOutput.Invoke(new Action<string>(doInvoke), _strPrint);
        }

        public void doInvoke(string _strPrint)
        {
            tbConsoleOutput.Text = tbConsoleOutput.Text + _strPrint + Environment.NewLine;
        }
    }
}
