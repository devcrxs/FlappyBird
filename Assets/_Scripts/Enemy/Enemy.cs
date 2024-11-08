using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    
    [SerializeField] private int pointsForKilling = 1;

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
        GameManager.instance.AddScoreDeath(pointsForKilling);
        UIManager.instance.UpdateEnemyDeath();
    }
}
