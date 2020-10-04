using UnityEngine;

public class EndObject : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
		{
			Debug.Log("Fin du niveau !");
			UIManager.Show(UIManager.EPageType.WinScreen, true);
			GameManager.Player.CanMove = false;
		}
	}
}