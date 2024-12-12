using UnityEngine;

public class FromagerMovement : MonoBehaviour
{
    // D�clare un tableau de 4 points pr�d�finis pour le parcours
    public Transform[] pathPoints;

    // Vitesse de d�placement
    public float moveSpeed = 3f;

    // Index du point actuel du parcours
    private int currentPointIndex = 0;

    void Start()
    {
        // Initialisation des 4 points pr�d�finis dans le tableau pathPoints
        pathPoints = new Transform[4];

        // Vous pouvez d�finir les points directement ici, en modifiant les positions
        // Cr�ez des objets vides dans la sc�ne et assignez-les � ces variables
        pathPoints[0] = CreatePoint(new Vector3(0, 1, 0));  // Point 1
        pathPoints[1] = CreatePoint(new Vector3(10, 1, 0)); // Point 2
        pathPoints[2] = CreatePoint(new Vector3(10, 1, 10)); // Point 3
        pathPoints[3] = CreatePoint(new Vector3(0, 1, 10)); // Point 4
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
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // M�thode pour cr�er un objet vide � une position donn�e
    Transform CreatePoint(Vector3 position)
    {
        GameObject point = new GameObject("Point"); // Cr�e un nouvel objet vide
        point.transform.position = position;         // D�finit sa position
        return point.transform;                       // Retourne le transform de l'objet
    }
}
