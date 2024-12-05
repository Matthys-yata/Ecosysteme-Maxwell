using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StunAndDamageCheese : MonoBehaviour
{
    public float stunDuration = 2f; // Durée du stun en secondes
    public int damage = 1; // Dégâts infligés au fromage
    private NavMeshAgent navMeshAgent;
    private bool isStunned = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si la souris touche un fromage et n'est pas déjà stun
        if (other.CompareTag("Cheese") && !isStunned)
        {
            CheeseHealth cheeseHealth = other.GetComponent<CheeseHealth>();

            if (cheeseHealth != null)
            {
                cheeseHealth.TakeDamage(damage); // Inflige des dégâts au fromage
            }

            StartCoroutine(Stun()); // Lance la coroutine de stun
        }
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        navMeshAgent.isStopped = true; // Arrête le mouvement
        Debug.Log("Souris est stun!");

        yield return new WaitForSeconds(stunDuration); // Attend la fin du stun

        navMeshAgent.isStopped = false; // Redémarre le mouvement
        isStunned = false;
        Debug.Log("Souris libérée du stun!");
    }
}
