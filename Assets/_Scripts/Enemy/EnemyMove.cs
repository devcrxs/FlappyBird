using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    private bool isDead;
    private Transform target;
    private NavMeshAgent agent;

    public bool IsDead
    {
        set => isDead = value; 
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (isDead) return;
        Move();
        FlipEnemy();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,target.position, agent.speed * Time.deltaTime);
        //agent.SetDestination(targetPosition);
    }

    private void FlipEnemy()
    {
        var direction = target.position - transform.position;
        var scale = transform.localScale;
        scale.x = direction.x > 0 ? 1 : -1;
        transform.localScale = scale;
    }
}
