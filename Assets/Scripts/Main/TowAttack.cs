using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowAttack : MonoBehaviour
{
    List<Monster> monsters;

    [Header("炮塔价格")]
    public float towerCost = 200;


    [Header("转身速度")]
    private float speed = 2;

    [Header("炮弹预设体")]
    public GameObject paodan;

    [Header("开火时间间隔")]
    private float fireInterval = 2;

    [Header("开火计时器")]
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
        //判断敌人是否销毁，销毁就移除引用
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

            //多个角色共用这个委托，写成+=，不然有可能报错
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
