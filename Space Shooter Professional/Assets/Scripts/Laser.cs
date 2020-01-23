using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    // speed variable 8
    [SerializeField]
    private float _laserSpeed = 8.0f;

    // Update is called once per frame
    void Update()
    {
     
        transform.Translate(Vector3.up *_laserSpeed * Time.deltaTime);
        if (transform.position.y >= 8.0f)
        {
            //if object has parent, destroy it too
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
            
        }
    }
}
