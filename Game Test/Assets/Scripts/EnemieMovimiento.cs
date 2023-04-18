using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovimiento : MonoBehaviour
{

    // Seccion de funciones

    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;
    private Rigidbody2D rb;


    // Seccion de Start

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Seccion FixedUpdate

    private void FixedUpdate()
    {

        // Lanzar un RayCast

        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        // velocidad del enemigo

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        // Condicional para ejecutar la funcion girar

        if (informacionSuelo == false)  
        {
            Girar();
        }
    }

    // Funcion para girar

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    // funcion para dibujar el RayCast

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }
}
