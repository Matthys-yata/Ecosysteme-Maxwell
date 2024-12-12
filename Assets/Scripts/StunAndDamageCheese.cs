using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndDamageCheese : MonoBehaviour
{
    public float stunDuration = 2f;
    public int damage = 1;
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cheese") && !isStunned)
        {
            CheeseHealth cheeseHealth = other.GetComponent<CheeseHealth>();

            if (cheeseHealth != null)
            {
                cheeseHealth.TakeDamage(damage);
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
