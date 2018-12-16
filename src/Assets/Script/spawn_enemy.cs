using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour {
	
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D pCol)
	{
		if(pCol.CompareTag("Player"))
		{
			Instantiate(enemy, this.transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
