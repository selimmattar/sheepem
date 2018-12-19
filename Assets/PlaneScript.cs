using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour {
    public Texture myTexture;
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.SetTexture("Element 0",myTexture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
