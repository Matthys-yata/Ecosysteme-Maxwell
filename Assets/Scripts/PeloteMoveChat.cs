using UnityEngine;
using UnityEngine.AI;

public class PeloteMoveChat : MonoBehaviour
{
    public float radius = 10f;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        GameObject closestPelote = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Pelote"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPelote = collider.gameObject;
                }
            }
        }

        if (closestPelote != null)
        {
            navMeshAgent.SetDestination(closestPelote.transform.position);
        }
    }
}
