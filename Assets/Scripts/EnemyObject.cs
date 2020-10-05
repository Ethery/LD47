using UnityEngine;

public class EnemyObject : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject == GameManager.Player.gameObject)
		{
			GameManager.Player.TakeDamage();
		}
	}
}