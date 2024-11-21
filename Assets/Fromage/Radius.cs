using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public GameObject objectToSpawn;  // L'objet à faire apparaître
    public float spawnRadius = 10f;    // Le rayon autour de la capsule
    public float spawnInterval = 120f;  // Intervalle entre chaque apparition
    public int maxSpawnCount = 10;    // Nombre maximal d'objets à spawn
    private int currentSpawnCount = 0; // Compteur d'objets spawnés
    public bool canSpawn = true;      // Permet de contrôler si le spawn est activé ou non

    private void Start()
    {
        // Commence à faire apparaître des objets après un certain délai et à intervalles réguliers
        if (canSpawn)
        {
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
        }
    }

    void SpawnObject()
    { 
        // Calculer une position aléatoire dans un rayon autour de la capsule
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;  // Génère une direction aléatoire
        randomDirection.y = 0f;  // Assure que l'objet spawnera à la même hauteur (niveau du sol)

        // Ajouter cette direction aléatoire à la position actuelle de la capsule pour obtenir la position de spawn
        Vector3 spawnPosition = transform.position + randomDirection;

        // Instancier l'objet à la position calculée
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}

