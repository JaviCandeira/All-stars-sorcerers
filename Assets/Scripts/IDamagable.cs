using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public interface IDamagable
{
  Stats stats { get; set; }
  void Damage(int damagePoints);
}
