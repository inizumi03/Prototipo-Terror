using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muro : MonoBehaviour
{
    public GameObject llave; // Referencia al objeto llave

    void Start()
    {
        if (llave != null)
        {
            // Suscribirse al evento de destrucción de la llave
            llave.GetComponent<Llave>().onLlaveDestruida += DestruirMuro;
        }
    }

    // Método que se llama cuando la llave es destruida
    void DestruirMuro()
    {
        Destroy(gameObject); // Destruir el muro
    }
}
