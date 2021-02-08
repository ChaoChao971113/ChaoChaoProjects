using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy1>().Damage(damage);
            damage += damage * (int)Time.deltaTime;
        }
    }
}
