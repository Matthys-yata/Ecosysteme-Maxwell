using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTargetWithNavMesh : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent non trouv� ! Ajoutez-en un via l'Inspector.");
            enabled = false;
            return;
        }

        if (target == null)
        {
            Debug.LogError("Aucune cible assign�e ! Assignez une cible dans l'Inspector.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
