using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickerPreventer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public static clickerPreventer main;



    public bool mouse_over_PMenu = false;
    // Start is called before the first frame update

    private void Awake(){
        main = this;
    }
    public void OnPointerEnter(PointerEventData eventData){
        mouse_over_PMenu = true;
        //UIHandler.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        mouse_over_PMenu = false;
        //UIHandler.main.SetHoveringState(false);
    }
}
