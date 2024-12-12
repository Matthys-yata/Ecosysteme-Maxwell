using System.Collections;
using UnityEngine;

public class TrapMouse : MonoBehaviour
{
    public bool IsAvailable = true; // Le piège est actif ou non
    public float CooldownDuration = 10.0f; // Temps de recharge du piège

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le piège est disponible et si l'objet entrant est une souris
        if (IsAvailable && other.CompareTag("Mouse"))
        {
            ActivateTrap(other.gameObject);
        }
    }

    private void ActivateTrap(GameObject mouse)
    {
        // Détruit la souris
        Destroy(mouse);

        // Lance le cooldown pour désactiver temporairement le piège
        StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        IsAvailable = false; // Désactive le piège
        yield return new WaitForSeconds(CooldownDuration); // Attend la fin du cooldown
        IsAvailable = true; // Réactive le piège
    }
}
