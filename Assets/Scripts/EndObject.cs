using UnityEngine;

public class EndObject : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
		{
			Debug.Log("Fin du niveau !");
			GameManager.Player.CanMove = false;
			if (GameManager.Instance.HasNextLevel())
			{
				NextLevel();
			}
			else
			{
				EndGame();
			}
		}
	}

	public void NextLevel()
	{
		UIManager.Show(UIManager.EPageType.NextLevel, true);
	}

	public void EndGame()
	{
		UIManager.Show(UIManager.EPageType.WinScreen, true);
	}
}