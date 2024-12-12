using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject target;
    public List<GameObject> Targets;
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}

