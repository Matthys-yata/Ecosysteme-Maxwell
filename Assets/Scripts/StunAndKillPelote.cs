using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndKillPelote : MonoBehaviour
{
    public float stunDuration = 3f;
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pelote") && !isStunned)
        {
            KillPelote(other.gameObject);
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

    private void KillPelote(GameObject Pelote)
    {
        Destroy(Pelote);
    }
}
