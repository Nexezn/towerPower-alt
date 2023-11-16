using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuHandler : MonoBehaviour
{
     public void PlayGame(){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }

     public void QuitGame(){
          Application.Quit();
     }

     public void OnSettingsButtonClicked(string sceneName)
     {
         if (sceneName != null)
         {
             SceneManager.LoadScene(sceneName);
         }
     }

     public void OnCreditsButtonClicked(string sceneName)
     {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
