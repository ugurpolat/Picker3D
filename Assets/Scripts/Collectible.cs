using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push()
    {
        _rb.AddForce(Vector3.forward * 15f);
        //Destroy(gameObject, 1.5f);
        

    }
}
