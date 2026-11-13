using System;
using System.Net.Sockets;

namespace MissionToMarsCommon;

public class Listener {
    // vars

    private TcpListener tcp; 


    public Listener(int pPort) {
        tcp = new TcpListener(pPort);
    }
}