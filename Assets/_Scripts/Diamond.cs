using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Diamond : MonoBehaviour
{
    [Header("ExperienceDiamond")]
    [SerializeField] private float expEarn = 25f;
    
    [Header("AnimationInPlayer")]
    private Transform _player;
    [SerializeField] private float moveAwayDistance = 2f;
    [SerializeField] private float followSpeed = 3f; 
    [SerializeField] private float followDuration; 
    private CircleCollider2D _circleCollider;
    
    [Header("AnimationIdle")] 
    [SerializeField] private float diamondDuration;
    [SerializeField] private float diamondDistance;
    

    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        DiamondIdle();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _circleCollider.enabled = false;
        transform.DOKill();
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

    private void DiamondIdle()
    {
        if (_circleCollider.enabled)
        {
            float newPositionY = transform.position.y;
            float offSetY = Random.Range(-diamondDistance, diamondDistance);
            newPositionY += offSetY;

            transform.DOMoveY(newPositionY, diamondDuration).OnComplete(() =>
            {
                transform.DOMoveY(transform.position.y - offSetY, diamondDuration).OnComplete(() =>
                {
                    DiamondIdle();
                }); 
            });  
        }
        else
        {
            transform.DOKill();
        }
        
    }
}