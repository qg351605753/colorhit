using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public static int Backgroundmove = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Backgroundmove == 1)
        {
            Vector2 velocity = new Vector2(0, -4);
            rigidbody2D.velocity = velocity;
}
	
	}
  public  static void Move() {
        Backgroundmove = 1;
    }

    
}
