using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverBoss : MonoBehaviour {
    
    public float speed;
    public float xMin, xMax;
    
    private bool dontmove = false;
    private bool left = false;
    private bool right = false;

    void Start()
    {
        Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;

    }

    IEnumerator Example(Vector3 movement)
    {
        yield return new WaitForSeconds(1);
        if (right == true)
        {
            GetComponent<Rigidbody>().velocity = movement * -speed;
        }
        else if (left == true)
        {
            GetComponent<Rigidbody>().velocity = movement * speed;
        }
        //print(Time.time);
    }

    void FixedUpdate()
    {
        //print(GetComponent<Rigidbody>().position.x);
        if(GetComponent<Rigidbody>().position.x > 6)
        {
            Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement * -speed;

            dontmove = true;
            right = true;
            left = false;
        }
        else if(GetComponent<Rigidbody>().position.x < 0.01 && GetComponent<Rigidbody>().position.x > -0.01 && dontmove == true)
        {
            Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement * 0;
            StartCoroutine(Example(movement));

            dontmove = false;
        }
        else if(GetComponent<Rigidbody>().position.x < -6)
        {
            Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement * speed;

            dontmove = true;
            left = true;
            right = false;
        }
    }
}
