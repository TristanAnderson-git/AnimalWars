using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public int health;
    public int owner = -1;

    protected void CheckHealth()
    {
        if (health <= 0)
            Die();
    }

    public abstract void Die();
}
