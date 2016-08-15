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

namespace TCPIPClient
{
    public partial class Client : Form
    {

        //Create TCP Client
        TcpClient mTcpClient;

        //Create byte Array to store data
        byte[] mRx;

        //Name in ChatBox
        static string strName;

        //When connected, prevent from editing ip address port and name
        bool isAvailableToWrite = true;

        public Client()
        {
            InitializeComponent();

            //Fix Close Button from looking like a normal button
            btnClose.TabStop = false;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;

            //Fix Console window from being clicked on first
            tbConsole.TabStop = false;
            tbName.TabIndex = 1;
        }

        private void Client_Load(object sender, EventArgs e){ }

        //Get Clients IP Address
        IPAddress findmMyIPV4Address()
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
                //Get the host entry from the domain name server ans store it in a IPHostEntry
                thisHostDNSEntry = System.Net.Dns.GetHostEntry(strThisHostName);
                //Get All IP Addressed and store it within the host entry object 
                allIPsOfThisHost = thisHostDNSEntry.AddressList;


                //Loop through all the Addresses and find the first IPV4 Address
                for (int idx = allIPsOfThisHost.Length -1; idx > 0; idx --)
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
                MessageBox.Show("IP Address cannot be detected. Program will still carry on running...", "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Return with IPV4 Address
            return ipv4Ret;
        }

        // Draggable window
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

        //When the connect button is clicked
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Create Object IPAddress and an Integer for the port number
            IPAddress ipa;
            int nPort;

            //We check if we are able to still able to right to the config group box
            isAvailableToWrite = false;

            try
            {
                //Code if IP Addr or Port is empty
                if (string.IsNullOrEmpty(tbServerIP.Text) || string.IsNullOrEmpty(tbName.Text))
                {
                    MessageBox.Show("You must enter your Name and provide an IP Address!", "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //If it cannot be passed over to the server IP
                if (!IPAddress.TryParse(tbServerIP.Text, out ipa))
                {
                    MessageBox.Show("Please supply an IP Address!", "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //If it cannot be passed over to the port Address
                if (!int.TryParse(tbServerPort.Text, out nPort))
                {
                    //Set a default port
                    nPort = 23000;
                    tbServerPort.Text = Convert.ToString(nPort);
                }

                //If the name text box is not empty
                if (!string.IsNullOrEmpty(tbName.Text))
                {
                    strName = tbName.Text;
                }

                //Create a new Object
                mTcpClient = new TcpClient();
                //Create a connection - IP ADDRESS, PORT NUMBER, WHEN CONNECTED AND WHICH CLIENT
                mTcpClient.BeginConnect(ipa, nPort, onCompleteConnect, mTcpClient);

                //We check the connection to enable and disable some functionality
                checkConnection();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //We check if the connection was successful or not
        void checkConnection()
        {
            if (isAvailableToWrite)
            {
                connectionGroup.Enabled = true;
                msgControls.Enabled = false;
            }
            else if (!isAvailableToWrite)
            {
                connectionGroup.Enabled = false;
                msgControls.Enabled = true;
                tbPayLoad.Select();
            }
        }

        //Call Back method when a connection attempt is finished
        void onCompleteConnect(IAsyncResult iar)
        {
            //Open a TCPClient connection
            TcpClient tcpc;

            //Create Object IPAddress and store null value 
            IPAddress ipa = null;

            //Lopp and feedback IPAddress
            ipa = findmMyIPV4Address();

            //We set this to be false as a connection attempt has to be made
            isAvailableToWrite = false;

            //Feedback Data by storing string in bytes
            byte[] tx = new byte[512];

            try
            {
                //We sync the result to the tcpclient
                tcpc = (TcpClient)iar.AsyncState;
                tcpc.EndConnect(iar);

                //Here we begin to include a read operation from the (this) client side
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromServerStream, tcpc);
               
                //We send the clients details to the server
                tx = Encoding.ASCII.GetBytes("Client has been connected. \r\nClient Name: " + strName + "\r\n"
                + "Clients IP Address: " + ipa.ToString() + "\r\n");
                mTcpClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToServer, mTcpClient);
                

            } catch (Exception exc)
            {
                MessageBox.Show("The Server is offline or has actively refused your connection, please try again later!",
                    "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
               
            }
        }

        //Read from the stream on complete
        void onCompleteReadFromServerStream (IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountBytesReceivedFromServer;
            string strReceived;

            try
            {
                //We are now checking if the bytes were received from the server
                tcpc = (TcpClient)iar.AsyncState;
                nCountBytesReceivedFromServer = tcpc.GetStream().EndRead(iar);

                //We are checking if the number of bytes sent to the server was nothing
                if (nCountBytesReceivedFromServer == 0)
                {
                    //if this is the case, the connection is broken
                    MessageBox.Show("Connection broken, retry connecting to the server!", "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //If the above does not happen then we store the data into strReceived and print
                strReceived = Encoding.ASCII.GetString(mRx, 0, nCountBytesReceivedFromServer);
                printLine(strReceived);
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromServerStream, tcpc);

            } catch (Exception exc)
            {
                MessageBox.Show("Server has disconnected, please try again later!", "TCP/IP Client" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Restart();
            }
        }

        //When the sent button is pressed
        private void btnSend_Click(object sender, EventArgs e)
        {

            //We create a byte array
            byte[] tx;
            
            //We check if the messages textbox is empty
            if (string.IsNullOrEmpty(tbPayLoad.Text))
            {
                MessageBox.Show("There is nothing to send as your message box is empty!", "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //We can now take the text from the payload, convert it to bytes and store it in tx
            try
            {
                //We check if there is stil a connection by checking if there are still packets
                if (mTcpClient != null)
                {
                    if (mTcpClient.Client.Connected)
                    {
                        //We store the text from message, convert it to bytes and then store it in tx
                        tx = Encoding.ASCII.GetBytes(strName + DateTime.Now.ToString(" [h:mm:ss] ") + ": " + tbPayLoad.Text);
                        mTcpClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToServer, mTcpClient);

                        //We print the clients message also on the same window
                        printLine(strName + DateTime.Now.ToString(" [h:mm:ss] ") + ": " + tbPayLoad.Text);

                        //We then clear the message on the payload
                        tbPayLoad.Clear();

                    } else if (!mTcpClient.Client.Connected)
                    {
                        MessageBox.Show("You are not connected to a server!", "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        msgControls.Enabled = false;
                    }
                } 

            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //What to do when it is written to the server
        void onCompleteWriteToServer (IAsyncResult iar)
        {
            //Create TcpClient obkect
            TcpClient tcpc;

            try
            { 
                //Convering the results of the IAR and casting it to TcpClient
                tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);

            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "TCP/IP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //When About button is executed
        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        //When the close button is executed
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
            tbConsole.Invoke(new Action<string>(doInvoke), _strPrint);
        }

        public void doInvoke(string _strPrint)
        {
            tbConsole.Text = tbConsole.Text + _strPrint + Environment.NewLine;
        }
    }
}
