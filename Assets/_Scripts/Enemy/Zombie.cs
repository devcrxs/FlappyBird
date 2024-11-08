using UnityEngine;

public class Zombie : Enemy
{ 
    [SerializeField] private GameObject diamond;
    private float dropDiamondChance = 43f;
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
        SpawnDiamond();
    }

    protected override void LaunchDamage()
    {
        //throw new System.NotImplementedException();
    }

    public void SpawnDiamond()
    {
        float randomChance = Random.Range(0f, 100f);
        if (randomChance <= dropDiamondChance)
        {
            Instantiate(diamond, transform.position, Quaternion.identity);
        }
    }
}
