using System;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Animator bulletAnimator;

    public void MoveBullet(Vector2 target)
    {
        var targetDir = target - (Vector2)transform.position;
        float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector2 direction =(target - (Vector2)transform.position).normalized;
        rb2D.velocity = direction * bulletSpeed;
        bulletAnimator.Play("Bullet");
        Invoke(nameof(HideBullet), 0.5f);
    }

    private void HideBullet()
    {
        ObjectPoolingManager.instance.AddBulletsToAvaible(gameObject);
        rb2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        HideBullet();
    }
}
