using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEvent : MonoBehaviour
{
    private float hp = 10;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            hp--;
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                Debug.Log("ÓÎÏ·Ê§°Ü");
            }
        }



    }
}
