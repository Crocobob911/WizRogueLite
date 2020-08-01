using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamForTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 0.03f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * -0.03f);
        }
    }
}
