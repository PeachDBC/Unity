﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _enemySpeed = 4.0f;
    private Player _player;
    private Animator _anim;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _enemyDestroyed;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is NULL.");
        }
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Animator is NULL.");
        }
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
            //trigger the animation
            _anim.SetTrigger("OnEnemyDeath");
            _enemySpeed = 0; //stop moving when destroyed
            AudioSource.PlayClipAtPoint(_enemyDestroyed, transform.position, 1.0f);
            Destroy(this.gameObject, 2.8f);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.ScoreKeeper(10);
            }
            //trigger anim
            _anim.SetTrigger("OnEnemyDeath");
            _enemySpeed = 0;
            Destroy(this.gameObject, 2.8f);

        }

    }
}
