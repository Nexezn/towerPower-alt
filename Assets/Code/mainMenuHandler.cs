using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuHandler : MonoBehaviour
{
     [Header("References")]
     [SerializeField] private GameObject settingsMenuScreen;

     public void PlayGame(){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }

     public void QuitGame(){
          Application.Quit();
     }

     public void GoToSettings(){
        settingsMenuScreen.SetActive(true);
    }

    public void ReturnFromSettings(){
        settingsMenuScreen.SetActive(false);
    }
}
