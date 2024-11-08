using UnityEngine;
public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private Transform pivotArrow;
    [SerializeField] private Transform barsPlayer;
    private PlayerMove _playerMove;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        FlipPlayer();
    }

    private void FlipPlayer()
    {
        if (_playerMove.Movement.x == 0) return;
        var scale = transform.localScale;
        scale.x = _playerMove.Movement.x > 0 ? 1 : -1;
        transform.localScale = scale;
        pivotArrow.localScale = scale;
        barsPlayer.localScale = scale;
    }
}
