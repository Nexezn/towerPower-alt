using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeHandler : MonoBehaviour
{
   
    [Header("References")]
    [SerializeField] Animator anim;

    private bool isMenuOpen = false;

    public void ToggleMenu(){
        isMenuOpen = !isMenuOpen;
        anim.SetBool("menuOpen", isMenuOpen);
    }
    public void setSelected(){

    }

    public void timeSetHalf(){
        Time.timeScale = 0.5f;
    }

    public void timeSetNormal(){
        Time.timeScale = 1;
    }

    public void timeSetDouble(){
        Time.timeScale = 2;
    }

    public void timeSetTen(){
        Time.timeScale = 10;
    }
}
