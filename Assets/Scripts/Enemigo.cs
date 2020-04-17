using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public GameObject enemigos;
    public float VelocidadCambios;
    public float crearEnemigoCada;
    public float subirDificultadCada;
    public float Agregar;
    public float tiempo;

    public float tiempo2;
    private Vector3 empuje;
    public float Valor1;
    public float Valor2;
    public float ubicacionEnY=0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= crearEnemigoCada)
        {
            GameObject temp = Instantiate(enemigos);
            float ubicacionX = Random.Range(Valor1, Valor2);
            temp.gameObject.transform.position = new Vector3(ubicacionX, ubicacionEnY,0);
            Rigidbody fuerza = temp.gameObject.GetComponent<Rigidbody>();
            float velocidadVariable = Random.Range(VelocidadCambios, VelocidadCambios * 1.5f);
            empuje = new Vector3(0, -velocidadVariable, 0);
            fuerza.AddRelativeForce(empuje, ForceMode.Impulse);
            tiempo = 0;
        }

        tiempo2 += Time.deltaTime;
        if (tiempo >= subirDificultadCada)
        {
            VelocidadCambios = VelocidadCambios + Agregar;
            tiempo2 = 0;
        }

    }

}
