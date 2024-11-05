using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;
        agent.SetDestination(targetPosition);
    }
}
