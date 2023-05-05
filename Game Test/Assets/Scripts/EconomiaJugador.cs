using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomiaJugador : MonoBehaviour
{
    public float dineroJugador;
   
    public void TomarDinero(float dinero)
    {
        dineroJugador += dinero;
    }

    public void QuitarDinero(float dinero)
    {
        dineroJugador -= dinero;
    }


}
