using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public string newGameLevel = "Level1";
   public void NewGameButton()
   {
    SceneManager.LoadScene(newGameLevel);
   }
}
