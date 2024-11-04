using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [Header("ExperienceDiamond")]
    [SerializeField] private float expEarn = 25f;
    [Header("")]
    private Transform _player;
    [SerializeField] private float moveAwayDistance = 2f;
    [SerializeField] private float followSpeed = 3f; // Velocidad de persecución
    [SerializeField] private float followDuration; // Duración de la persecución
    private CircleCollider2D _circleCollider;

    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _circleCollider.enabled = false;
        DiamondAnimation();
    }

    private void DiamondAnimation()
    {
        Vector2 directionAway = ((Vector2)transform.position - (Vector2)_player.position).normalized;
        Vector2 moveAwayPosition = (Vector2)transform.position + directionAway * moveAwayDistance;
        transform.DOMove(moveAwayPosition, followDuration).OnComplete(() =>
        {
            StartCoroutine(FollowPlayer());
        } );
    }
    
    private IEnumerator FollowPlayer()
    {
        while (Vector2.Distance(transform.position, _player.position) > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, followSpeed * Time.deltaTime);
            yield return null;
        }
        GameManager.instance.AddExperience(expEarn);
        UIManager.instance.UpdateExperience();
        Destroy(gameObject);
    }
}