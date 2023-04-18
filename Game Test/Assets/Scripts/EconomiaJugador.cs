using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomiaJugador : MonoBehaviour
{
    [SerializeField] private float dineroJugador;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void TomarDinero(float dinero)
    {
        dineroJugador += dinero;
    }

    public void QuitarDinero(float dinero)
    {
        dineroJugador -= dinero;
    }
}
