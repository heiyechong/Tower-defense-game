using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x<-52)
            {
                transform.position = new Vector3(-52, transform.position.y, transform.position.z);
            }
            transform.position -= new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.z<1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            }
            transform.position -= new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x >-1)
            {
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
            }
            transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.z>62)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 62);
            }
            transform.position += new Vector3(0, 0, 1);
        }

    }
}
