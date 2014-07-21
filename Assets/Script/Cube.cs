using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    public GameObject gameObject;
   
    
    // Use this for initialization
    void Start()
    {
       
        rigidbody.velocity = new Vector3(0,( 3.00f+0.02f*Secai.Cubespeed), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > -4)
        {
            Destroy(gameObject);
        }
    }
}