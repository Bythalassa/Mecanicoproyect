using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDir =
            new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            ).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * speed;

        // cs: Muévete en la dirección moveDir, a esta velocidad (speed)".
        // motor mediante el wrapper de RG 2D: get value FixedUpdate.
    }

}
