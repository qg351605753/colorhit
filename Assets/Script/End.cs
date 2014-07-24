using UnityEngine;
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
                    Secai.speed = 3;
                    destroycube = true;
                    StartCoroutine(waiting());
                }
                else if (hit.transform.name == "returned")
                {
                    Secai.speed = 3;
                    PlaneMove.reach = false;
                    GameBegin.IsBegin = false;
                    destroycube = true;
                    Secai.showover = false;
                    Gameovermove.boolmove = false;
                    startretrunde = true;
                    Secai.point = 0;
                    //GameShare.IsShare = false;
                    //GameTrad.IsTrad = false;
                   // player.SetActive(false);
                   // playermid.SetActive(true);
                    player.active = false;
                    playermid.active = true;

                    Debug.Log("returnedreturnedreturnedreturnedreturned");

                }
            }
        }
    }
    IEnumerator waiting()
    {
        // Vector3 movePosition = new Vector3(0, 10, 1.1f);
        yield return new WaitForSeconds(0.3f);
        starretry = true;
        Debug.Log("retryretryretryretry");
        PlaneMove.reach = false;
        GameBegin.IsBegin = false;
        Secai.showover = false;
        //  Gameovermove.boolmove = true;
        Gameovermove.boolmove = false;
        Secai.point = 0;
    }
}
