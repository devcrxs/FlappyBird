using UnityEngine;
public class AutoShootPlayer : MonoBehaviour
{
    [SerializeField]private float shootDistance = 10f;
    [SerializeField]private float shootTime = 1f;
    [SerializeField]private float nextTimeShoot = 1f;
    [SerializeField]private Transform bulletSpawn;
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
        var bullet = ObjectPooling.instance.GetPrefabFree();
        if (bullet == null) return;
        bullet.transform.position = bulletSpawn.position;
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().MoveBullet(enemyPosition);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
}
