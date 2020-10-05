using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider), typeof(Animator))]
public class JumpPlayer : MonoBehaviour
{
	private Rigidbody2D rb;
	private Animator anim;
	public float forceSaut = 5;
	public float MoveSpeed = 5f;
	public float runMultiplicator = 2;
	public bool canPositionEchelle => Place != null;
	public EchelleObject Echelle;
	public PositionEchelle Place;

	[HideInInspector]
	public bool CanMove = true;
	public bool ClimbingToLadder;

	public bool IsGrounded { get; private set; }

	private void Awake()
	{
		CanMove = true;
		GameManager.Player = this;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	private void Update()
	{
		if (!ClimbingToLadder)
			UpdateMovements();
		else
		{
			if (CanMove)
			{
				//GRIMPER A L'ECHELLE
			}
		}

		if (!CanMove)
			return;

		if (Echelle != null && Input.GetKeyDown(KeyCode.E))
		{
			if (Echelle.isPlaced)
			{
				ClimbingToLadder = !ClimbingToLadder;
			}

			if (Echelle.IsGrabbed && canPositionEchelle)
			{
				Echelle.transform.SetParent(Place.transform);
				Echelle.isPlaced = true;
			}
			else
			{
				Echelle.IsGrabbed = !Echelle.IsGrabbed;
				if (Echelle.IsGrabbed)
					Echelle.transform.SetParent(transform);
				else
				{
					Echelle.transform.SetParent(null);
				}
			}
		}
	}

	public void UpdateMovements()
	{
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded && CanMove)
		{
			IsGrounded = false;
			rb.AddForce(transform.up * forceSaut, ForceMode2D.Impulse);
		}

		Vector3 ZeroRotVelocity = transform.InverseTransformVector(new Vector3(rb.velocity.x, rb.velocity.y, 0));

		ZeroRotVelocity.x = 0;

		if (Input.GetKey(KeyCode.D) && CanMove)
		{
			GetComponent<SpriteRenderer>().flipX = false;
			ZeroRotVelocity.x = MoveSpeed;
		}
		if (Input.GetKey(KeyCode.Q) && CanMove)
		{
			GetComponent<SpriteRenderer>().flipX = true;
			ZeroRotVelocity.x = -MoveSpeed;
		}
		if (Input.GetKey(KeyCode.LeftShift) && CanMove)
		{
			ZeroRotVelocity.x *= runMultiplicator;
		}
		float maxSpeed = MoveSpeed * runMultiplicator;
		float lerpedHorizontalSpeed = (Mathf.InverseLerp(-maxSpeed, maxSpeed, ZeroRotVelocity.x) * 2) - 1;
		anim.SetFloat("HorizontalSpeed", lerpedHorizontalSpeed);
		anim.SetFloat("VerticalSpeed", ZeroRotVelocity.y);
		anim.SetBool("IsGrounded", IsGrounded);
		rb.velocity = transform.TransformVector(ZeroRotVelocity);

		Vector3 CenterOfPlanet = Vector3.zero;
		Vector3 downDirection = (CenterOfPlanet - transform.position).normalized;

		transform.rotation = Quaternion.LookRotation(Vector3.forward, -downDirection);
		Physics2D.gravity = downDirection * 9.81f;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			IsGrounded = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			IsGrounded = false;
		}
	}

	public void TakeDamage()
	{
		Debug.Log("Cest la muerte !");
		CanMove = false;
		StartCoroutine(TakeDamageRoutine());
	}

	public IEnumerator TakeDamageRoutine()
	{
		anim.SetTrigger("TakeDamage");
		yield return new WaitForSeconds(2f);
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