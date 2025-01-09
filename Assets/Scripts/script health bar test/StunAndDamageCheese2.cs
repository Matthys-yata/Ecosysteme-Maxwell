using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndDamageCheese2 : MonoBehaviour
{
    public float stunDuration = 2f;
    public int damage = 1;
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;

    hunger_bar hb = null;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        hb = GetComponent<hunger_bar>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cheese") && !isStunned)
        {
            CheeseHealth cheeseHealth = other.GetComponent<CheeseHealth>();

            if (cheeseHealth != null)
            {
                cheeseHealth.TakeDamage(damage);
                hb=FindObjectOfType<hunger_bar>();
                hb.Cheeseeat();
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