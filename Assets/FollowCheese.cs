using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowCheese : MonoBehaviour
{
    private Vector3 targetPosition; // Vector pour diriger l'IA vers le point le plus proche

    private NavMeshAgent directionNavAgent;

    public List<GameObject> Targets; // Liste des objectifs

    public GameObject closest; // Censé être la cible la plus proche

    public GameObject Actual; // Censé être la cible atteinte par l'IA

    public bool TargetGet = false; // Pour savoir si l'IA a touché le trigger de l'objectif.

    public bool Atteint = false; // Bool secondaire pour savoir si l'IA a atteint l'objectif et est prête à repartir vers l'objectif suivant.

    void Start()
    {
        FindTargets(); // Charge toutes les entités avec le tag objectif dans la liste dès le départ
    }

    void Update()
    {
        MoveToClosest(); // Déplacement constant vers la cible la plus proche

        if (TargetGet == true)
        {
            ChangeTarget(); // Retirer l'objet actuel de la liste et choisir une nouvelle cible
        }

        if (Atteint == true)
        {
            FindClosestTarget(); // Trouver la cible la plus proche
            Debug.Log("Change de cible");
        }

        // Vérifier si la cible actuelle a été détruite pour en choisir une nouvelle
        if (Actual == null && Targets.Count > 0)
        {
            FindClosestTarget(); // Si la cible actuelle est détruite, trouver la cible la plus proche
        }
    }

    void MoveToClosest() // Déplacement vers la cible la plus proche
    {
        directionNavAgent = GetComponent<NavMeshAgent>();
        FindClosestTarget();
        directionNavAgent.destination = targetPosition;
    }

    void OnTriggerEnter(Collider other) // Active le bool TargetGet lorsque la cible est touchée
    {
        if (other.tag == "Cheese")
        {
            Debug.Log("Cible touchée");
            TargetGet = true;
        }
    }

    void FindTargets() // Trouve les objets ayant le tag "Cheese"
    {
        Targets = new List<GameObject>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Cheese"))
        {
            Targets.Add(go);
        }
    }

    void ChangeTarget() // Enlève la Target la plus proche pour la remplacer par la suivante
    {
        if (Targets.Count == 0) return; // Si la liste est vide, on ne fait rien

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        // Trouver le fromage le plus proche parmi les targets restantes
        foreach (GameObject go in Targets)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                Actual = go; // Met à jour la cible actuelle
                Targets.Remove(Actual); // Retire la cible actuelle de la liste des objectifs
                Atteint = true; // Marque comme atteint
            }
        }
        Debug.Log("Cible actuelle enlevée");
    }

    void FindClosestTarget() // Trouve la cible la plus proche parmi les targets restantes
    {
        if (Targets.Count == 0) return; // Si la liste des cibles est vide, on ne fait rien

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in Targets)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                targetPosition = closest.transform.position; // Mise à jour de la destination vers la cible la plus proche
            }
        }
    }
}
