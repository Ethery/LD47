using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceSaut = 20;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("z"))
        {
            Debug.Log("Saut");
            rb.AddForce(new Vector2(0, forceSaut), ForceMode2D.Impulse);    
        }   
    }
}
