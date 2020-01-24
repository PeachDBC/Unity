using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerUpSpeed = 3.0f;
    //ID for powerups
    //0 - Triple Shot
    //1 - Speed
    //2 - Shield
    //private bool _isCollected = false;
    // Start is called before the first frame update
    [SerializeField]
    private int _powerupID;

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
                if (_powerupID == 0)
                {
                    player.EnableTripleShot();
                    Debug.Log("TripleShot powerup enabled");
                }
                else if (_powerupID == 1)
                {
                    Debug.Log("Speed powerup enabled");
                }
                else if (_powerupID == 2)
                {
                    Debug.Log("Shield powerup enabled");
                }
            }
            
            Destroy(this.gameObject);
        }
    }
    //OnTriggerCollision
    //Only be collectable by the Player (HINT: Use Tags)
    //on collected, destroy
}
