using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadingTime : MonoBehaviour {

	float alpha = 1;
	bool tr = false;
	public Texture2D fadeTexture;
	public string level2load;


float factor  = 0.0001F;
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		
		if(tr){
			alpha+= 0.07F;
		}
		else {
			if(alpha >= 0)
				alpha-= 0.07F;
		}
			//print (alpha);
			StartCoroutine(transition());


	}

	IEnumerator transition()
    {
		yield return new WaitForSeconds(2); 
		tr = true;
		StartCoroutine(loadLevel());

	 }

	IEnumerator loadLevel()
    {
		yield return new WaitForSeconds(1); 
		SceneManager.LoadScene(level2load);

	}

	void OnGUI()
	{
	GUI.color = new Color(1,1,1, alpha);
	GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fadeTexture);
	}
}
