using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider))]
public class JumpPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forceSaut = 5;

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("z") && IsGrounded)
        {
            Debug.Log("Saut");
            IsGrounded = false;
            rb.AddForce(new Vector2(0, forceSaut), ForceMode2D.Impulse);    
        }   
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Prend des dommages");
    }
}
