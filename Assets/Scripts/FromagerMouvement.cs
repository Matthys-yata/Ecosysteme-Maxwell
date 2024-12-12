using UnityEngine;

public class FromagerMovement : MonoBehaviour
{
    // D�clare un tableau de 4 points pr�d�finis pour le parcours
    public Transform[] pathPoints;

    // Vitesse de d�placement
    public float moveSpeed = 3f;

    // Vitesse de rotation
    public float rotationSpeed = 100f;

    // Index du point actuel du parcours
    private int currentPointIndex = 0;

    void Start()
    {
        // Initialisation des 4 points pr�d�finis dans le tableau pathPoints
        pathPoints = new Transform[4];

        // D�finir les points de parcours
        pathPoints[0] = CreatePoint(new Vector3(0, 0, 0));  // Point 1
        pathPoints[1] = CreatePoint(new Vector3(10, 0, 0)); // Point 2
        pathPoints[2] = CreatePoint(new Vector3(10, 0, 10)); // Point 3
        pathPoints[3] = CreatePoint(new Vector3(0, 0, 10)); // Point 4

        // Forcer l'orientation initiale du mod�le face � l'axe X
        Vector3 initialDirection = pathPoints[1].position - pathPoints[0].position; // Direction vers le premier point
        if (initialDirection.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(initialDirection); // Tourner le mod�le face � cette direction
        }
    }

    void Update()
    {
        if (pathPoints.Length > 0)
        {
            // D�placer le fromager vers le point actuel
            MoveTowards(pathPoints[currentPointIndex].position);

            // Si on arrive au point actuel, passer au suivant
            if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) < 0.5f)
            {
                // Passer au point suivant
                currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
            }
        }
    }

    // Fonction pour d�placer le fromager vers un point donn�
    void MoveTowards(Vector3 targetPosition)
    {
        // Calculer la direction vers le point cible
        Vector3 moveDirection = targetPosition - transform.position;

        // Normaliser la direction pour �viter des vitesses variables selon la distance
        moveDirection.Normalize();

        // D�placer le personnage
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Afficher la direction de mouvement pour le d�bogage
        Debug.DrawRay(transform.position, moveDirection * 2, Color.green);

        // Faire tourner le personnage vers la direction du mouvement
        if (moveDirection.magnitude > 0.1f)
        {
            // Calculer la rotation n�cessaire pour regarder dans la direction du mouvement
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // Appliquer une rotation fluide sur l'axe Y (autour de l'axe vertical)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // M�thode pour cr�er un objet vide � une position donn�e
    Transform CreatePoint(Vector3 position)
    {
        GameObject point = new GameObject("Point"); // Cr�e un nouvel objet vide
        point.transform.position = position;         // D�finit sa position
        return point.transform;                       // Retourne le transform de l'objet
    }
}
