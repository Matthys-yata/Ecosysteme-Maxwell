using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FromagerMoveTurn : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform[] pathPoints; // Tableau des points de destination
    private int currentPointIndex = 0; // Index du point actuel

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Création dynamique des points
        pathPoints = new Transform[4]; // 4 points définis
        pathPoints[0] = CreatePoint(new Vector3(0, 1, 0));    // Point 1
        pathPoints[1] = CreatePoint(new Vector3(10, 1, 0));   // Point 2
        pathPoints[2] = CreatePoint(new Vector3(10, 1, 10));  // Point 3
        pathPoints[3] = CreatePoint(new Vector3(0, 1, 10));   // Point 4

        // Démarre en se déplaçant vers le premier point
        if (pathPoints.Length > 0)
        {
            agent.SetDestination(pathPoints[currentPointIndex].position);
        }
    }

    void Update()
    {
        // Si l'agent a atteint sa destination, passe au point suivant
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            GoToNextPoint();
        }

        // Oriente le personnage dans la direction du mouvement
        if (agent.velocity.sqrMagnitude > 0.1f) // Si l'agent se déplace
        {
            Vector3 direction = agent.velocity.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }

    // Crée un point sous forme de Transform
    private Transform CreatePoint(Vector3 position)
    {
        GameObject point = new GameObject("PathPoint");
        point.transform.position = position;
        return point.transform;
    }

    // Passe au point suivant
    void GoToNextPoint()
    {
        if (pathPoints.Length == 0) return; // Pas de points définis, ne fait rien

        // Passe au point suivant (boucle au début si nécessaire)
        currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
        agent.SetDestination(pathPoints[currentPointIndex].position);
    }
}
