using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndKillMouse : MonoBehaviour
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
        if (other.CompareTag("Mouse") && !isStunned)
        {
            KillMouse(other.gameObject); 
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

    private void KillMouse(GameObject mouse)
    {
        Destroy(mouse);
    }
}
