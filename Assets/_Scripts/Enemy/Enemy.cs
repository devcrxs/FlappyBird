using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;

    protected abstract void UpdateHealth();
    protected abstract void Dead();
    protected abstract void LaunchDamage();

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet")) return;
        UpdateHealth();
    }
}
