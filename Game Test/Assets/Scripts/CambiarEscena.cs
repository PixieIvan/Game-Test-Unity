using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nombreJugador;
    public int indiceNivel;
    public float nuevaPosX;
    public float nuevaPosY;
    public bool enPuerta;
  


    private void Update()
    {
        

        if (enPuerta && Input.GetKeyDown(KeyCode.E))
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