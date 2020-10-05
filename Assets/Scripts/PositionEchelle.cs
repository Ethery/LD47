using UnityEngine;

public class PositionEchelle : MonoBehaviour
{
	public GameObject Echelle;

	private void Start()
	{
		//Echelle = GameObject.Find("Echelle");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
		{
			GameManager.Player.canPositionEchelle = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
		{
			GameManager.Player.canPositionEchelle = false;
		}
	}

	private void Update()
	{
		if (GameManager.Player.canPositionEchelle)
		{
			//transform.SetPositionAndRotation();
		}
	}
}