using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject.Find("lose Text").GetComponent<GUIText>().text = "时间：" + Secai.timer;
        GameObject.Find("record Text").GetComponent<GUIText>().text = "分数：" + Secai.point;
        GameObject.Find("most Text").GetComponent<GUIText>().text = "最高纪录" + Secai.recordtimes;
        if (Input.GetMouseButtonUp(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "retry")
                {
                    PlaneMove.reach = false;
                    GameBegin.IsBegin = false;
                    Application.LoadLevelAsync("menu");
                }
            }
        }
    }
}
