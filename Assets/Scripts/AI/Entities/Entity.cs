using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public int health;
    public int owner;

    public abstract void Die();
}
