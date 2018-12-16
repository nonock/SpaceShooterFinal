using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_ennemy_behavior : MonoBehaviour {
	
	public float speed;
	public GameObject explosion;
	public GameObject bullet;
	private int shootingTime;
	public int health;
	private GameObject aPlayer;
	public int sens;
	//public GameObject aMurInvisible;
	


	// Use this for initialization
	void Start () {
		//health = 1;
		shootingTime = 90;
		aPlayer = GameObject.Find("Player");
		//aMurInvisible = GameObject.Find("rebord_invisible");
	}
	
	// Update is called once per frame
	void Update () {
		if(aPlayer.transform.position.x < this.transform.position.x)
		{
			sens = -1;
			this.transform.localScale = new Vector3(-2.607F, 2.607F, 2.607F);
			this.transform.Translate(new Vector2(-0.1f, 0)*speed*Time.deltaTime);
		}
		else if (aPlayer.transform.position.x > this.transform.position.x)
		{
			sens = 1;
			this.transform.localScale = new Vector3(2.607F, 2.607F, 2.607F);
			this.transform.Translate(new Vector2(0.1f, 0)*speed*Time.deltaTime);
			
		}
		
		if(shootingTime<=0){
			Shoot();
			shootingTime = 90;
		}
		shootingTime--;
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Bullet")||col.CompareTag("grenade")||col.CompareTag("Laser"))
		{
			health--;
			if(health <= 0)
			{
				//if(aMurInvisible!=null){Destroy(aMurInvisible);}
				Destroy(Instantiate(explosion, this.transform.position, Quaternion.identity),0.6f);
				Destroy(this.gameObject);
			}
		}
		else if(col.CompareTag("Player")){
			col.GetComponent<Move>().health--;
		}
	} 
	
	void OnTriggerStay2D(Collider2D col){
		if(col.CompareTag("Bullet")||col.CompareTag("grenade")||col.CompareTag("Laser"))
		{
			Destroy(Instantiate(explosion, this.transform.position, Quaternion.identity),0.6f);
			Destroy(this.gameObject);
		}
		else if(col.CompareTag("Player")){
			col.GetComponent<Move>().health--;
		}
	} 
	
	void Shoot(){
			
			GameObject bulletSens = Instantiate(bullet, new Vector2((this.transform.position.x + sens*1.7f), this.transform.position.y-0.1f), Quaternion.identity);
			bulletSens.GetComponent<BulletBehavior>().sens  = sens;
	}
	
}
