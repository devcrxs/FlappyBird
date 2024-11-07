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

    private void Update()
    {
        FlipEnemy();
    }

    private void Move()
    {
        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;
        agent.SetDestination(targetPosition);
    }

    private void FlipEnemy()
    {
        var direction = target.position - transform.position;
        var scale = transform.localScale;
        scale.x = direction.x > 0 ? 1 : -1;
        transform.localScale = scale;
    }
}
