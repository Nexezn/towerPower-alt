using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool mouse_over = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (mouse_over) Debug.Log("Mouse over: " + name);
    }

    public void OnPointerEnter(PointerEventData eventData){
        mouse_over = true;
        UIHandler.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        mouse_over = false;
        UIHandler.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }
}
