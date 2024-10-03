using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;   
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private FloatingJoystick joystick;
    private Vector2 movement;
    private float joystickDeadZone = 0.1f;
    [SerializeField] private Transform pivotArrow;
    [SerializeField] private float distanceArrowPlayer;


    private void Update()
    {
        
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        FlipPlayer();
        if (movement.magnitude <= 0.1f)
        {
            rb2d.velocity = Vector2.zero;
        }
        // esta parte del codigo es para que la flecha vaya donde el joystick va
        ArrowMove();
    }

    private void ArrowMove()
    {
        if (Mathf.Abs(movement.x) > joystickDeadZone || Mathf.Abs(movement.y) > joystickDeadZone)
        {

            Vector3 direction = new Vector3(movement.x, movement.y, 0);

            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * distanceArrowPlayer;
            pivotArrow.position = transform.position + offset;

           
            pivotArrow.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveSpeed * movement * Time.fixedDeltaTime);  //fisicas del movimiento del jugador
    }

    private void FlipPlayer()
    {
        if (movement.x == 0) return;
        var scale = transform.localScale;
        scale.x = movement.x > 0 ? 1 : -1;
        transform.localScale = scale;
        pivotArrow.localScale = scale;
    }
}
