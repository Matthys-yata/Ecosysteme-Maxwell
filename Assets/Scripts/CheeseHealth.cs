using UnityEngine;

public class CheeseHealth : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
