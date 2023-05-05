using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public GameObject jugador;
    public int indiceNivel;
    public float nuevaPosX;
    public float nuevaPosY;
    public bool enPuerta;


    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (enPuerta && Input.GetKeyDown(KeyCode.E) && jugador.GetComponent<PlayerMovement>().enSuelo)
        {
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