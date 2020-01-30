using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _enemySpeed = 4.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters/second
        //if bottom of screen, respawn at top with a new random x position
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if (transform.position.y <= -5.5)
        {
            float randomX = Random.Range(-9.4f, 9.4f);
            transform.position = new Vector3(randomX, 7.2f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if other is Player, damage the player, destroy us
        //if other is laser, destroy laser, destroy us
        if (other.tag == "Player")
        {
            //damage player
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //Add 10 to score
            Destroy(this.gameObject);

        }

    }
}
