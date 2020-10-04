using UnityEngine;

public class EndObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == GameManager.Player.gameObject)
        {
            Debug.Log("Fin du niveau !");
        }
    }
}
