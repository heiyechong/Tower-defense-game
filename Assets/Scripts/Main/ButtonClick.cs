using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonClick : MonoBehaviour
{
    public static ButtonClick buttonClick;

    public GameObject[] Prefabs;

    public float currentMoney = 300;
    private int currentTowIndex;

    private Text moneyText;

    private RaycastHit raycastHit;



    private void Awake()
    {
        moneyText = transform.Find("Money").GetComponent<Text>();

    }
    private void Start()
    {
        UpdateMoney();
        buttonClick = this;
    }
    public void OnClick(int Index)
    {
        currentTowIndex = Index;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        TowAttack towAttack = Prefabs[currentTowIndex].GetComponent<TowAttack>();



        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out raycastHit))
        {

            if (currentMoney < towAttack.towerCost)
            {
                Debug.Log("Ç®²»¹»");
                return;

            }
            if (!raycastHit.collider.name.Contains("Tower_Base"))
            {
                return;
            }
            currentMoney -= towAttack.towerCost;
            UpdateMoney();
            GameObject gameObject = Instantiate(Prefabs[currentTowIndex]);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            gameObject.transform.SetParent(raycastHit.collider.transform);
            gameObject.transform.localPosition = Vector3.up * 2.7f;
        }
    }


    public void UpdateMoney()
    {
        moneyText.text = currentMoney.ToString();
    }

}
