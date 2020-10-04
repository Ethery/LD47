using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider))]
public class JumpPlayer : MonoBehaviour
{
	private Rigidbody2D rb;
	public float forceSaut = 5;
	public float MoveSpeed = 5f;
	public float runMultiplicator = 2;

	public bool IsGrounded { get; private set; }

	private void Awake()
	{
		GameManager.Player = this;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
		{
			IsGrounded = false;
			rb.AddForce(transform.up * forceSaut, ForceMode2D.Impulse);
		}

		Vector3 ZeroRotVelocity = transform.InverseTransformVector(new Vector3(rb.velocity.x, rb.velocity.y, 0));

		ZeroRotVelocity.x = 0;

		if (Input.GetKey(KeyCode.D))
		{
			ZeroRotVelocity.x = MoveSpeed;
		}
		if (Input.GetKey(KeyCode.Q))
		{
			ZeroRotVelocity.x = -MoveSpeed;
		}
		if (Input.GetKey(KeyCode.LeftShift))
		{
			ZeroRotVelocity.x *= runMultiplicator;
		}
		rb.velocity = transform.TransformVector(ZeroRotVelocity);

		Vector3 CenterOfPlanet = Vector3.zero;
		Vector3 downDirection = (CenterOfPlanet - transform.position).normalized;

		transform.rotation = Quaternion.LookRotation(Vector3.forward, -downDirection);
		Physics2D.gravity = downDirection * 9.81f;
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
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
		Debug.Log("Cest la muerte !");
		UIManager.Show(UIManager.EPageType.DeathScreen, true);
	}

	private void OnDestroy()
	{
		if (GameManager.Player == this)
		{
			GameManager.Player = null;
		}
	}
}