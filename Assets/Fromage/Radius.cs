using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public GameObject objectToSpawn;  // L'objet � faire appara�tre
    public float spawnRadius = 10f;    // Le rayon autour de la capsule
    public float spawnInterval = 120f;  // Intervalle entre chaque apparition
    public int maxSpawnCount = 10;    // Nombre maximal d'objets � spawn
    private int currentSpawnCount = 0; // Compteur d'objets spawn�s
    public bool canSpawn = true;      // Permet de contr�ler si le spawn est activ� ou non

    private void Start()
    {
        // Commence � faire appara�tre des objets apr�s un certain d�lai et � intervalles r�guliers
        if (canSpawn)
        {
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
        }
    }

    void SpawnObject()
    { 
        // Calculer une position al�atoire dans un rayon autour de la capsule
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;  // G�n�re une direction al�atoire
        randomDirection.y = 0f;  // Assure que l'objet spawnera � la m�me hauteur (niveau du sol)

        // Ajouter cette direction al�atoire � la position actuelle de la capsule pour obtenir la position de spawn
        Vector3 spawnPosition = transform.position + randomDirection;

        // Instancier l'objet � la position calcul�e
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}

