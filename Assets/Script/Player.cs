using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static bool playerstar = false;
    public Transform m_transform;
    public Vector3  fristPos;
    public Vector3 movePos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playerstar == true)
        {
        rigidbody.velocity = new Vector3(0, -4, 0);
      
        float moveY = 0;// 上下移动的数值;        
        float moveX = 0;//左右移动的数值;
       
        //是否刚刚触屏
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
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
                    /*判断移动是否会超出屏幕右侧
                    700这个值是针对不同手机屏幕的分辩率参考出来的,因为分辨率越高，手指在屏幕中移动的值不一样。
                    比如：400*800  与 1920*1080的分辨率,手指在屏幕移动1厘米的距离得到的Input.GetTouch(0).deltaPosition会不一样
                    也可在Awake()方法中 默认一个速度 speet=你调出的参考值 * Screen.width / 你的默认值。
                    开发中就不要了，因为不要测试。待程序发布的时候可以。
                    如果按我这么写，700这个值在1080P的屏幕上移动是很流畅的。
                     调试的时候就不能用这么高的值。一般在10到100之间。
                     */
                   if ((movePos.x / 700) + m_transform.position.x <= 2.50f)
                   {
                        moveX += movePos.x / 700;
                    }
                }
                //向左移动
                if (fristPos.x > movePos.x)
                {
                    //判断移动是否会超出屏幕左侧 (-1.2是摄像机左的临界点)  
                    if ((m_transform.position.x + movePos.x / 700) >= -2.50f)
                    {
                        moveX -= Mathf.Abs(movePos.x / 700);
                    }
                }
            }
    
            m_transform.Translate(new Vector3(12*moveX, moveY, 0));
        }
        }
	}
}
