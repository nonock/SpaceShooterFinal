using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_script : MonoBehaviour {

	public background_space aScript;
 	private float timer = 0; 
 	private float timerMax = 0;

	public void StartGame() 
	{
	
	AudioSource audioData = GetComponent<AudioSource>();
	audioData.Play(0);
	aScript.zoom();

	StartCoroutine(runGame());

	}

	IEnumerator runGame()
    {
		yield return new WaitForSeconds(2); 
		SceneManager.LoadScene("explicationMonde");
	 }
	public void QuitGame() 
	{
	  print("By");
   // SceneManager.LoadScene("lvl");
	}

}
