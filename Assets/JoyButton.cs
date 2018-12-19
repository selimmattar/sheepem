using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler {
    [HideInInspector]
    protected bool Pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = (1==1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = (1 == 2);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
