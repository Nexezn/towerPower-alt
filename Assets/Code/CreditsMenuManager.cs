using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuManager : MonoBehaviour
{
    public void OnHomeButtonClicked(string sceneName)
    {
        if(sceneName != null) 
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
