using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;   
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private FloatingJoystick joystick;
    private Vector2 movement;
    
    private void Update()
    {
        //movement.x = Input.GetAxis("Horizontal");   //movimiento x, y del player
        //movement.y = Input.GetAxis("Vertical");
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        if (movement.magnitude <= 0.1f)
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveSpeed * movement * Time.fixedDeltaTime);  //fisicas del movimiento del jugador
    }
}
