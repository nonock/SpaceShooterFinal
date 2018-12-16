using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public float fireRate;
	 
	private float nextFire;

    Scene m_Scene;


    void Update ()
	{
        m_Scene = SceneManager.GetActiveScene();
        if(m_Scene.name == "niv2")
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
        if(m_Scene.name == "niv3")
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
        if (m_Scene.name == "niv4")
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
                Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
        if (m_Scene.name == "niv5")
        {
            if(Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
                Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
                Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
    }

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
    }

    public void UpRate()
    {
        fireRate = fireRate - 0.01f;

        //print(fireRate);
    }
}
