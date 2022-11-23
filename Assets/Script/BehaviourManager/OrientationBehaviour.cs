using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 orientation = Input.acceleration;
        Physics2D.gravity = new Vector2(orientation.x, Physics2D.gravity.y);
    }
}
