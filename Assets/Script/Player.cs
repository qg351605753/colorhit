using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static bool playerstar = false;
    public Transform m_transform;
    public Vector3 fristPos;
    public Vector3 movePos;
    public Transform Prefabblue;
    public Transform Prefabgreen;
    public Transform Prefabred;
    public Transform Prefabyellow;

    public GameObject protect;
    public GameObject speedDown;
    public GameObject speedRush;

    private static int blue = 0;
    private static int green = 0;
    private static int yellow = 0;
    private static int red = 0;
    private string changeColor;
    public static bool pauseeverything = false;

    public static int RED { get { return red; } }
    public static int GREEN { get { return green; } }
    public static int YELLOW { get { return yellow; } }
    public static int BLUE { get { return blue; } }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (playerstar == true)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);

            float moveY = 0;// 上下移动的数值;        
            float moveX = 0;//左右移动的数值;
            int i = 1;

            //是否刚刚触屏
            // while (i < Input.touchCount)
            // {
            //Debug.Log("i:" + i + " Touch Count:" + Input.touchCount);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                i++;
                //接触屏幕的坐标
                fristPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)//是否触屏移动
            {                                  //触屏移动后的坐标      
                movePos = Input.GetTouch(0).deltaPosition;

                //更据X轴的值判断移动方向
                if (Mathf.Abs(fristPos.x - movePos.x) > 0.1)
                {
                    //向右移动
                    if (fristPos.x < movePos.x)
                    {
                        if ((movePos.x / 700) + m_transform.position.x <= 2.40f)
                        {
                            moveX += movePos.x / 700;
                        }
                    }
                    //向左移动
                    if (fristPos.x > movePos.x)
                    {
                        if ((m_transform.position.x + movePos.x / 700) >= -2.40f)
                        {
                            moveX -= Mathf.Abs(movePos.x / 700);
                        }
                    }
                }

                m_transform.Translate(new Vector3(10 * moveX, moveY, 0));
            }
        }
        //  }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Finish")
        {
            //  Debug.Log("碰撞到的物体的名字是：" + collisionInfo.gameObject.name);
            Destroy(collisionInfo.gameObject);
            Secai.recordTime();
            StartCoroutine(Wait());

        }
        else if (collisionInfo.gameObject.tag == "GameController")
        {
            // Debug.Log("碰撞到的物体的名字是:" + collisionInfo.gameObject.name);
            Destroy(collisionInfo.gameObject);
            Color changeColor = new Color(0, 0.686f, 1, 0);
            renderer.material.color = changeColor;
            blue++;
            green = 0;
            yellow = 0;
            if (blue == 1)
            {
                Secai.point += 1;
                // speedDown.active = false;
                // protect.active = false;

            }
            else if (blue == 2)
            {
                Secai.point += 2;


            }
            else if (blue > 2)
            {
                Secai.point += 6;
                // speedRush.active = true;

            }
        }
        else if (collisionInfo.gameObject.tag == "EditorOnly")
        {
            // Debug.Log("碰撞到的物体的名字是:" + collisionInfo.gameObject.name);
            Destroy(collisionInfo.gameObject);
            renderer.material.color = Color.green;

            green++;
            yellow = 0;
            blue = 0;
            if (green == 1)
            {
                Secai.point += 1;
                // protect.active = false;
                // speedRush.active = false;
            }
            else if (green == 2)
            {
                Secai.point += 2;


            }
            else if (green > 2)
            {
                //

                //speedDown.active = true;

                Secai.point += 6;
            }
        }
        else if (collisionInfo.gameObject.tag == "Respawn")
        {
            // Debug.Log("碰撞到的物体的名字是:" + collisionInfo.gameObject.name);
            Destroy(collisionInfo.gameObject);
            renderer.material.color = Color.yellow;
            yellow++;
            blue = 0;
            green = 0;
            if (yellow == 1)
            {
                Secai.point += 1;
                //  speedRush.active = false;
                //  speedDown.active = false;
            }
            else if (yellow == 2)
            {
                Secai.point += 2;

            }
            else if (yellow > 2)
            {
                Secai.point += 6;
                // protect.active = true;


            }
        }
    }

    IEnumerator Wait()
    {
        // Vector3 movePosition = new Vector3(0, 10, 1.1f);
        yield return new WaitForSeconds(0.01f);
        // Application.LoadLevelAsync("Gameover");
        //transform.position = Vector3.MoveTowards(transform.position, tradPosition, UnityEngine.Time.smoothDeltaTime * 4);
        //GameObject.FindGameObjectWithTag("EditorOnly").transform.position = Vector3.MoveTowards(transform.position, movePosition, UnityEngine.Time.smoothDeltaTime * 2);
        //TriggerGameOver();
        // GameObject.Find("gameover").collider.enabled = true;
        //Secai.showover = true;
        Secai.showover = true;
        pauseeverything = true;
        Gameovermove.boolmove = true;
    }

}