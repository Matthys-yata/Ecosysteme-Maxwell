using UnityEngine;
using UnityEngine.AI;

public class MouvementDirection : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        // R�cup�re le NavMeshAgent attach� � l'objet
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // V�rifie si l'agent est en mouvement
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            // Oriente le personnage dans la direction de la vitesse
            Vector3 direction = agent.velocity.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }
}
