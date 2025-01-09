using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndDamageWater : MonoBehaviour
{
    public float stunDuration = 2f;
    public int damage = 1;
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;

    hunger_bar hb = null;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !isStunned)
        {
            HealthSystem HealthSystem = other.GetComponent<HealthSystem>();

            if (HealthSystem != null)
            {
                HealthSystem.TakeDamage(damage);
                hb = FindObjectOfType<hunger_bar>();
                hb.RefillWater();
            }

            StartCoroutine(Stun());
        }

    }

    private IEnumerator Stun()
    {
        isStunned = true;
        navMeshAgent.isStopped = true;

        yield return new WaitForSeconds(stunDuration); 

        navMeshAgent.isStopped = false; 
        isStunned = false;
    }
}
