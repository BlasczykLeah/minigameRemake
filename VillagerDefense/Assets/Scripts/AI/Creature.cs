using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour, IMove, IHealth
{
    // All creature variables:
    public int maxHealth, currentHealth;
    public bool dead;

    public float speed;


    // Default methods:

    public virtual void Die()
    {
        Debug.Log(name + " tried to die.");
    }

    public virtual void Heal(int amount)
    {
        Debug.Log(name + " healing for " + amount + ".");
    }

    public virtual void Move()
    {
        Debug.Log(name + " tried to move.");
    }

    public virtual bool TakeDamage(int dmg)
    {
        Debug.Log(name + " took " + dmg + " damage.");
        return false;
    }
}
