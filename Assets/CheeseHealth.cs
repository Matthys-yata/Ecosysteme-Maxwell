using UnityEngine;

public class CheeseHealth : MonoBehaviour
{
    public int health = 1; // Points de vie du fromage

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Fromage a pris " + amount + " dégâts!");

        if (health <= 0)
        {
            Destroy(gameObject); // Détruit le fromage si la santé atteint 0
            Debug.Log("Fromage détruit!");
        }
    }
}
