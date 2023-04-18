using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool activa = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !activa)
        {
            ActivarPalanca();        
        }

        else if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && activa)
        {
            DesactivarPalanca();
        }
    }

    private void ActivarPalanca()
    {
        animator.SetBool("Activa", activa);
        activa = true;
    }

    private void DesactivarPalanca()
    {
        animator.SetBool("Activa", activa);
        activa = false;
    }
}

