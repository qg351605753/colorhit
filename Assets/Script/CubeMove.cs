using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {

    //Vector3 cubePosition = new Vector3(0, 3, 0);
    Vector3 tradPosition = new Vector3(0, 10, 0);
    Vector3 backPosition = new Vector3(0, 2, 0);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameBegin.IsBegin)
        {
            //animation["Cube"].normalizedTime = 0;
            //animation["Cube"].speed = 0;
            //.Rewind("player");
            //animation["player"].speed = 0;
            //transform.position = Vector3.MoveTowards(transform.position, cubePosition, UnityEngine.Time.smoothDeltaTime * 1);
        }
        if (GameTrad.IsTrad)
        {
            //animation.Rewind("Cube");
            //animation["player"].speed = 0;
            transform.position = Vector3.MoveTowards(transform.position, tradPosition, UnityEngine.Time.smoothDeltaTime * 2);
        }
        if (BackMain.IsBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 3);
            //animation.Play();
            //animation["player"].speed = 1;
        }
    }
}