# TCPIPSockets v0.4
TCP/IP Server and Client Sockets Application created using Visual C#.NET

<h2><b>Note</b></h2>

The initial purpose of this project was to differentiate how a TCP/IP protocol would communicate between one machine and another; compared to other peers to peer communication methods which use the internet of things and DNS (Domain Name Servers). This Application 'TCPIPSockets' was created using 'Visual Studio 2015', therefore when editing these files, be sure to use the guidance of 'Microsoft Visual Studio'. All code is open-source, but a reference to 'Milan Conhye' would be much appreciated. This code does not use the backbone of TCP/IP Sockets Programming, instead uses the .NET Framework provided by 'Microsoft' to make it more readable and considerably easier to program. All code has been thoroughly commented in order to be understood and further extended. 

This project has been split into two main programs - 'TCPIPClient' and 'TCPIPServer'. The host machine must have at least the 'TCPIPServer' running and listening, and the client machine must have the 'TCPIPClient' running and connected to the host for them to be able to communicate with each other. These two main folders contain the code which can be opened using Visual Studio. However, if you would like to test the communication, it is recommended to use the executable files contained within the 'TestRun' folder of this branch. 

<h2><b>General Knowledge</b></h2>

The TCP/IP Server requires you to accept incoming connections from other machines, meaning that you must temporary disable your firewall or allow it (Windows 10+) for this application to run successfully. The TCP/IP Server features an auto IPv4 detection which will be placed as a default IP address on the appropriate text box. As you may know, there is a total of 65536 ports on a computer, well-known ports or system ports are <b>reserved</b> between 0 - 1023. A single port can be used to send or receive data, but only at one process at any given time. Since TCP/IP must use the combination of an IP address and a port number (End Point), if the port number has not been specified, a default port number of '23000' will use.

You may specify a loopback address (127.0.0.1/8), on the server and client side, but this would only limit you to running the client and server on a single machine. By using a loopback address, the server does not need to know the exact IPv4 Address.

<b>The TCP/IP Client must have knowledge of the Server IP and Port to create a successful connection.</b>

<h4><b>Client Server Model</b></h4>

Server                                          | Client
-------------                                   | -------------
The Server must start first.                    | The Client - Servers IP Address and Port number.
Must perform and accept connections.            | Exceptions on most or of these processes. 
Specific IP Address and Port number provided.   |  

<h2>Operation</h2>

<h4>TCP/IP Server</h4>

As seen in Figure 1, the TCP/IP Server Application features an auto detection of the IPv4 Address and is placed within the configuration panel. You are not obligated to provide a port number and therefore if not specified, a default port number of 23000 will be used. 

![TCP/IP Server](/Screenshots/1.png?raw=true "TCP/IP Server")

<h4>TCP/IP Client</h4>

As seen in Figure 2, the client is required to specify their Name, the Server IP, and Server Port number. If the Name and/or IP address are blank then an error message will occur. It is recommended to specify the Server Port number, however, the default port number of 23000 will be provided if the field is blank. If the client is not able to connect to the server, an exception will be thrown. There are many validation rules and error prevention techniques - they will not be featured in this readme file, however, the main error occurrences will. 

![TCP/IP Client](/Screenshots/2.png?raw=true "TCP/IP Client")

As seen in Figure 3, if the client has been successfully connected to the server, the client will receive various information which is appended on their console.

![TCP/IP Client](/Screenshots/3.png?raw=true "TCP/IP Client")

<h4>TCP/IP Server</h4>

However, on the TCP/IP Server Console, the host is able to see the clients Name and IPv4 address (Figure 4). This is used for safety precautions, if in case the server expects a specific IP address and has received an unknown other. At this point, the server is able to accept multiple connections from other clients.

![TCP/IP Server](/Screenshots/4.png?raw=true "TCP/IP Server")

<h2>Additional Features</h2>

Various other features are added such as the current time appended on every message to keep track of messages - the rest is up to you to explore and implement. However, there is just one optional feature I have in mind which I have not added as of yet, but can be implemented by you. 

<h4>Listen for incoming connections on “Any” IP address</h4>

So far, we have seen two techniques to listen for incoming connections I.e. A specific IP address, and a loopback address. However, it is possible to listen to incoming connections on both of these IP addresses or any other associated with your PC. To implement this, within the object variable of mTCPListener you can parse the following instead: 
`mTCPListener = new TcpListener(IPAddress.Any, nPort);` 

<h2>Errors, Bugs and Feedback </h2>

If you come across any of those nasty little things, would like to contribute some ideas towards this project or even if you need some guidance - please do leave a comment and I will try my best to respond as fast as possible. 
