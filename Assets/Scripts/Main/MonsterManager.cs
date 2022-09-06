using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Monsters
{

    [Header("�����벨��֮���ʱ����")]
    public float waveInterval;

    [Header("���������֮��ļ��")]
    public float monsterInterval;

    [Header("һ����������")]
    public float monsterCount;

    [Header("����Ԥ����")]
    public Transform monsterPrefab;

    [Header("����Ѫ��")]
    public float monsterBlood;

    [Header("�����ٶ�")]
    public float monsterSpeed;

    [Header("��ɱ����õ��Ľ�Ǯ")]
    public float monsterValue;


}
public class MonsterManager : MonoBehaviour
{
    public Monsters[] monsters;

    [Header("�������ɼ�ʱ��")]
    private float monsterTimer;

    [Header("�������ɼ�ʱ��")]
    private float waveTimer;

    [Header("��ǰ�ǵڼ�����")]
    private int waveIndex = 0;

    [Header("�������ɵ�λ��")]
    private Transform startpro;

    [Header("��ǰ�Ĺ��������")]
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

        //�����벨��֮���ʱ����
        if (waveTimer > monsters[waveIndex].waveInterval)
        {
            monsterTimer += Time.deltaTime;
            //���ɵĹ����Ƿ�ﵽһ��������������
            if (monsterNumber < monsters[waveIndex].monsterCount)
            {
                //��ʱ���ﵽ���ɹ����ʱ����
                if (monsterTimer > monsters[waveIndex].monsterInterval)
                {
                    //���ɹ���
                    GameObject monster = Instantiate(monsters[waveIndex].monsterPrefab, startpro.position, Quaternion.identity).gameObject;
                    //�����ʼ��
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
