using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    [SerializeField] int vida;
    [SerializeField] int maxVida;


    private void Start()
    {
        vida = maxVida;
    }

    public void TomarDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Curar(int curacion)
    {
        if ((vida + curacion) > maxVida)
        {
            vida = maxVida;
        }

        else
        {
            vida += curacion;
        }
    }
}
