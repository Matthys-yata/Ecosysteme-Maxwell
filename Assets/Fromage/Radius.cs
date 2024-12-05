using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public GameObject objectToSpawn;  // L'objet à faire apparaître
    public float spawnRadius = 10f;   // Rayon autour de la position de spawn
    public float spawnInterval = 4f;  // Intervalle entre chaque apparition
    public int maxSpawnCount = 50;     // Nombre maximal d'objets à spawn
    private int currentSpawnCount = 0; // Compteur d'objets spawnés
    public bool canSpawn = true;      // Permet de contrôler si le spawn est activé ou non
    public Transform Player;
    private float timeSinceLastSpawn;

    private void Start()
    {
        // Commence à faire apparaître des objets après un certain délai et à intervalles réguliers
        if (canSpawn)
        {
            InvokeRepeating("Cheese", 0f, spawnInterval);
        }
    }

    private void Update()
    {
        // Vérifie si le nombre d'objets spawnés a atteint la limite
        if (currentSpawnCount >= maxSpawnCount)
        {
            canSpawn = false; // Désactive le spawn
            CancelInvoke("Cheese"); // Annule les appels répétés pour spawn
        }
    }

    private void Cheese()
    { 
        // Calculer une position aléatoire dans un rayon autour de l'objet actuel
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;  // Génère une direction aléatoire
        randomDirection.y = 0f;  // Assure que l'objet spawnera à la même hauteur (niveau du sol)

        // Ajouter cette direction aléatoire à la position actuelle pour obtenir la position de spawn
        Vector3 spawnPosition = transform.position + randomDirection;

        // Instancier l'objet à la position calculée
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Assigner un tag à l'objet spawné
        spawnedObject.tag = "Cheese";  // Assurez-vous que "SpawnedObject" est un tag valide

        // Incrémenter le compteur de spawns
        currentSpawnCount++;
    }
}