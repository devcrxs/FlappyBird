using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [Header("ExperienceDiamond")]
    [SerializeField] private float expEarn = 25f;
    [Header("")]
    [SerializeField] private Transform player;
    [SerializeField] private float moveAwayDistance = 2f;
    [SerializeField] private float moveAwayDuration = 0.3f;
    [SerializeField] private float followSpeed = 3f; // Velocidad de persecución
    [SerializeField] private float followDuration; // Duración de la persecución

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DiamondAnimation();
        }
    }

    public void DiamondAnimation()
    {
        Vector2 directionAway = ((Vector2)transform.position - (Vector2)player.position).normalized;
        Vector2 moveAwayPosition = (Vector2)transform.position + directionAway * moveAwayDistance;

        Sequence diamondSequence = DOTween.Sequence();

        // Moverse lejos del jugador
        diamondSequence.Append(transform.DOMove(moveAwayPosition, moveAwayDuration).SetEase(Ease.OutQuad));

        // Al completar el movimiento, empezar a seguir al jugador
        diamondSequence.AppendCallback(() => StartCoroutine(FollowPlayer())); // Cerrar paréntesis correctamente
    }

    private IEnumerator FollowPlayer()
    {
        float elapsedTime = 0f;

        while (elapsedTime < followDuration)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Al final de la persecución, destruir el diamante y sumar experiencia
        GameManager.instance.AddExperience(expEarn);
        UIManager.instance.UpdateExperience();
        Destroy(gameObject);
    }
}