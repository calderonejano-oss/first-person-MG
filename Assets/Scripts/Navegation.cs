using UnityEngine;
using UnityEngine.AI;

public class Navegation : MonoBehaviour
{
    [Header("componentes")]
    public NavMeshAgent navMeshAgent;

    public Transform Target;

    void Start()
    {
        navMeshAgent.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("TargetUpdate",3f,.2f);

    }

    void Update()
    {
        
    }
    private void TargetUpdate()
    {
        navMeshAgent.destination = Target.position;
    }
}
