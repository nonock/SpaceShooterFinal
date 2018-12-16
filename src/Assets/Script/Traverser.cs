using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traverser : MonoBehaviour {

	private GameObject player;
	private EdgeCollider2D collider;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		collider = this.GetComponent<EdgeCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y < this.transform.position.y)
		{
			collider.enabled = false;
		}
		else{
			collider.enabled = true;
		}
			
	
	}
}
