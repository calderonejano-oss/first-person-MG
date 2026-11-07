using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Navegation : MonoBehaviour
{
    [Header("componentes")]
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public Transform Target;
    public bool isDead;
    public GameObject gameObjectCanva;
    public float distanciaDeAtaque = 2f; 
    public bool isdance;

    void Start()
    {
        navMeshAgent.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("TargetUpdate",3f,.2f);
        animator = GetComponentInChildren<Animator>();
        gameObjectCanva = GetComponentInChildren<Canvas>().gameObject;

    }

    void Update()
    {
        if(isDead == true)
        {
            return;
        }
        if (isdance == true)
        {
            return;
        } 
    
        if (navMeshAgent.velocity.magnitude > 0)
        {
            animator.SetBool("Ismoving", true);
        }
        else animator.SetBool("Ismoving", false);

        float distancia = Vector3.Distance(transform.position, Target.position);
        if (distancia <= distanciaDeAtaque)
        {
            StartCoroutine(Ataque());
        }
    
    }
    private void TargetUpdate()
    {
        navMeshAgent.destination = Target.position;
    }
    public IEnumerator die()
    {
        animator.SetTrigger("Die");
        navMeshAgent.isStopped = true;
        isDead = true;
        GetComponent<Collider>().enabled = false;
        gameObjectCanva.SetActive(false);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    public IEnumerator hit()
    {
        if (isDead) yield break;
        animator.SetTrigger("Hit");
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(1f);
        if (!isDead)
        {
            navMeshAgent.isStopped = false;
        }
    
    }
    IEnumerator Ataque()
    {
        animator.SetTrigger("Ataque");
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(1.2f);
        navMeshAgent.isStopped = false;
    }

}
