using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {
	
	public float speed;
	public bool isGrounded;
	public float jumpPower;
	public GameObject bullet;
	public int sens;
	public Animator anim;
	public bool isMoving;
	public int SceneNumber;
	public int health;
	public Rigidbody2D aRigidBody;
	public int yminniveau;
	public int xmaxniveau;
    Scene m_Scene;

    //Ici
    public Texture2D fadeTexture;
    private float alpha = 1;
    bool tr = false;

    //Ici
    private string level2load;

    private Animator aAnimPanel;

	// Use this for initialization
	void Start () {
		this.speed = 2;
		this.sens = 1;
		anim = this.GetComponent<Animator>();
		this.health = 3;
		this.aRigidBody = this.GetComponent<Rigidbody2D>();
		aAnimPanel = GameObject.Find("Panel").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //Ici
        if (tr)
        {
            alpha += 0.07F;
        }
        else
        {
            if (alpha > 0)
                alpha -= 0.07F;
        }

        this.transform.localScale = new Vector3(sens*0.3283063F, 0.3283063F, 0.3283063F);
		anim.SetBool("isMoving", isMoving);
		
		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			//this.transform.Translate(new Vector2(0, jumpPower));
			aRigidBody.AddForce(new Vector2(0, jumpPower));
		}
		 
	    if(this.transform.position.y < yminniveau || health<=0 )
		{
			aAnimPanel.SetBool("isDead", true);
			anim.SetBool("isDead", true);
			StartCoroutine("ReStart");  
	    }

        if (this.transform.position.x >= xmaxniveau)
        {
            StartCoroutine(transition());
        }
		 
	}
	
	void FixedUpdate () {
		if(Input.GetAxis("Horizontal") > 0.01F)
		{
			this.transform.Translate(new Vector2(0.1F, 0)*speed);
			this.sens = 1;
			isMoving = true;
			
		}
		else if(Input.GetAxis("Horizontal") < -0.01F)
		{
			this.transform.Translate(new Vector2(-0.1F, 0)*speed);
			this.sens = -1;
			isMoving = true;
		}
		else{
			isMoving = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D pCol){
		//Debug.Log(pCol.name);
		/*if(pCol.CompareTag("ennemy"))
		{
			aAnimPanel.SetBool("isDead", true);
			anim.SetBool("isDead", true);
			StartCoroutine("ReStart");	
		}*/
		
	}
	
	void OnTriggerStay2D(Collider2D pCol){
		this.isGrounded = true;
	}
	
	void OnTriggerExit2D(Collider2D pCol){
		this.isGrounded = false;
	}
	
	IEnumerator ReStart()
	{
        m_Scene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(2);

        //print("Nom scene : " + m_Scene.name);

        if (m_Scene.name == "niveau 1")
        {
            level2load = "niveau 1";
        }
        else if (m_Scene.name == "scene bleue")
        {
            level2load = "scene bleue";
        }
        else if (m_Scene.name == "scene jaune")
        {
            level2load = "scene jaune";
        }
        else if (m_Scene.name == "scene rose")
        {
            level2load = "scene rose";
        }

        SceneManager.LoadScene(level2load);
	}

    IEnumerator transition()
    {
        yield return new WaitForSeconds(2);
        tr = true;
        StartCoroutine(loadLevel());

    }
    //Ici
    IEnumerator loadLevel()
    {
        m_Scene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(1);

        if (m_Scene.name == "niveau 1")
        {
            level2load = "planet1toespace";
        }
        else if (m_Scene.name == "scene bleue")
        {
            level2load = "planet2toespace";
        }
        else if (m_Scene.name == "scene jaune")
        {
            level2load = "planet3toespace";
        }
        else if (m_Scene.name == "scene rose")
        {
            level2load = "planet4toespace";
        }
        SceneManager.LoadScene(level2load);
    }


    //Ici
    void OnGUI()
    {
        GUI.color = new Color(1, 1, 1, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }


}
