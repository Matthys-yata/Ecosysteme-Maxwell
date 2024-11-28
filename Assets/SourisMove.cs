using UnityEngine;
using UnityEngine.AI;

public class SourisMove : MonoBehaviour
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

        GameObject closestCheese = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Cheese"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCheese = collider.gameObject;
                }
            }
        }

        if (closestCheese != null)
        {
            navMeshAgent.SetDestination(closestCheese.transform.position);
        }
    }
}
