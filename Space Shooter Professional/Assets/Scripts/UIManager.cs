using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to Text
    [SerializeField]
    private Text _scoreText;
    // Start is called before the first frame update
    private Player _player;
    private int _playerScore;

    void Start()
    {
        //assign text component to the handle
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        //_player = GameObject.Find("Player").GetComponent<Player>();
        _playerScore = Player.
    }
}
