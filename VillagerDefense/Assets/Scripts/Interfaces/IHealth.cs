using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    bool TakeDamage(int dmg);

    void Heal(int amount);

    void Die();
}
