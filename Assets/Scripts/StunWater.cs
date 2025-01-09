using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunWater : MonoBehaviour
{
    public float stunDuration = 3f;
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;
    public hunger_bar _hunger_Bar;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !isStunned)
        {
            KillWater(other.gameObject);
            _hunger_Bar.RefillWater();
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

    private void KillWater(GameObject Water)
    {
        Destroy(Water);
    }
}
