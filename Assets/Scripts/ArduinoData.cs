using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoData : MonoBehaviour
{

    SerialPort puerto = new SerialPort("COM3", 9600);
    //SerialPort puerto = new SerialPort("/dev/cu.usbmodem1461", 9600);


    // Start is called before the first frame update
    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (puerto.IsOpen)
        {
            try
            {
                print(puerto.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
    }
}
