using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    private float _rotateSpeed = 19.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
        //transform.Rotate(0, 0, 2);
    }
}
