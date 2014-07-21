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
    public static int point ;
    public static float timer;
    public static int recordtimes;

    private float cubeX;
    private bool FirstCube = false;
    private bool suiji = false;
    private static float speed;
    Rect windowRect = new Rect(20, 20, 100, 50);
    public static float Cubespeed { get { return speed; } }
    private float timestart;
    private bool begin=false;
    // GUI.WindowFunction windowFunction;
    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 700, 100, 50), "开始游戏"))
        {           
            Vector2 velocity = new Vector2(0, -5);
            rigidbody2D.velocity = velocity;
        }
    }


    // Use this for initialization
    void Start()
    {
           recordtimes = PlayerPrefs.GetInt("recordtimes", 0);
           speed = 3.0f;
           point = 0;
    }
    Transform ob;
    // Update is called once per frame
    void Update()
    {

        int Startproduce = 0;
        
        float juli;
        
        GameObject.Find("title Text").GetComponent<GUIText>().text = "色彩撞击";
        timer = Time.time - timestart;
        if (begin)
        {
        GameObject.Find("time Text").GetComponent<GUIText>().text = "时间：" + timer.ToString(".000");
        GameObject.Find("point Text").GetComponent<GUIText>().text = "分数：" + point;
        }
        if (Startproduce == 0 && cam.transform.position.y < -10f)
        {
            Player.playerstar = true;
            Startproduce = 1;
            if (FirstCube == false)
            {
                FirstCube = true;
                Debug.Log(FirstCube + " -------- :FirstCube");               
                ob = (Transform)Instantiate(getColorPref(), new Vector3(0, -15, 0), Quaternion.identity);
                timestart = Time.time;
            }
        }

        if (Startproduce == 1)
        {
            begin = true;
            if (Random.Range(0, 10) < 0f)
            {
                float k = Random.Range(-2.50f, 0.50f);

                if (k < (cubeX - 1.0f))
                {
                    cubeX = k;
                }
                else
                {
                    cubeX = k + 2.0f;
                } 
                if (suiji == false)
                {
                    suiji = true;
                    juli = Random.Range(0.10f, 0.60f);
                   
                }
                else
                {
                    suiji = false;
                    juli = Random.Range(0.60f, 0.70f);
                 
                }
            }
            else
            {
                juli = Random.Range(0.90f, 3.40f);
                cubeX = Random.Range(-2.50f, 2.50f);
            }

            Background.Move();
            if (Background.test == 1)
            {
                Vector2 velocity = new Vector2(0, 0);
                rigidbody2D.velocity = velocity;
            }
            else
            {
                Vector2 velocity = new Vector2(0, 0);
                rigidbody2D.velocity = velocity;
            }

            if ((15 + ob.position.y) > juli)
            {
            
                ob = (Transform)Instantiate(getColorPref(), new Vector3(cubeX, -15, 0), Quaternion.identity);
                speed++;
                Debug.LogError("speed: " + speed);
 
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
  public static void recordTime()
    {
        if (recordtimes == 0)
        {
            recordtimes = point;
            PlayerPrefs.SetInt("recordtimes", recordtimes);
        }
        if (recordtimes < point)
        {

            recordtimes = point;
            PlayerPrefs.SetInt("recordtimes", recordtimes);
        }
    }
}
