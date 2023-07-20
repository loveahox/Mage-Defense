using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float PlayButton;
   

   public string newGameLevel = "Level1";

   public void NewGameButton()
   {
    SceneManager.LoadScene(newGameLevel);
   }

   public void exitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
