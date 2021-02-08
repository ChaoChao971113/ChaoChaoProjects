using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 70;
    private Transform target;

    public void Settarget(Transform _target)
    {
        this.target = _target;
    }

    void Update()
    {
        if (target==null)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Enemy")
        {
            col.GetComponent<Enemy1>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
