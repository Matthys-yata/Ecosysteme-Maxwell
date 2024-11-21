using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
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
                Debug.Log($"{gameObject.name} inflige {damage} de d�g�ts � {collision.gameObject.name}.");
            }
        }
    }
}

