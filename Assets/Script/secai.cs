using UnityEngine;
using System.Collections;

public class secai : MonoBehaviour {
    public int Choosesecai;
    /* Rect windowRect = new Rect(20, 20, 100, 50);

    // GUI.WindowFunction windowFunction;
     void OnGUI ()
     {
         if (GUI.Button(new Rect(500, 700, 100, 50), "开始游戏"))
         {
             //Application.Quit();
             Vector2 velocity = new Vector2(0, -5);       
             rigidbody2D.velocity = velocity;
           
         }
     }  **/

   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject.Find("title Text").GetComponent<GUIText>().text = "色彩撞击";
        Choosesecai = Random.Range(0, 100);
	}
}
