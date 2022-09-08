using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneTwo : MonoBehaviour
{
    private Transform tittle;
    private void Awake()
    {
        tittle = transform.GetChild(0);
    }
    void Start()
    {
      
        tittle.GetChild(0).GetComponent<Text>().text = "Level" + (ScenceOne.lnumber + 1);
    }
}
