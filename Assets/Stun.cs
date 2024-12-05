using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndDamageCheese : MonoBehaviour
{
    public float stunDuration = 2f; // Dur�e du stun en secondes
    public int damage = 1; // D�g�ts inflig�s au fromage
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si la souris touche un fromage et n'est pas d�j� stun
        if (other.CompareTag("Cheese") && !isStunned)
        {
            CheeseHealth cheeseHealth = other.GetComponent<CheeseHealth>();

            if (cheeseHealth != null)
            {
                cheeseHealth.TakeDamage(damage); // Inflige des d�g�ts au fromage
            }

            StartCoroutine(Stun()); // Lance la coroutine de stun
        }
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        navMeshAgent.isStopped = true; // Arr�te le mouvement
        Debug.Log("Souris est stun!");

        yield return new WaitForSeconds(stunDuration); // Attend la fin du stun

        navMeshAgent.isStopped = false; // Red�marre le mouvement
        isStunned = false;
        Debug.Log("Souris lib�r�e du stun!");
    }
}
