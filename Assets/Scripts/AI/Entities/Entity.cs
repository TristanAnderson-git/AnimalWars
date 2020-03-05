using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public int health;
    public int owner;

    protected void CheckHealth()
    {
        if (health <= 0)
            Die();
    }

    public abstract void Die();
}
