using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotation : MonoBehaviour
{
    public float rotationSpeed;


    void Update()
    {
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}
