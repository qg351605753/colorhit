﻿using UnityEngine;
using System.Collections;

public class End : MonoBehaviour
{
    public static bool destroycube = false;
    //public GameObject retry;
    //public GameObject returned;
    public static bool startretrunde = false;
    public static bool starretry = false;
    public GameObject player;
    public GameObject playermid;
    private string path;
    private string picpath;
    Transform save;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "retry")
                {
                    Debug.Log("retry:");
                   // ChangeScale(GameObject.Find("retry"));
                    GameObject.Find("retry").animation.Play("Changebtn");
                    Secai.speed = 3;
                    destroycube = true;
                    Player.initial = true;
                    StartCoroutine(waiting());
                }
                else if (hit.transform.name == "returned")
                {
                    //Color changesssColor = new Color(0, 0.686f, 1, 0);
                    /*save = new Material(GameObject.Find("returned").renderer.sharedMaterial);
                    Material nov = new Material(GameObject.Find("returned").renderer.sharedMaterial);
                    nov.color = new Color(save.color.r, save.color.g, save.color.b, 0.6f);
                    GameObject.Find("returned").renderer.sharedMaterial = nov;
                    StartCoroutine(returncolor());**/
                    GameObject.Find("returned").animation.Play("Changebtn");
                   // ChangeScale(GameObject.Find("returned"));
                    Player.initial = true;
                    StartCoroutine(waited());
                   

                }
                else if (hit.transform.name =="share")
                {
                   
                   // ChangeScale(GameObject.Find("share"));
                    
                    GameObject.Find("share").animation.Play("Changebtn");
                    Application.CaptureScreenshot("Screenshot.png");
                    if(Application.platform==RuntimePlatform.Android){  
                    	path=Application.persistentDataPath;  
                    }

					Application.CaptureScreenshot("jietu.JPG");
#if UNITY_IOS
					Lihui.weibo();
#endif
                    //  picpath =path+"/Screenshot.png";
        //            Lihuiweibo.jietu(picpath);

                }
            }
        }
    }
    IEnumerator waiting()
    {
        // Vector3 movePosition = new Vector3(0, 10, 1.1f);
        yield return new WaitForSeconds(0.3f);
        starretry = true;
       // Debug.Log("retryretryretryretry");
        PlaneMove.reach = false;
        GameBegin.IsBegin = false;
        Secai.showover = false;
        //  Gameovermove.boolmove = true;
        Gameovermove.boolmove = false;
        Secai.point = 0;
        Player.beishu = 0;
        Player.recordbeishu = 0;
    }
    IEnumerator waited()
    {
        // Vector3 movePosition = new Vector3(0, 10, 1.1f);
        yield return new WaitForSeconds(0.3f);
        Secai.speed = 3;
        PlaneMove.reach = false;
        GameBegin.IsBegin = false;
        destroycube = true;
        Secai.showover = false;
        Gameovermove.boolmove = false;
        startretrunde = true;
        Secai.point = 0;
        Player.beishu = 0;
        //GameShare.IsShare = false;
        //GameTrad.IsTrad = false;
        // player.SetActive(false);
        // playermid.SetActive(true);
        player.active = false;
        playermid.active = true;
        GameObject.Find("Playermid").animation.Play("sizeBig");
        Player.recordbeishu = 0;
    }
    IEnumerator returnScale(GameObject btn)
    {
        yield return new WaitForSeconds(0.1f);
      //  GameObject.Find("returned").renderer.sharedMaterial = save;
        btn.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
    }
   /* void ChangeScale(GameObject btn) {
        btn.transform.localScale += new Vector3(-0.1F, -0.1f, -0.1f);
        StartCoroutine(returnScale(btn));
    }**/
}
