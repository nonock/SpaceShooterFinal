using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose_weapon : MonoBehaviour {
	
	public Move player;
	public int weapon_index;
	public GameObject flame_thrower;
	public GameObject grenade_launcher;
	public GameObject grenade;
	public GameObject laser;
	public int nombreArme;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("Player").GetComponent<Move>();
		weapon_index = 0;
		flame_thrower.SetActive(false);
		grenade_launcher.SetActive(false);
		laser.SetActive(false);    
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown("t")){
			
			weapon_index = ((weapon_index + 1)% nombreArme);
		}
		
		
		
			switch(weapon_index)
			{
				case 0 :
				{
		            flame_thrower.SetActive(false);
					grenade_launcher.SetActive(false);
					laser.SetActive(false);
					if(Input.GetButtonDown("Fire2")){
						
						Shoot();//semi-auto
					}
					break;

				}
				case 1 :
				{
					grenade_launcher.SetActive(false);
					laser.SetActive(false);
		            flame_thrower.SetActive(true);
					if(Input.GetButton("Fire2"))
					{
						flame_thrower.GetComponent<Animator>().SetTrigger("attack");
					}
					break;
				}
				case 2 :
				{
					flame_thrower.SetActive(false);
					laser.SetActive(false);
					grenade_launcher.SetActive(true);
					if(Input.GetButtonDown("Fire2")){
						Instantiate(grenade, grenade_launcher.transform.position, Quaternion.identity).GetComponent<Grenade_Behaviour>().sens = player.sens;
						
						}
					break;
				}
				case 3 :
				{
						
					flame_thrower.SetActive(false);
					grenade_launcher.SetActive(false);
					laser.SetActive(false);
					if(Input.GetButton("Fire2")){
						//Debug.Log("a belette has been shot");
						this.Shoot();
						//subMachineGun_shoot();
					}
					break;	
				}
				
				case 4 :
				{
					flame_thrower.SetActive(false);		
					grenade_launcher.SetActive(false);
					
					if(Input.GetButton("Fire2")){
						laser.SetActive(true);
					}
					else{
						laser.SetActive(false);
					}
					break;
				}
		
			}
			
			
		
	}

	
	public void Shoot()
	{	
		
			
		GameObject bulletSens = Instantiate(player.bullet, new Vector2(this.transform.position.x + 0.7F*player.sens, this.transform.position.y + 0.05F), Quaternion.identity);
		if(weapon_index == 4)
		{bulletSens.GetComponent<SpriteRenderer>().color = Color.red;}
		bulletSens.GetComponent<BulletBehavior>().sens  = player.sens;
	}
	
	
}
