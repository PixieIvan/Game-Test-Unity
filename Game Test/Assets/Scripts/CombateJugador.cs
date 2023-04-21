using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{

    [SerializeField] private float vidaJugador;
    private PlayerMovement playerMovement;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vidaJugador -= daño;
    }

    public  void TomarVida(float vida)
    {
        vidaJugador += vida;
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vidaJugador -= daño;
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        playerMovement.Rebote(posicion);
    }

    private IEnumerator PerderControl()
    {
        playerMovement.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        playerMovement.sePuedeMover = true;
    }
}
