using UnityEngine;
using System.Collections;

public class Cloud3 : MonoBehaviour {
    Vector3 targetPosition = new Vector3(-6,-1, 0);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameBegin.IsBegin)
        {
            Animator m_ani = GameObject.Find("cloud3").GetComponent<Animator>();
            m_ani.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 2);
        }

    }
}
