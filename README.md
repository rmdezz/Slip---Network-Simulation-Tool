
![Logo](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/logo_png.png)


# Slip - Network Simulation Tool

Slip is an advanced Windows application made to simulate different network conditions like latency, duplicate, shuffle, encrypt, drop, and traffic shaper bandwitdth on sending and receiving packets, with best-in-class accuracy. Using WinDivert library, Slip intercepts packets before they hit the network stack for real-time modifications according to the enabled modules chosen by the user. The graphical user interface is powered by a C# interface, while the backend code that governs the functionality of the application is written in a C/C++ dll. Furthermore, a console is available to monitor messages sent from the Slip dll through a named pipe. Slip boasts powerful and cutting-edge features sure to exceed any network simulation expectations.

![Gif](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/demo.gif)



## Installation
To install Slip, first download the lastest release package and its dependencies (WinDivert.dll, libcrypto-3-x64.dll, PipeReader.dll and Slip.dll). Then, simply launch the C# .exe file. After the initial setup is complete, you'll be able to start taking advantage of Slip's powerful network simulation capabilities. For the best performance, make sure to have all dependencies installed and up-to-date.
```bash
PipeReader.dll
Slip.dll
Slip.exe
SlipClient.exe
WinDivert.dll
WinDivert64.sys
libcrypto-3-x64.dll
```
    
## Usage
The usage section of Slip is designed to enable users to quickly and easily utilize the application's powerful network simulation capabilities. The Modules section allows users to choose from seven different simulation options.

## Features
![Features](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/screenshots/Screenshot%202023-01-10%20213315.jpg)
### Lag
Enabling this module allows the user to introduce a delay to the packets passing through the network, simulating a slower connection. This can be useful for testing an application's ability to handle latency or for simulating a long-distance network connection. The delay can be adjusted by using the delay slider, which allows the user to specify the amount of delay in milliseconds. The user can also select whether this applies to inbound or outbound packets, in this way, simulating different network scenarios. Additionally, this feature can also be used to test the robustness of a network protocol and identify if it can handle high latencies without failing, or if any optimization or redesign is necessary.
### Drop
Enabling this module allows the user to simulate network conditions by dropping a specified percentage of packets before they reach the network stack. This can be useful for testing an application's ability to handle packet loss, simulating a congested network, or conducting penetration testing. The chance of packets to be dropped can be adjusted by using a range of 0 to 100%. The user can also select whether this applies to inbound or outbound packets, which enables to simulate different network conditions. Additionally, using this feature in conjunction with other modules such as the duplicate module allows you to test how your application would handle packet loss scenarios, or how it would react when packets are dropped by a congested network.
### Throttle
Enabling this module allows the user to simulate a congested network by temporarily blocking traffic passing through the network in a specified time frame, before releasing it in a single batch. This feature allows to test an application's ability to handle network congestion, delays in receiving data, or a limited bandwidth. The user can control the rate at which traffic is released by adjusting the delay textbox input and the drop checkbox. This can be done by setting the delay time and drop checkbox, where the drop checkbox would allow you to drop the packets that exceed the delay time or keep them waiting for the release. The user can also select whether this applies to inbound or outbound packets, this way you can simulate different network scenarios. Additionally, this feature can be used to test the robustness of a network protocol and identify if it can handle high latency, congestion or limited bandwidth without failing, or if any optimization or redesign is necessary.
### Duplicate
Enabling this module allows the user to create multiple copies of the packets passing through the network before they reach the network stack. This can be used to simulate network congestion, test an application's ability to handle multiple packets or to conduct penetration testing. The user can adjust the number of copies to be created using the numeric up-down component. The user can also select whether this applies to inbound or outbound packets, and in this way you can test the network or the application under different scenarios. Additionally, using this feature in conjunction with the drop module allows you to test how the application would handle packet loss scenarios.
### Encrypt
Enabling this module allows the user to encrypt packets passing through the network. This feature can be used to test the security of an application or a network by simulating a secure communication, in this way you can test the application's behavior and detect any vulnerability or weakness. The encryption can be applied on all the packets or on specific packets that match the filter criteria, this way you can test different scenarios. Additionally, this feature can be useful for testing compliance with regulatory standards or industry best practices for data security.
### Shuffle
Enabling this module allows the user to simulate a chaotic network conditions by shuffling a specified number of packets passing through the network. This feature can be used to test the behavior of an application or network protocol under chaotic conditions, as well as identify potential vulnerabilities or bugs. The shuffle can be applied on all the packets or on specific packets that match the filter criteria, this way you can test different scenarios. The minimum number of packets required to start the shuffle module can be adjusted using the numeric up-down component. The user can also select whether this applies to inbound or outbound packets, which enables to simulate different network scenarios. In case of TCP packets, the shuffle updates the sequence number and recalculates the checksum to make the consumer believe that the packets are in the correct order, this way the packets can be delivered to the application as if they were in the correct order. Additionally, this feature can be used to test the robustness of a network protocol and identify if it can handle chaotic network conditions without failing, or if any optimization or redesign is necessary.
### Traffic Shaper (Bandwith)
Enabling this module allows the user to simulate network conditions by limiting the traffic speed of the network. This feature can be used to test an application's ability to handle limited bandwidth, simulating a congested network, or conducting penetration testing. The speed limit can be adjusted by using a textbox component in MB/s. The user can also select whether this applies to inbound or outbound packets, which enables to simulate different network scenarios. Additionally, using this feature in conjunction with other modules such as the duplicate or drop module allows you to test how the application would handle a congested network or limited bandwidth scenarios. This feature can also be used to test the robustness of a network protocol and identify if it can handle limited bandwidth without failing, or if any optimization or redesign is necessary.


## Filtering
The Filtering section provides the ability to selectively apply the modules' functionalities to specific packets. This allows you to test the behavior of an application or network protocol under specific scenarios. The user can either choose from predefined presets or set their own filter using the WinDivert filter syntax. This powerful feature allows to create complex filters that include various filtering criteria such as protocol, direction, source, and destination addresses, among others. Additionally, this feature can be used to simulate more realistic network conditions by applying the modules' functionalities only to a subset of the network packets, rather than to all of them. This feature can also help you to isolate specific packets for further testing.
![Filtering](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/screenshots/Screenshot%202023-01-10%20213215.jpg)

## Screenshots

![Screenshot1_black](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/screenshots/Screenshot%202023-01-10%20213232.jpg)
![Screenshot2_black](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/screenshots/Screenshot%202023-01-10%20213245.jpg)
![Screenshot1_white](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/screenshots/Screenshot%202023-01-10%20213215.jpg)
![Screenshot2_white](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/screenshots/Screenshot%202023-01-10%20213315.jpg)
![Screenshot3](https://github.com/rmdezz/Slip---Network-Simulation-Tool/blob/master/screenshots/Screenshot%202023-01-10%20213141.jpg)


