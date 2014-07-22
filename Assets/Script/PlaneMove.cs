using UnityEngine;
using System.Collections;

public class PlaneMove : MonoBehaviour {
    //GameBegin gb = new GameBegin();
    //Vector3 startPos;
    //Vector3 velocity;
    public static bool reach = false;
    Vector3 gamePosition =new Vector3(0, -11, 1);
    Vector3 tradPosition = new Vector3(0, 11, 1);
    Vector3 sharePosition = new Vector3(0, 11, 1);
    Vector3 backPosition = new Vector3(0, 0, 1);
    //RaycastHit hit = new RaycastHit();
   // float speed = 1.0f;  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
       // Debug.Log("GameBegin.IsPressed ---- " + GameBegin.IsPressed);
        //while(GameBegin.IsPressed == true)
        if (GameBegin.IsBegin)
        {
            //startPos = transform.position;
            //velocity =hit.point - startPos;
            //Debug.Log("move ---- ");
            //transform.Translate(0, 0, -2 * Time.deltaTime);
            //transform.Translate(velocity / velocity.magnitude * speed * Time.smoothDeltaTime);
            transform.position = Vector3.MoveTowards(transform.position, gamePosition, UnityEngine.Time.smoothDeltaTime * 4);
            if (transform.position.y < -9.9f)
            {
                reach = true;
            }
        }
         if (GameTrad.IsTrad)
        {
            transform.position = Vector3.MoveTowards(transform.position, tradPosition, UnityEngine.Time.smoothDeltaTime * 4);
        }
         /*if (GameShare.IsShare)
         {
             transform.position = Vector3.MoveTowards(transform.position, sharePosition, UnityEngine.Time.smoothDeltaTime * 4);
         }*/
         if (BackMain.IsBack)
         {
             //GameBegin.IsBegin = false;
             GameTrad.IsTrad = false;
             GameShare.IsShare = false;
             //transform.position = backPosition;
             transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 4);
             Debug.Log("transform.position" + transform.position);
         }
	}
}
