using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuManager : MonoBehaviour
{
    public void OnBackButtonClicked(string sceneName)
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
