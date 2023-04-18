using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class zarigueya : MonoBehaviour
{
    public bool enColision = false;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.CompareTag("Player"))
        {
            foreach (ContactPoint2D punto in other.contacts)
            {
                if (punto.normal.y <= -0.9)
                {
                    other.gameObject.GetComponent<PlayerMovement>().Rebote(other.GetContact(0).normal);
                    Destroy(gameObject);
                }

                else if (punto.normal.y >= -0.9)
                {
                    other.gameObject.GetComponent<CombateJugador>().TomarDaño(1, other.GetContact(0).normal);
                }
            }
            enColision = true;

        }
        
    }

   

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            enColision = false;
        }
    }
}
