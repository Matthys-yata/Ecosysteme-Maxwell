using UnityEngine;
using UnityEngine.AI;

public class SourisMoveWater : MonoBehaviour
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

        GameObject closestWater = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Water"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestWater = collider.gameObject;
                }
            }
        }

        if (closestWater != null)
        {
            navMeshAgent.SetDestination(closestWater.transform.position);
        }
    }
}
