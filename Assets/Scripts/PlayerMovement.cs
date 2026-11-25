using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3.5f;
    public float sprintSpeed = 6f;
    public float currentNoise = 0f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(x, y).normalized;

        if (moveInput == Vector2.zero)
        {
            currentSpeed = 0f;
            currentNoise = 0f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
            currentNoise = 6f;
        }
        else
        {
            currentSpeed = walkSpeed;
            currentNoise = 2.5f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * currentSpeed;
    }

    void OnDrawGizmosSelected()
    {
        if (currentNoise <= 0f) return;

        if (currentSpeed == sprintSpeed) Gizmos.color = Color.red;
        else Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, currentNoise);
    }
}