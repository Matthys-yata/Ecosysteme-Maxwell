using UnityEngine;

public class CheeseHealth : MonoBehaviour
{
    public int health = 1; // Points de vie du fromage

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Fromage a pris " + amount + " d�g�ts!");

        if (health <= 0)
        {
            Destroy(gameObject); // D�truit le fromage si la sant� atteint 0
            Debug.Log("Fromage d�truit!");
        }
    }
}
