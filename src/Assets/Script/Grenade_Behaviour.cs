using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Behaviour : MonoBehaviour {
	
	public int sens;
	public float speed;
	public int taille_max;
	public Rigidbody2D rigidbody;
	public bool touchedSomething;
	public GameObject explosion;
	public int onVerraY;
	public int onVerraX;
	public CircleCollider2D circle;
	
	private bool hasExploded;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(new Vector2(0, onVerraY)*speed*Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce(new Vector2(onVerraX*sens, 0)*speed*Time.deltaTime);
		if(touchedSomething)
		{
			if(circle.radius<=1)
				circle.radius+=0.1f;
			if(!hasExploded){
			    Destroy(Instantiate(explosion, this.transform.position, Quaternion.identity),0.5f);
			    Destroy(this.gameObject,0.5f);
				this.GetComponent<Animator>().enabled = false;
				this.GetComponent<SpriteRenderer>().sprite = null;
				hasExploded = true;
			}
			//#onverraplustard
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(!col.CompareTag("Player") && !col.CompareTag("grenade"))
		    touchedSomething = true;
	}
}
