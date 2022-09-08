using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScenceOne : MonoBehaviour
{
    [Header("已解锁的关卡数量")]
    private int LevelsUnlock = PublicScript.danli().dic.Count+1;

    private Transform select;

    [HideInInspector]
    public static int lnumber =0;

    private void Awake()
    {
        select = transform.GetChild(0).Find("Select");
    }
    // Start is called before the first frame update
    void Start()
    {
        initialize();
    }

    public void LevelButtonClick(int LevelNumber)
    {
        Transform game = transform.GetChild(LevelNumber - 1);
        lnumber = LevelNumber - 1;
        select.SetParent(game);
        select.SetSiblingIndex(0);
        select.localPosition = Vector3.zero;
    }

    public void ScenceButtonClick()
    {
        PublicScript.danli().levelnumber = lnumber;
        SceneManager.LoadScene("Main");


    }
    //初始化
    private void initialize()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).Find("Text").GetComponent<Text>().text = (i + 1).ToString();
            transform.GetChild(i).Find("StarManager").gameObject.SetActive(false);
            if (i < LevelsUnlock)
            {
                transform.GetChild(i).Find("StarManager").gameObject.SetActive(true);
                transform.GetChild(i).Find("Lock").gameObject.SetActive(false);
                if (i  == PublicScript.danli().dic.Count)
                {
                    continue;
                }

                for (int k = 0; k < PublicScript.danli().dic[i]; k++)
                {
                    transform.GetChild(i).Find("StarManager").GetChild(k).gameObject.SetActive(true); 
                }
            }
            else
            {
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }

        }

    }


}
