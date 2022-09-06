using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Monsters
{

    [Header("波次与波次之间的时间间隔")]
    public float waveInterval;

    [Header("怪物与怪物之间的间隔")]
    public float monsterInterval;

    [Header("一波怪物数量")]
    public float monsterCount;

    [Header("怪物预设体")]
    public Transform monsterPrefab;

    [Header("怪物血量")]
    public float monsterBlood;

    [Header("怪物速度")]
    public float monsterSpeed;

    [Header("击杀怪物得到的金钱")]
    public float monsterValue;


}
public class MonsterManager : MonoBehaviour
{
    public Monsters[] monsters;

    [Header("怪物生成计时器")]
    private float monsterTimer;

    [Header("波次生成计时器")]
    private float waveTimer;

    [Header("当前是第几波次")]
    private int waveIndex = 0;

    [Header("怪物生成的位置")]
    private Transform startpro;

    [Header("当前的怪物的数量")]
    private int monsterNumber = 0;

    private Transform endpro;
    private void Awake()
    {
        startpro = GameObject.Find("StartPos").transform;

        endpro = GameObject.Find("TargetPos").transform;
    }
    private void Update()
    {

        waveTimer += Time.deltaTime;

        if (waveIndex>=monsters.Length)
        {
            return;
        }

        //波次与波次之间的时间间隔
        if (waveTimer > monsters[waveIndex].waveInterval)
        {
            monsterTimer += Time.deltaTime;
            //生成的怪物是否达到一波怪物的最大数量
            if (monsterNumber < monsters[waveIndex].monsterCount)
            {
                //计时器达到生成怪物的时间间隔
                if (monsterTimer > monsters[waveIndex].monsterInterval)
                {
                    //生成怪物
                    GameObject monster = Instantiate(monsters[waveIndex].monsterPrefab, startpro.position, Quaternion.identity).gameObject;
                    //怪物初始化
                    monster.GetComponent<Monster>().SetMonster(monsters[waveIndex].monsterBlood, monsters[waveIndex].monsterSpeed, endpro,monsters[waveIndex].monsterValue);
                    monsterNumber++;
                    monsterTimer = 0;
                }
            }
            else
            {
                monsterNumber = 0;
                waveTimer = 0;
                waveIndex++;
            }

        }

    }

}
