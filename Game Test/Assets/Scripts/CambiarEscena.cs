using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public GameObject jugador; // Referencia al objeto que contiene PlayerMovement
    public string nombreJugador;
    public int indiceNivel;
    public float nuevaPosX;
    public float nuevaPosY;
    public bool enPuerta;


    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player"); // Busca el objeto por etiqueta y asigna la referencia
    }
    private void Update()
    {

        
        if (enPuerta && Input.GetKeyDown(KeyCode.E) && jugador.GetComponent<PlayerMovement>().enSuelo)
        {
                GameObject jugador = GameObject.Find(nombreJugador);
                CambioDeEscena(indiceNivel);
                jugador.transform.position = new Vector2(nuevaPosX, nuevaPosY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            enPuerta = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            enPuerta = false;
    }

    public void CambioDeEscena(int indice)
    {
        SceneManager.LoadScene(indice);
    }  
}