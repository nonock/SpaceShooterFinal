using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_space : MonoBehaviour {

	float alpha = 0.000f;
	bool isZooming = false;
	public Texture2D fadeTexture;


float factor  = 0.0001F;
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3(factor,factor, 0);
		if(isZooming){
			alpha+= 0.01F;
		}
	}

	public void zoom(){
				factor = 0.01F;
				isZooming = true;
	}

	void OnGUI()
	{
	GUI.color = new Color(1,1,1, alpha);
	GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fadeTexture);
	}
}
