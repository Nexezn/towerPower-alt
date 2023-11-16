using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuHandler : MonoBehaviour
{
     [Header("References")]
     [SerializeField] private GameObject creditsMenuScreen;

     public void PlayGame(){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }

     public void QuitGame(){
          Application.Quit();
     }

     public void GoToCredits(){
        creditsMenuScreen.SetActive(true);
    }

    public void ReturnFromCredits(){
        creditsMenuScreen.SetActive(false);
    }
}
