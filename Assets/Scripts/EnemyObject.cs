using UnityEngine;

public class EnemyObject : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == GameManager.Player)
		{
			GameManager.Player.TakeDamage();
		}
	}
}