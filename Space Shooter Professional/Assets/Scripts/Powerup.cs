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

                switch(_powerupID)
                {
                    case 0:
                        player.EnableTripleShot();
                        break;
                    case 1:
                        player.EnableSpeedPowerup();
                        break;
                    case 2:
                        player.EnableShieldsPowerup();
                        break;
                    default:
                        Debug.Log("Default amount");
                        break;
;                }
                

            }
            
            Destroy(this.gameObject);
        }
    }
    //OnTriggerCollision
    //Only be collectable by the Player (HINT: Use Tags)
    //on collected, destroy
}
