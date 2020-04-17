using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorDC : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Bala") {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag=="Enemigo") {
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
