using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool _isGameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1); //Current game scene
        }
        //if escape key is pressed, quit application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //if end key is pressed, go back to new game screen
        else if (Input.GetKeyDown(KeyCode.End))
        {
            SceneManager.LoadScene(0);
        }
            
    }
  
    public void GameOver()
    {
        _isGameOver = true;
    }


}
