using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    private Transform ress;
    private Transform StarManager;
    private MonsterManager monsterManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        ress = transform.GetChild(0).GetChild(1);
        StarManager = transform.GetChild(0).GetChild(2);
        StarManager.gameObject.SetActive(false);
        ress.GetComponent<Button>().onClick.AddListener(Ress);
      //  monsterManager = new MonsterManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonsterManager.waveIndex>= MonsterManager.monsterwaves && MonsterManager.monsterCount ==0 && TargetEvent.hp>0)
        {
            StarManager.gameObject.SetActive(true);
            if (TargetEvent.hp>=7)
            {
                for (int i = 0; i < StarManager.childCount; i++)
                {
                    StarManager.GetChild(i).gameObject.SetActive(true);
                    PublicScript.danli().starcount = i+1;
                }
            }
            else if(TargetEvent.hp>4&&TargetEvent.hp<7)
            {
                for (int i = 0; i < StarManager.childCount-1; i++)
                {
                    StarManager.GetChild(i).gameObject.SetActive(true);
                    PublicScript.danli().starcount = i+1;
                }
            }
            else
            {
                for (int i = 0; i < StarManager.childCount - 2; i++)
                {
                    StarManager.GetChild(i).gameObject.SetActive(true);
                    PublicScript.danli().starcount = i+1;
                }

            }

            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void Ress()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (PublicScript.danli().dic.ContainsKey(PublicScript.danli().levelnumber))
        {
            if (PublicScript.danli().dic[PublicScript.danli().levelnumber] < PublicScript.danli().starcount)
            {
                PublicScript.danli().dic[PublicScript.danli().levelnumber] = PublicScript.danli().starcount;
            }
        }
        else
        {
            PublicScript.danli().dic.Add(PublicScript.danli().levelnumber, PublicScript.danli().starcount);
        }
        MonsterManager.waveIndex = 0;
        MonsterManager.monsterwaves = 10;
        MonsterManager.monsterCount = 0;
        SceneManager.LoadScene("OriginScene");
        
    }
}
