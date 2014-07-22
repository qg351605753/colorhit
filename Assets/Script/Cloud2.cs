﻿using UnityEngine;
using System.Collections;

public class Cloud2 : MonoBehaviour {
    Vector3 targetPosition = new Vector3(-6, 4, 0);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameBegin.IsBegin)
        {
            Animator m_ani = GameObject.Find("cloud2").GetComponent<Animator>();
            m_ani.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, UnityEngine.Time.smoothDeltaTime * 2);
        }

    }
}
