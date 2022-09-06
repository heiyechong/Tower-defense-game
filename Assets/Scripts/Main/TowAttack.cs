using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowAttack : MonoBehaviour
{
    List<Monster> monsters;

    [Header("�����۸�")]
    public float towerCost = 200;


    [Header("ת���ٶ�")]
    private float speed = 2;

    [Header("�ڵ�Ԥ����")]
    public GameObject paodan;

    [Header("����ʱ����")]
    private float fireInterval = 2;

    [Header("�����ʱ��")]
    private float Timer;

    private float damage = 100;

    private void Awake()
    {
        monsters = new List<Monster>();
    }

    private void Update()
    {
        if (monsters.Count == 0)
        {
            return;
        }
        //�жϵ����Ƿ����٣����پ��Ƴ�����
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i] == null)
            {
                monsters.Remove(monsters[i]);
                i--;
            }
        }
        if (monsters.Count > 0)
        {

            Vector3 vector = monsters[0].transform.position + monsters[0].transform.up * 3 - transform.position;
            Quaternion quaternion = Quaternion.LookRotation(vector);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, speed * Time.deltaTime);
        }


        Timer += Time.deltaTime;

        if (Timer > fireInterval)
        {
            GameObject blt = Instantiate(paodan, transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).position, Quaternion.identity);
            blt.GetComponent<PaodanScript>().BulletInit(damage, monsters[0].transform);
            Timer = 0;

        }

    }
    public void Removed(Monster monster)
    {
        if (monsters.Contains(monster))
        {
            monsters.Remove(monster);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            monsters.Add(other.GetComponent<Monster>());

            //�����ɫ�������ί�У�д��+=����Ȼ�п��ܱ���
            other.gameObject.GetComponent<Monster>().deadEvent += new System.Action<Monster>(Removed);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster" && monsters.Contains(other.GetComponent<Monster>()))
        {
            monsters.Add(other.GetComponent<Monster>());

            other.gameObject.GetComponent<Monster>().deadEvent += new System.Action<Monster>(Removed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
        {
            monsters.Remove(other.GetComponent<Monster>());
            other.gameObject.GetComponent<Monster>().deadEvent -= new System.Action<Monster>(Removed);
        }

    }

}
