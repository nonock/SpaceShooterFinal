using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverHori : MonoBehaviour {

    public float speed;

    void Start()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        float positionZ = Random.Range(4,6);
        Vector3 movement = new Vector3(1.0f, 0.0f, positionZ);
        GetComponent<Rigidbody>().velocity = movement * speed;
    }
}
