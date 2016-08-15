# TCPIPSockets v0.4
<i>TCP/IP Server and Client Sockets Application created using Visual C#.NET.</i>

TCIPSockets is a peer to peer communication platform which uses TCP (Transmission Control Protocol) to send and receive information between various devices within the same network. TCIPSockets features Date/Time of messages sent, IP verification, validation rules etc. Since TCIPSockets or any application which allows you to communicate between various nodes, you must temporarily disable your firewall or whitelist this application. 

<h2><b>Note</b></h2>

The initial purpose of this project was to differentiate how a TCP/IP protocol would communicate between one machine and another; compared to other peers to peer communication methods which use the internet of things and DNS (Domain Name Servers). This Application 'TCPIPSockets' was created using 'Visual Studio 2015', therefore when editing these files, be sure to use the guidance of 'Microsoft Visual Studio'. All code is open-source, but a reference to 'Milan Conhye' would be much appreciated. This code does not use the backbone of TCP/IP Sockets Programming, instead uses the .NET Framework provided by 'Microsoft' to make it more readable and considerably easier to program. All code in this program has been thoroughly commented in order to be understood and further extended. 

This project has been split into two main programs - 'TCPIPClient' and 'TCPIPServer'. The host machine must have at least the 'TCPIPServer' running and listening, and the client machine must have the 'TCPIPClient' running and connected to the host for them to be able to communicate with each other. These two main folders contain the code which can be opened using Visual Studio. However, if you would like to test the communication, it is recommended to use the executable files contained within the 'TestRun' folder of this branch. 

Requirements: Any version of Windows 7+ with support the of NetFramework 4.0.

<h2><b>General Knowledge</b></h2>

The TCP/IP Server requires you to accept incoming connections from other machines, meaning that you must temporary disable your firewall or allow it (Windows 10+) for this application to run successfully. The TCP/IP Server features an auto IPv4 detection which will be placed as a default IP address on the appropriate text box. As you may know, there is a total of 65536 ports on a computer, well-known ports or system ports are <b>reserved</b> between 0 - 1023. A single port can be used to send or receive data, but only at one process at any given time. Since TCP/IP must use the combination of an IP address and a port number (End Point), if the port number has not been specified, a default port number of '23000' will be used.

You may specify a loopback address (127.0.0.1/8), on the server and client side, but this would only limit you to running the client and server on a single machine. By using a loopback address, the server does not need to know the exact IPv4 Address.

<b>The TCP/IP Client must have knowledge of the Server IP and Port to create a successful connection.</b>

<h4><b>Client Server Model</b></h4>

Server                                          | Client
-------------                                   | -------------
The Server must start first.                    | The Client - Servers IP Address and Port number.
Must perform and accept connections.            | Exceptions on most of these processes. 
Specific IP Address and Port number provided.   |  

<h2>Operation</h2>

<h4>TCP/IP Server</h4>

As seen in Figure 1, the TCP/IP Server Application features an auto detection of the IPv4 Address and is placed within the configuration panel. You are not obligated to provide a port number and therefore if not specified, a default port number of 23000 will be used. 

<i>Figure 1 - TCP/IP Server</i>

![TCP/IP Server](/Screenshots/1.png?raw=true "TCP/IP Server")

<h4>TCP/IP Client</h4>

As seen in Figure 2, the client is required to specify their Name, the Server IP, and Server Port number. If the Name and/or IP address are blank then an error message will occur. It is recommended to specify the Server Port number, however, the default port number of 23000 will be provided if the field is blank. If the client is not able to connect to the server, an exception will be thrown. There are many validation rules and error prevention techniques - they will not be featured in this readme file, however, the main error occurrences will. 

<i>Figure 2 - TCP/IP Client</i>

![TCP/IP Client](/Screenshots/2.png?raw=true "TCP/IP Client")

As seen in Figure 3, if the client has been successfully connected to the server, the client will receive various information which is appended on their console.

<i>Figure 3 - TCP/IP Client</i>

![TCP/IP Client](/Screenshots/3.png?raw=true "TCP/IP Client")

<h4>TCP/IP Server</h4>

However, on the TCP/IP Server Console, the host is able to see the clients Name and IPv4 address (Figure 4). This is used for safety precautions, if in case the server expects a specific IP address and has received an unknown other. At this point, the server is able to accept multiple connections from other clients.

<i>Figure 4 - TCP/IP Server</i>

![TCP/IP Server](/Screenshots/4.png?raw=true "TCP/IP Server")

<h2>Additional Features</h2>

Various other features are added such as the current time appended on every message to keep track of messages - the rest is up to you to explore and implement. However, there is just one optional feature I have in mind which I have not added as of yet, but can be implemented by you. 

<h4>Listen for incoming connections on “Any” IP address</h4>

So far, we have seen two techniques to listen for incoming connections I.e. A specific IP address, and a loopback address. However, it is possible to listen to incoming connections on both of these IP addresses or any other associated with your PC. To implement this, within the object variable of mTCPListener you can parse the following instead: 
`mTCPListener = new TcpListener(IPAddress.Any, nPort);` 

<h2>Errors, Bugs and Feedback</h2>

If you come across any of those nasty little things, would like to contribute some ideas towards this project or even if you need some guidance - please do leave a comment and I will try my best to respond as fast as possible. 

<h2>Licence and Agreement</h2>

The software is provided "as is" and the author disclaims all warranties with regard to this software including all implied warranties of merchantability and fitness. This software, does not encrypt the information sent across the network. In no event shall the author be liable for any special, direct, indirect, or consequential damages or any damages whatsoever resulting from loss of use, data or profits, whether in an action of contract, negligence or other tortious action, arising out of or in connection with the use or performance of this software. Please acknowledge and agree to this agreement before downloading and using this software.

<a rel="license" href="http://creativecommons.org/licenses/by-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-sa/4.0/88x31.png" /></a><br />This work is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-sa/4.0/">Creative Commons Attribution-ShareAlike 4.0 International License</a>.
