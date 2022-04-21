using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public interface IDamagable
{
  int currentHealth { get; set; }
  void Damage(int damagePoints);
  
}
