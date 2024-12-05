using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndKillMouse : MonoBehaviour
{
    public float stunDuration = 3f; // Dur�e du stun en secondes
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si le chat touche un objet avec le tag "Mouse"
        if (other.CompareTag("Mouse") && !isStunned)
        {
            KillMouse(other.gameObject); // Tue la souris
            StartCoroutine(Stun()); // Lance la coroutine de stun
        }
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        navMeshAgent.isStopped = true; // Arr�te le mouvement du chat
        Debug.Log("Chat est stun!");

        yield return new WaitForSeconds(stunDuration); // Attend la dur�e du stun

        navMeshAgent.isStopped = false; // Red�marre le mouvement du chat
        isStunned = false;
        Debug.Log("Chat lib�r� du stun!");
    }

    private void KillMouse(GameObject mouse)
    {
        Destroy(mouse); // D�truit la souris
        Debug.Log("Souris tu�e!");
    }
}
