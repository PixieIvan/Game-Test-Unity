using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Seccion de Variables

    public static PlayerMovement Instance;
    private Rigidbody2D rb2D;
    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;
    [Header("Movimiento")]
    private float inputX;
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velociadDeMovimiento;
    [Range(0, 0.3f)] [SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;
    [Header("Animacion")]
    private Animator animator;
    public event EventHandler OnJump;
    [Header("SaltoPared")]
    [SerializeField] private Transform controladorPared;
    [SerializeField] private Vector3 dimensionesCajaPared;
    public bool enPared;
    public bool deslizando;
    [SerializeField] private float velocidadDeslizar;
    [SerializeField] private float fuerzaSaltoParedX;
    [SerializeField] private float fuerzaSaltoParedY;
    [SerializeField] private float tiempoSaltoPared;
    private bool saltandoDePared;


    // Seccion de start

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        if (PlayerMovement.Instance == null)
        {
            PlayerMovement.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Seccion de Update

    private void Update()
    {
        // Variebles de movimiento

        inputX = Input.GetAxisRaw("Horizontal");
        movimientoHorizontal = inputX * velociadDeMovimiento;

        // Variables para el animator

        animator.SetFloat("VelocidadX", Mathf.Abs((rb2D.velocity.x)));
        animator.SetFloat("VelocidadY", rb2D.velocity.y);
        animator.SetBool("Deslizando", deslizando);

        // Ejecucion de funciones con condiciones

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

        if (!enSuelo && enPared && inputX != 0)
        {
            deslizando = true;
        }

        else
        {
            deslizando = false;
        }
    }   

    // Seccion de FixedUpdate

    private void FixedUpdate()

    {
        // Variables de movimiento

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        enPared = Physics2D.OverlapBox(controladorPared.position, dimensionesCajaPared, 0f, queEsSuelo);

        //Variables para el animator

        animator.SetBool("enSuelo",enSuelo);

        // Ejecucion del movimiento

        if (sePuedeMover)
        {
            Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        }

        salto = false;

        // Condicion para deslizando

        if (deslizando)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -velocidadDeslizar, float.MaxValue));
        }

    }

    // Funcion de mover

    private void Mover(float mover, bool saltar)
    {

        // Condicional para movimiento del jugador

        if (!saltandoDePared)
        {
            Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        }

        // Condicional para rotar al jugador

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }

        // Condicional para rotar al jugador

        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        // Condicional para salar

        if (enSuelo && saltar && !deslizando)
        {
            Salto();
        }

        // Condicional para saltar en la pared

        if (enPared && saltar && deslizando)
        {
            SaltoPared();
        }
    }

    // Funcion para saltar en la pared

    private void SaltoPared()
    {
        enPared = false;
        rb2D.velocity = new Vector2(fuerzaSaltoParedX * -inputX, fuerzaSaltoParedY);
        StartCoroutine(CambioSaltoPared());
    }

    // Coroutine de cambio de salto Pared

    IEnumerator CambioSaltoPared()

    {
        saltandoDePared = true;
        yield return new WaitForSeconds(tiempoSaltoPared);
        saltandoDePared = false;
    }

    // Funcion para saltar

    private void Salto()
    {
        enSuelo = false;
        rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        OnJump?.Invoke(this, EventArgs.Empty);
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb2D.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }

    // Funcion para girar

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    // Funcion para cajas collision boxes del jugador

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
        Gizmos.DrawWireCube(controladorPared.position, dimensionesCajaPared);

    }

}