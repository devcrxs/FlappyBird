using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;   
    [SerializeField] private Rigidbody2D rb2d;
    private FloatingJoystick _joystick;
    private Vector2 _movement;
    private const float JoystickDeadZone = 0.1f;
    [SerializeField] private Transform pivotArrow;
    [SerializeField] private float distanceArrowPlayer;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    
    public Vector2 Movement => _movement;

    private void Start()
    {
        _joystick = FindObjectOfType<FloatingJoystick>();
    }

    private void Update()
    {
        SetMovementInput();
        ArrowMove();
        rb2d.velocity = _movement.magnitude <= 0.1f ? Vector2.zero: rb2d.velocity;
        animator.SetFloat("Velocity", _movement.magnitude);
    }

    private void SetMovementInput()
    {
        _movement.x = _joystick.Horizontal;
        _movement.y = _joystick.Vertical;
    }

    private void ArrowMove()
    {
        if (Mathf.Abs(_movement.x) > JoystickDeadZone || Mathf.Abs(_movement.y) > JoystickDeadZone)
        {

            Vector3 direction = new Vector3(_movement.x, _movement.y, 0);

            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * distanceArrowPlayer;
            pivotArrow.position = transform.position + offset;

           
            pivotArrow.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveSpeed * _movement * Time.fixedDeltaTime);  //fisicas del movimiento del jugador
    }
}
