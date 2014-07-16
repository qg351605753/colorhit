using UnityEngine;
using System.Collections;

public class Secai : MonoBehaviour
{
    public Camera cam;
    public Transform Prefabblue;
    public Transform Prefabgreen;
    public Transform Prefabred;
    public Transform Prefabyellow;
    public Transform Prefabwhite;


    private static float cubesy = -15;
    private float cubeX;
    private bool FirstCube = false;
    private bool suiji = false;
    Rect windowRect = new Rect(20, 20, 100, 50);
    public static float CubeSY { get { return cubesy; } }

    // GUI.WindowFunction windowFunction;
    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 700, 100, 50), "开始游戏"))
        {
            //Application.Quit();
            Vector2 velocity = new Vector2(0, -5);
            rigidbody2D.velocity = velocity;
        }
    }


    // Use this for initialization
    void Start()
    {
       // Instantiate(Prefabwhite, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        int Startproduce = 0;
        // Debug.Log(juli + " -------- juli摄像机坐标");
        GameObject.Find("title Text").GetComponent<GUIText>().text = "色彩撞击";
        if (Startproduce == 0 && cam.transform.position.y < -10)
        {
            Player.playerstar = true;
            Startproduce = 1;
            if (FirstCube == false)
            {
                FirstCube = true;
               // Debug.Log(FirstCube + " -------- :FirstCube");
                Instantiate(getColorPref(), new Vector3(0, -15, 0), Quaternion.identity);
            }
        }
        
        if (Startproduce == 1)
        {            
            Background.Move();
            Vector2 velocity = new Vector2(0, -4);
            rigidbody2D.velocity = velocity;
            
            if (cam.transform.position.y < (cubesy + 5))
            {
               
                float juli;
                if (Random.Range(0, 10) < 3)
                {
                    if (suiji == false)
                    {
                    suiji = true;
                    juli = Random.Range(0.10f, 0.60f);
                    //Debug.Log(suiji + " -------- suiji:");
                    }
                    else{
                     suiji = false;
                     juli = Random.Range(0.60f, 0.70f);
                     //Debug.Log(suiji + " -------- suiji:");
                    }

                   float k = Random.Range(-2.50f, 0.50f);

                    if (k < (cubeX - 1.0f))
                    {
                        cubeX = k;
                    }
                    else
                    {
                        cubeX = k + 2.0f;
                    }

                    /*while(cubeX>2.5f&&cubeX<-2.5f){
                        if (k < cubeX-0.5f)
                        {
                        cubeX -= Random.Range(-2.50f, cubeX-0.60f);
                        }
                        else{

                        cubeX -= Random.Range( cubeX + 0.60f,2.50f);
                        }

                    }*/
                    //Debug.Log(k + " -------- k摄像机坐标");
                    //(k > 0.60f || k < -0.60f) &&
                    //  if (-0.6f<k<0.6f) { }
                }
                else
                {
                    juli = Random.Range(0.70f, 1.40f);
                    cubeX = Random.Range(-2.50f, 2.50f);
                }
                cubesy -= juli;
              //  Debug.LogError("k:" + k + "cubeX:" + cubeX + " cubesy:" + cubesy + " juli:" + juli + " suijishu:" + suijishu);
              
                Instantiate(getColorPref(), new Vector3(cubeX, cubesy, 0), Quaternion.identity);
                
            }

        }
    }

    private Transform getColorPref()
    {
       int Whatcolour = Random.Range(0, 100);
        if (Whatcolour % 4 == 1)
        {
            return Prefabblue;
        }
        else if (Whatcolour % 4 == 2)
        {
            return Prefabgreen;
        }
        else if (Whatcolour % 4 == 3)
        {
            return Prefabred;
        }

        return Prefabyellow;
    }
}
