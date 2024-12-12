using System.Collections;
using UnityEngine;

public class TrapMouse : MonoBehaviour
{
    public bool IsAvailable = true; // Le pi�ge est actif ou non
    public float CooldownDuration = 10.0f; // Temps de recharge du pi�ge

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si le pi�ge est disponible et si l'objet entrant est une souris
        if (IsAvailable && other.CompareTag("Mouse"))
        {
            ActivateTrap(other.gameObject);
        }
    }

    private void ActivateTrap(GameObject mouse)
    {
        // D�truit la souris
        Destroy(mouse);

        // Lance le cooldown pour d�sactiver temporairement le pi�ge
        StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        IsAvailable = false; // D�sactive le pi�ge
        yield return new WaitForSeconds(CooldownDuration); // Attend la fin du cooldown
        IsAvailable = true; // R�active le pi�ge
    }
}
