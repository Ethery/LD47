using UnityEngine;

public class EchelleObject : MonoBehaviour
{
	public GameObject Player;
	public Vector3 offset = new Vector3(0, 0, 0);
	public bool isPlaced = false;
	private bool onPlayer = false;

	private void Update()
	{
		if (onPlayer)
		{
			transform.position = Player.transform.position + offset;
		}
		GetComponent<Rigidbody2D>().bodyType = onPlayer ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.attachedRigidbody.gameObject == Player.gameObject)
		{
			if (Input.GetKeyDown(KeyCode.E) && !GameManager.Player.canPositionEchelle)
			{
				onPlayer = !onPlayer;
			}
		}
	}
}