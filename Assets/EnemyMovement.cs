using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Update()
    {
        navAgent.SetDestination(target.position);
    }
}
