using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    static public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { // update runs based on frame rate.
        // fixed update based on physics engine.
        this.transform.Rotate(0f,0f, speed);
    }
}
