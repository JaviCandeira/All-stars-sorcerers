using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public interface IDamagable
{
  void Damage(int damagePoints);
  
  Transform GetTransform();

  
}
