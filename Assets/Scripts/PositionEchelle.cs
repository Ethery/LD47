using UnityEngine;

public class PositionEchelle : MonoBehaviour
{
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
        {
            GameManager.Player.Place = this;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
        {
            GameManager.Player.Place = this;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
        {
            GameManager.Player.Place = null;
        }
    }
}