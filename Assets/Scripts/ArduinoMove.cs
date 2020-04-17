using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ArduinoMove : MonoBehaviour 
{
	SerialPort puerto = new SerialPort("COM4", 9600);

	public float distanciaMov = 50;

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
				mover(puerto.ReadByte());
			}
			catch (System.Exception)
			{

			}
		}

		//transform.Rotate(Vector3.up * distanciaMov, Space.Self);
	}

	void mover(int direccion)
	{


		if (direccion == 1)
		{
			transform.Translate(Vector3.left * distanciaMov, Camera.main.transform);
		}



		//Space.World: se mueve en las coordenadas del espacio local donde esta el GameObject
		//Space.Self: se utiliza para rotación sobre si mismo, con los ejes que el objeto tiene
		//Camera.main.transform: se mueve relativo a las coordenadas de la camara

		if (direccion == 2)
		{
			transform.Translate(Vector3.right * distanciaMov, Camera.main.transform);

		}
	}
}
