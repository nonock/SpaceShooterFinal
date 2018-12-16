using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
    public GameObject laser;
	public Transform shotSpawn;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;
    public Transform shotSpawn5;
    public Transform shotSpawn6;
    public Transform shotSpawn7;
    public Transform shotSpawn8;
    public Transform shotSpawn9;
    public Transform laserSpawn;
    public float fireRate;
    public float fireLaserRate;
	public float delay;

    Scene m_Scene;

	void Start ()
	{
        m_Scene = SceneManager.GetActiveScene();

        if(m_Scene.name == "niv3")
        {
            fireRate = 1;
        }
        else if(m_Scene.name == "niv4")
        {
            fireRate = 0.7f;
        }

        if (m_Scene.name == "niv5")
        {
            fireRate = 0.2f;

            InvokeRepeating("FireBoss", delay, fireRate);

            InvokeRepeating("LaserBoss", delay*3, fireLaserRate);
        }
        else
        {
            InvokeRepeating("Fire", delay, fireRate);
        }
	}

	void Fire ()
	{
        Vector3 pos = new Vector3(shotSpawn.position.x, shotSpawn.position.y, shotSpawn.position.z);
        Vector3 pos1 = new Vector3(shotSpawn1.position.x, shotSpawn1.position.y, shotSpawn1.position.z);

        pos.y = 0;
        pos1.y = 0;

        //print(shotSpawn.position);
		Instantiate(shot, pos, shotSpawn.rotation);
        Instantiate(shot, pos1, shotSpawn1.rotation);
		GetComponent<AudioSource>().Play();
	}

    void FireBoss()
    {
        Vector3 pos = new Vector3(shotSpawn.position.x, shotSpawn.position.y, shotSpawn.position.z);
        Vector3 pos1 = new Vector3(shotSpawn1.position.x, shotSpawn1.position.y, shotSpawn1.position.z);
        Vector3 pos2 = new Vector3(shotSpawn2.position.x, shotSpawn2.position.y, shotSpawn2.position.z);
        Vector3 pos3 = new Vector3(shotSpawn3.position.x, shotSpawn3.position.y, shotSpawn3.position.z);
        Vector3 pos4 = new Vector3(shotSpawn4.position.x, shotSpawn4.position.y, shotSpawn4.position.z);
        Vector3 pos5 = new Vector3(shotSpawn5.position.x, shotSpawn5.position.y, shotSpawn5.position.z);
        Vector3 pos6 = new Vector3(shotSpawn6.position.x, shotSpawn6.position.y, shotSpawn6.position.z);
        Vector3 pos7 = new Vector3(shotSpawn7.position.x, shotSpawn7.position.y, shotSpawn7.position.z);
        Vector3 pos8 = new Vector3(shotSpawn8.position.x, shotSpawn8.position.y, shotSpawn8.position.z);
        Vector3 pos9 = new Vector3(shotSpawn9.position.x, shotSpawn9.position.y, shotSpawn9.position.z);


        pos.y = 0;
        pos1.y = 0;
        pos2.y = 0;
        pos3.y = 0;
        pos4.y = 0;
        pos5.y = 0;
        pos6.y = 0;
        pos7.y = 0;
        pos8.y = 0;
        pos9.y = 0;

        //print(shotSpawn.position);
        Instantiate(shot, pos, shotSpawn.rotation);
        Instantiate(shot, pos1, shotSpawn1.rotation);
        Instantiate(shot, pos2, shotSpawn2.rotation);
        Instantiate(shot, pos3, shotSpawn3.rotation);
        Instantiate(shot, pos4, shotSpawn4.rotation);
        Instantiate(shot, pos5, shotSpawn5.rotation);
        Instantiate(shot, pos6, shotSpawn6.rotation);
        Instantiate(shot, pos7, shotSpawn7.rotation);
        Instantiate(shot, pos8, shotSpawn8.rotation);
        Instantiate(shot, pos9, shotSpawn9.rotation);
        GetComponent<AudioSource>().Play();
    }

    void LaserBoss()
    {
        for(int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(laserSpawn.position.x, laserSpawn.position.y, laserSpawn.position.z + i/2);

            pos.y = 0;

            //print(shotSpawn.position);
            Instantiate(laser, pos, laserSpawn.rotation);

        }
    }
}
