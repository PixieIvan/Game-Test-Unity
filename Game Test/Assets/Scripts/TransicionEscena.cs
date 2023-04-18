using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CambiarEscenas());
        }
    }

    IEnumerator CambiarEscenas()
    {
        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(animacionFinal.length);
            
    }
}