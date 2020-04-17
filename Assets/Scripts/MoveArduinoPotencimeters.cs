using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MoveArduinoPotencimeters:MonoBehaviour
{
    public float vel;
    private int boton;
    private int dir;
    public GameObject bala;
    public float velocidadBala;
    public float tiempo;
    public float tiempoDeEspera = 1;
    public bool disparar = true;
    

    SerialPort puerto = new SerialPort("COM4", 9600);
    //SerialPort puerto = new SerialPort("/dev/cu.usbmodem1461", 9600);
    
    // Use this for initialization
    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(boton);
        //distanciaMov = vel * Time.deltaTime;

        if (puerto.IsOpen)
        {
            try
            {
                mover(puerto.ReadLine());
                
            }
            catch (System.Exception)
            {

            }
        }
        
        tiempo += Time.deltaTime;

        if (tiempo >= tiempoDeEspera) {
            disparar = true;
            tiempo = 0;
        }
        if (disparar == true) {
            if (boton == 1)
            {
                Debug.Log("holi");
                GameObject temp = Instantiate(bala);
                temp.gameObject.transform.position = this.gameObject.transform.position;
                Rigidbody temp2 = temp.gameObject.GetComponent<Rigidbody>();
                Vector3 fuerza = new Vector3(0, velocidadBala, 0);
                temp2.AddRelativeForce(fuerza, ForceMode.Impulse);
                disparar = false;
            }
        }
        
    }

    void mover(string datoArduino)
    {
        string[] datosArray = datoArduino.Split(char.Parse(","));

        if (datosArray.Length == 2)
        {
            dir = int.Parse(datosArray[1]);
            boton= int.Parse(datosArray[0]);
            print (boton+ "   ");
        }

        this.gameObject.transform.position = new Vector3(dir/82,1,0);

      


    }
}
