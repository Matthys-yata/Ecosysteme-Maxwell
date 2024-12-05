using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public GameObject objectToSpawn;  // L'objet � faire appara�tre
    public float spawnRadius = 10f;   // Rayon autour de la position de spawn
    public float spawnInterval = 4f;  // Intervalle entre chaque apparition
    public int maxSpawnCount = 50;     // Nombre maximal d'objets � spawn
    private int currentSpawnCount = 0; // Compteur d'objets spawn�s
    public bool canSpawn = true;      // Permet de contr�ler si le spawn est activ� ou non
    public Transform Player;
    private float timeSinceLastSpawn;

    private void Start()
    {
        // Commence � faire appara�tre des objets apr�s un certain d�lai et � intervalles r�guliers
        if (canSpawn)
        {
            InvokeRepeating("Cheese", 0f, spawnInterval);
        }
    }

    private void Update()
    {
        // V�rifie si le nombre d'objets spawn�s a atteint la limite
        if (currentSpawnCount >= maxSpawnCount)
        {
            canSpawn = false; // D�sactive le spawn
            CancelInvoke("Cheese"); // Annule les appels r�p�t�s pour spawn
        }
    }

    private void Cheese()
    { 
        // Calculer une position al�atoire dans un rayon autour de l'objet actuel
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;  // G�n�re une direction al�atoire
        randomDirection.y = 0f;  // Assure que l'objet spawnera � la m�me hauteur (niveau du sol)

        // Ajouter cette direction al�atoire � la position actuelle pour obtenir la position de spawn
        Vector3 spawnPosition = transform.position + randomDirection;

        // Instancier l'objet � la position calcul�e
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Assigner un tag � l'objet spawn�
        spawnedObject.tag = "Cheese";  // Assurez-vous que "SpawnedObject" est un tag valide

        // Incr�menter le compteur de spawns
        currentSpawnCount++;
    }
}