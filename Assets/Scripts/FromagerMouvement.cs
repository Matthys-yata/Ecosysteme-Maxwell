using UnityEngine;

public class FromagerMovement : MonoBehaviour
{
    // Déclare un tableau de 4 points prédéfinis pour le parcours
    public Transform[] pathPoints;

    // Vitesse de déplacement
    public float moveSpeed = 3f;

    // Index du point actuel du parcours
    private int currentPointIndex = 0;

    void Start()
    {
        // Initialisation des 4 points prédéfinis dans le tableau pathPoints
        pathPoints = new Transform[4];

        // Vous pouvez définir les points directement ici, en modifiant les positions
        // Créez des objets vides dans la scène et assignez-les à ces variables
        pathPoints[0] = CreatePoint(new Vector3(0, 1, 0));  // Point 1
        pathPoints[1] = CreatePoint(new Vector3(10, 1, 0)); // Point 2
        pathPoints[2] = CreatePoint(new Vector3(10, 1, 10)); // Point 3
        pathPoints[3] = CreatePoint(new Vector3(0, 1, 10)); // Point 4
    }

    void Update()
    {
        if (pathPoints.Length > 0)
        {
            // Déplacer le fromager vers le point actuel
            MoveTowards(pathPoints[currentPointIndex].position);

            // Si on arrive au point actuel, passer au suivant
            if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) < 0.5f)
            {
                // Passer au point suivant
                currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
            }
        }
    }

    // Fonction pour déplacer le fromager vers un point donné
    void MoveTowards(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // Méthode pour créer un objet vide à une position donnée
    Transform CreatePoint(Vector3 position)
    {
        GameObject point = new GameObject("Point"); // Crée un nouvel objet vide
        point.transform.position = position;         // Définit sa position
        return point.transform;                       // Retourne le transform de l'objet
    }
}
