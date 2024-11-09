using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] private GameObject diamondPrefab;
    [SerializeField] protected Animator animator;
    private float _dropDiamondChance;

    protected abstract void UpdateHealth();
    protected abstract void Dead();
    protected abstract void LaunchDamage();

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet")) return;
        UpdateHealth();
    }

    protected void AddPointsForKilling()
    {
        GameManager.instance.AddScoreDeath();
        UIManager.instance.UpdateEnemyDeath();
    }
    protected void SpawnDiamond()
    {
        float randomChance = Random.Range(0f, 100f);
        _dropDiamondChance  = Random.Range(0f, 60f);
        if (randomChance <= _dropDiamondChance)
        {
            Instantiate(diamondPrefab, transform.position, Quaternion.identity);
        }
    }
}
