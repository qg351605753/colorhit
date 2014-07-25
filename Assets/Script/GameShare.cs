using UnityEngine;
using System.Collections;

public class GameShare : MonoBehaviour
{

    public GameObject GameShareSmall;
    //public GameObject ClickedBackground;
    public GameObject GameShareBig;
    public static bool IsShare = false;
    Vector3 targetPosition = new Vector3(9, -3, 0);
    Vector3 backPosition = new Vector3(1, -3, 0);
    public int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            i++;
            if (Physics.Raycast(pos, out hit))
            {
                if (hit.transform.name == "GameShareBtn")
                {

                    if (i % 2 == 1)
                    {
                        GameShareBig.active = false;
                        GameShareSmall.active = true;
                    }
                    if (i % 2 == 0)
                    {
                        GameShareBig.active = true;
                        GameShareSmall.active = false;
                    }

                }
            }
        }
       
        if (GameBegin.IsBegin)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (GameTrad.IsTrad)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (BackMain.IsBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 3);
        }
        if (End.startretrunde)
        {
            transform.position = Vector3.MoveTowards(transform.position, backPosition, UnityEngine.Time.smoothDeltaTime * 5);
            
        }
        if (IsShare)
        {
 
        }
    }


}
