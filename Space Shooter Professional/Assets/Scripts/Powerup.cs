using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerUpSpeed = 3.0f;
    //private bool _isCollected = false;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);
     
            if (transform.position.y <= -6)
            {
                Destroy(this.gameObject);
            }
    


        //move down at a speed of 3 (adjust in inspector)
        //when we leave the screen, destroy this object
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //_isCollected = true;
            //Debug.Log("Collected: " + _isCollected);

            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.EnableTripleShot();
            }
            
            Destroy(this.gameObject);
        }
    }
    //OnTriggerCollision
    //Only be collectable by the Player (HINT: Use Tags)
    //on collected, destroy
}
