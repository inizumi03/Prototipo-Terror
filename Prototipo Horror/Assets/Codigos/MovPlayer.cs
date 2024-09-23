using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public float velocidadMovimiento = 5f;   // Velocidad del jugador
    private Vector3 velocidadActual;         // Almacena la velocidad actual
    private Vector3 velocidadDeseada;        // Almacena la velocidad deseada
    private Vector3 velocidadRef;            // Para la interpolación suave
    public float suavizadoMovimiento = 0.1f; // Factor de suavizado

    void Update()
    {
        // Capturar las entradas de movimiento (WASD)
        float movX = Input.GetAxisRaw("Horizontal");  // Movimiento lateral (A/D)
        float movZ = Input.GetAxisRaw("Vertical");    // Movimiento hacia adelante o atrás (W/S)

        // Calcular el vector de movimiento deseado
        Vector3 direccionMovimiento = transform.right * movX + transform.forward * movZ;

        // Calcular la velocidad deseada y aplicar suavizado
        velocidadDeseada = direccionMovimiento.normalized * velocidadMovimiento;
        velocidadActual = Vector3.SmoothDamp(velocidadActual, velocidadDeseada, ref velocidadRef, suavizadoMovimiento);

        // Aplicar el movimiento al jugador
        transform.position += velocidadActual * Time.deltaTime;
    }
}

