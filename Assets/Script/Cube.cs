using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    public GameObject gameObject;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > Secai.CubeSY + 13.00f)
        {
            Destroy(gameObject);
        }

    }
}