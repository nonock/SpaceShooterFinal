using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class king_enemy_behaviour : MonoBehaviour {
	
	public float speed;
	public GameObject explosion;
	public GameObject bullet;
	private int shootingTime;
	public int health;
	private GameObject aPlayer;
	public GameObject aMurInvisible;
	public int sens;

	void Start () {
		//health = 1;
		shootingTime = 90;
		aPlayer = GameObject.Find("Player");
		aMurInvisible = GameObject.Find("rebord_invisible");
	}
	
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
		
		if(this.transform.position.y < -30)//////////////////////////////////////////
		{
			Destroy(this.gameObject);
			Destroy(aMurInvisible);
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Bullet")||col.CompareTag("grenade")||col.CompareTag("Laser"))
		{
			//print("print perd vie");
			health--;
			//print(health);
			if(health <= 0)
			{
				//print("vie éro");
				if(aMurInvisible != null)
				{
					//Debug.Log("mur pas nul");
					Destroy(aMurInvisible);
				}
				Destroy(Instantiate(explosion, this.transform.position, Quaternion.identity),0.6f);
				Destroy(this.gameObject);
			}
		}
		else if(col.CompareTag("Player")){
			col.GetComponent<Move>().health--;
		}
	} 
	
	void OnTriggerStay2D(Collider2D col){
		/*if(col.CompareTag("Bullet")||col.CompareTag("grenade")||col.CompareTag("Laser"))
		{
			Destroy(Instantiate(explosion, this.transform.position, Quaternion.identity),0.6f);
			Destroy(this.gameObject);
		}
		else if(col.CompareTag("Player")){
			col.GetComponent<Move>().health--;
		}*/
		if(col.CompareTag("Bullet")||col.CompareTag("grenade")||col.CompareTag("Laser"))
		{
			
			health--;
			if(health <= 0)
			{
				if(aMurInvisible != null)
				{
					Destroy(aMurInvisible);
				}
				Destroy(Instantiate(explosion, this.transform.position, Quaternion.identity),0.6f);
				Destroy(this.gameObject);
			}
		}
		else if(col.CompareTag("Player")){
			col.GetComponent<Move>().health--;
		}//fincc
	}
	
	void Shoot(){
			GameObject bulletSens = Instantiate(bullet, new Vector2(this.transform.position.x + (1.7f)*sens, this.transform.position.y-0.1f), Quaternion.identity);
			bulletSens.GetComponent<BulletBehavior>().sens  = sens;
	}
}
