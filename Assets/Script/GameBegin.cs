using UnityEngine;
using System.Collections;

public class GameBegin : MonoBehaviour {

    public GameObject GameBeginSmall;
    public GameObject GameBeginBtn;
    public GameObject GameBeginBig;
    public static bool IsBegin = false;
    Vector3 targetPosition = new Vector3(-1, 10, 0);
    Vector3 backPosition = new Vector3(-1, 0, 0);
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "GameBeginBtn")
                {
                   
                    // Debug.Log("click");
                    //IsBegin = true;
                    
                    GameBeginBig.active = false;
                    GameBeginSmall.active = true;

                    //Material mt = Background.materials[0];
                    //mt = (Material)GameObject.Find("ClickedBackground");
                    //ClickedBackground.active = false;
                    
                    
                }
            }
        }else if (Input.GetMouseButtonUp(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "GameBeginBtn")
                {

                    // Debug.Log("click");
                    IsBegin = true;
                    GameBeginBig.active = true;
                    GameBeginSmall.active = false;
                    GameBeginBtn.active = false;
                    
                    //Material mt = Background.materials[0];
                    //mt = (Material)GameObject.Find("ClickedBackground");
                    //ClickedBackground.active = false;


                }
            }
        }
        if (GameTrad.IsTrad)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (BackMain.IsBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
	}


}
