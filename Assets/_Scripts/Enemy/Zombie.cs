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
        ObjectPoolingManager.instance.AddEnemyToAvaible(gameObject);
        gameObject.SetActive(false);
    }

    protected override void LaunchDamage()
    {
        //throw new System.NotImplementedException();
    }
}