using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to Text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _gameOverText;


    // Start is called before the first frame update

    void Start()
    {
        //assign text component to the handle
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
    }
    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }
    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _liveSprites[currentLives];
        if (currentLives == 0)
        {
            StartCoroutine(FlashTextCoroutine());
           
        }

    }
    IEnumerator FlashTextCoroutine()
    {
        while (true)
        {
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
