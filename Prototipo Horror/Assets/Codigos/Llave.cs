using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public delegate void LlaveDestruida(); // Definici�n del delegado
    public event LlaveDestruida onLlaveDestruida; // Evento que se dispara cuando la llave se destruye

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Jugador")) // Aseg�rate de que tu jugador tenga la etiqueta "Jugador"
        {
            Destroy(gameObject); // Destruir la llave

            // Disparar el evento de destrucci�n de la llave
            if (onLlaveDestruida != null)
            {
                onLlaveDestruida.Invoke();
            }
        }
    }
}
