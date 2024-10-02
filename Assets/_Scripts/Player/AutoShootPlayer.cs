using UnityEngine;
public class AutoShootPlayer : MonoBehaviour
{
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private float shootDistance = 10f;
    [SerializeField]private float shootTime = 1f;
    [SerializeField]private float nextTimeShoot = 1f;
    [SerializeField]private Transform bulletSpawn;
    [SerializeField]private float bulletSpeed = 10f;
    [SerializeField]private LayerMask layerTarget;

    private void Update()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, shootDistance, layerTarget);

        if (enemiesInRange.Length <= 0) return;
        if (!(Time.time > nextTimeShoot)) return;
        ShootAtEnemy(enemiesInRange[0].transform.position);
        nextTimeShoot = Time.time + 1f / shootTime;
    }

    private void ShootAtEnemy(Vector2 enemyPosition)
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        Rigidbody2D bulletRb2d = bulletInstance.GetComponent<Rigidbody2D>();
        if (bulletRb2d == null) return;
        Vector2 direction =(enemyPosition - (Vector2)bulletSpawn.position).normalized;
        bulletRb2d.velocity = direction * bulletSpeed;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
}
