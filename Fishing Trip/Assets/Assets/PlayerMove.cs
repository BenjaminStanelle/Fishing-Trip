using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1;
    public float jumpForce = 1;
    private Rigidbody2D __rigidbody;
  

    private void Start()
    {
        __rigidbody = GetComponent<Rigidbody2D>();
    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump") && Mathf.Abs(__rigidbody.velocity.y)<0.001f)
        {
            __rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }

    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * moveSpeed;
        Jump();

    }
}