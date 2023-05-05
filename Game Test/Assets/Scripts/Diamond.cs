using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int dineroObjeto;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<EconomiaJugador>().TomarDinero(dineroObjeto);
            Destroy(gameObject);
        }
    }
}
