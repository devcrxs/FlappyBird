using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        agent.SetDestination(target.position);
    }
}
