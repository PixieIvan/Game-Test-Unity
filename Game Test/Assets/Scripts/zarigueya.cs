using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zarigueya : MonoBehaviour
{
    public bool enColision = false;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.CompareTag("Player"))
        {
            enColision = true;
            other.gameObject.GetComponent<CombateJugador>().TomarDaño(1, other.GetContact(0).normal);
        }
        foreach (ContactPoint2D punto in other.contacts)
        {
            if (punto.normal.y <= -0.9)
            {

            }
        }
    }

   

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            enColision = false;
            other.gameObject.GetComponent<CombateJugador>().TomarDaño(1, other.GetContact(0).normal);
        }
    }
}
