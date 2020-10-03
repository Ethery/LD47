using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log(collision.gameObject.name);
		if (collision.gameObject == GameManager.Player.gameObject)
		{
			GameManager.Player.TakeDamage();
		}
	}
}