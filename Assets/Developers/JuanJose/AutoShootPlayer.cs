
using UnityEngine;

public class AutoShootPlayer : MonoBehaviour
{
    [SerializeField]private GameObject bullet;
    [SerializeField]private float shootDistance = 10f;
    [SerializeField]private float shootTime = 1f;
    [SerializeField]private float nextTimeShoot = 1f;
    [SerializeField]private Transform bulletSpawn;
    [SerializeField]private float bulletSpeed = 10f;
    private LayerMask Enemy;
    [SerializeField]private Rigidbody2D rb2d;

    
    void Update()
    { 
        Enemy = LayerMask.GetMask("Enemy");
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, shootDistance, Enemy);
        
        if (enemiesInRange.Length > 0)
        {
            if (Time.time > nextTimeShoot)
            {
                ShootAtEnemy(enemiesInRange[0].transform.position);
                nextTimeShoot = Time.time + 1f / shootTime;
            }
        }
    }

    void ShootAtEnemy(Vector2 enemyPosition )
    {
        
        GameObject bulletInstance = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        Rigidbody2D rb2d = bulletInstance.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            Vector2 direction =(enemyPosition - (Vector2)bulletSpawn.position).normalized;

            rb2d.velocity = direction * bulletSpeed;
        }
    }
}
