using UnityEngine;

public class EchelleObject : MonoBehaviour
{
	public Vector3 PositionOffset = new Vector3(0, 0, 0);
	public Vector3 RotationOffset = new Vector3(0, 0, 0);
	public bool IsPlaced = false;
	public bool IsGrabbed = false;

	private void Update()
	{
		if (IsGrabbed || IsPlaced)
		{
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}
		transform.localScale = Vector3.one;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.attachedRigidbody != null && collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
		{
			GameManager.Player.Echelle = this;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.attachedRigidbody != null && collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
		{
			GameManager.Player.Echelle = this;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.attachedRigidbody != null && collision.attachedRigidbody.gameObject == GameManager.Player.gameObject && !IsGrabbed)
		{
			GameManager.Player.Echelle = null;
		}
	}
}