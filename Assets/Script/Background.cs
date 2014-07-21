using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public static int Backgroundmove = 0;
    public static int test = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("test:" + test);
        if (Backgroundmove == 1)
        {
                Vector2 velocity = new Vector2(0, 0);
                rigidbody2D.velocity = velocity;
            
        }
	
	}
  
    public  static void Move() {
        Backgroundmove = 1;
    }

    
}
