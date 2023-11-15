using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject helpMenuScreen;
    
    public void FacebookURL(){
        Application.OpenURL("https://www.facebook.com");
        Debug.Log("Link Opened");
    }

    public void InstagramURL(){
        Application.OpenURL("https://www.instagram.com");
        Debug.Log("Link Opened");
    }

    public void XURL(){
        Application.OpenURL("https://twitter.com");
        Debug.Log("Link Opened");
    }

    public void YoutubeURL(){
        Application.OpenURL("https://www.youtube.com");
        Debug.Log("Link Opened");
    }

    public void GmailURL(){
        Application.OpenURL("https://mail.google.com");
        Debug.Log("Link Opened");
    }

}
