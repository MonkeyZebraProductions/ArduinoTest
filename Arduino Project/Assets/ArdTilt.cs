using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArdTilt : MonoBehaviour
{
    // Start is called before the first frame update
    public float ArdX;
    public float ArdY;
    public float ArdZ;

    public SerialController serialController;
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Update is called once per frame
    void Update()
    {
        string message = serialController.ReadSerialMessage();

        //if (message == null)
        //    return;

        //// Check if the message is plain data or a connect/disconnect event.
        //if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
        //    Debug.Log("Connection established");
        //else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
        //    Debug.Log("Connection attempt failed or disconnection detected");
        //else
        //    Debug.Log("Message arrived: " + message);

        string[] ArdString=message.Split(',');
        Debug.Log(ArdString[0]);
        Debug.Log(ArdString[1]);
        Debug.Log(ArdString[2]);

        ArdX = float.Parse(ArdString[0]);
        ArdY = float.Parse(ArdString[1]);
        ArdZ = float.Parse(ArdString[2]);
        transform.rotation = Quaternion.EulerAngles(ArdX, ArdY, ArdZ);
    }
}
