using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    IHealth FindTarget();

    IEnumerable Attack();   // deals damage from saved 'target'
}
