using UnityEngine;

public class PositionEchelle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.attachedRigidbody.gameObject == GameManager.Player.gameObject)
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
}