using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject pauseMenuScreen;
    [SerializeField] private GameObject settingsMenuScreen;
    [SerializeField] private GameObject helpMenuScreen;

    public static UIHandler main;
    private bool isHoveringUI;

    private void Awake(){
        main = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Prevents a bug when switching scene.
        Time.timeScale = 1;
    }

    public void SetHoveringState(bool state){
        isHoveringUI = state;
    }

    public bool IsHoveringUI(){
        return isHoveringUI;
    }

    public void PauseGame(){
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    
    public void ResumeGame(){

        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GoToSettings(){
        pauseMenuScreen.SetActive(false);
        settingsMenuScreen.SetActive(true);
    }

    public void ReturnFromSettings(){
        settingsMenuScreen.SetActive(false);
        pauseMenuScreen.SetActive(true);
    }

    public void GoToHelp(){
        pauseMenuScreen.SetActive(false);
        helpMenuScreen.SetActive(true);
    }

    public void ReturnFromHelp(){
        helpMenuScreen.SetActive(false);
        pauseMenuScreen.SetActive(true);
    }

    public void GoToCredits(string sceneName)
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
