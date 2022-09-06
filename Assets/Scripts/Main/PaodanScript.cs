using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaodanScript : MonoBehaviour
{
    public Transform target;

    [Header("ÅÚµ¯·ÉÐÐËÙ¶È")]
    public float speed = 1000;

    public float damage ;

    private void Update()
    {
        if (target ==null)
        {
            Destroy(gameObject);
            return;
        }
       transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
    }

    public void BulletInit( float damage,Transform target)
    {
        this.damage = damage;
        this.target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Monster")
        {
            other.GetComponent<Monster>().Damage(damage);
            Destroy(this.gameObject);
        }
    }

}
