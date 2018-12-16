using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
	
	public int sens;
	public float speed;
	public bool isEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector2(sens, 0)*2.5F*speed*Time.deltaTime);
		Destroy(this.gameObject, 2);
	}
	
	void OnTriggerEnter2D(Collider2D pCol){
		if(isEnemy && pCol.CompareTag("Player"))
			pCol.GetComponent<Move>().health--;
		Destroy(this.gameObject);
	}
}