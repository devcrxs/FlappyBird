public class Skeleton : Enemy
{
    private EnemyMove _enemyMove;

    private void Start()
    {
        _enemyMove = GetComponent<EnemyMove>();
    }

    protected override void UpdateHealth()
    {
        health -= 1;
        animator.SetTrigger("Hit");
        if (health > 0) return;
        Dead();
    }

    protected override void Dead()
    {
        animator.SetTrigger("Dead");
        _enemyMove.IsDead = true;
        AddPointsForKilling();
        SpawnerManager.instance.CanSpawn();
        Invoke(nameof(HideEnemy), 0.4f);
    }

    private void HideEnemy()
    {
        ObjectPoolingManager.instance.AddEnemyToAvaible(gameObject);
        SpawnDiamond();
    }

    protected override void LaunchDamage()
    {
        //throw new System.NotImplementedException();
    }
}
