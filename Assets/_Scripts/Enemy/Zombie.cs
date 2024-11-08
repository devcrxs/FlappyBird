public class Zombie : Enemy
{ 
    protected override void UpdateHealth()
    {
        health -= 1;
        if (health > 0) return;
        Dead();
    }

    protected override void Dead()
    {
        AddPointsForKilling();
        ObjectPoolingManager.instance.AddEnemyToAvaible(gameObject);
        SpawnerManager.instance.CanSpawn();
    }

    protected override void LaunchDamage()
    {
        //throw new System.NotImplementedException();
    }
}
