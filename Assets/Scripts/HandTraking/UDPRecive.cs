using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class HandUDPReceiver : MonoBehaviour {
    UdpClient udp;
    IPEndPoint remoteEndPoint;
    string lastMessage = "";

    // Reference to the DoorController
    public DoorController door; // Assign in Inspector

    void Start() {
        udp = new UdpClient(5052); // Same port as Python
        remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        Debug.Log("UDP Receiver started on port 5052");
    }

    void Update() {
        if (udp.Available > 0) {
            byte[] data = udp.Receive(ref remoteEndPoint);
            lastMessage = Encoding.UTF8.GetString(data);

            Debug.Log("Received: " + lastMessage);

            if (lastMessage == "OPEN") {
                Debug.Log("Hand open detected ? Trigger OPEN animation");
                door.OpenDoor();
            }
            else if (lastMessage == "CLOSE") {
                Debug.Log("Hand closed ? Trigger CLOSE animation");
                door.CloseDoor();
            }
        }
    }
}
