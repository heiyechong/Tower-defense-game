using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEvent : MonoBehaviour
{
    public static float hp = 10;
    private MonsterManager monsterManager;
    private void Awake()
    {
        monsterManager = new MonsterManager();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            hp--;
            Debug.Log(hp);
            MonsterManager.monsterCount--;
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                Debug.Log("ÓÎÏ·Ê§°Ü");
            }
        }



    }
}
