using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
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

                if (punto.normal.y >= -0.9)
                {
                    other.gameObject.GetComponent<CombateJugador>().TomarDaño((float)0.5, other.GetContact(0).normal);
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
