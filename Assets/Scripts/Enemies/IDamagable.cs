using UnityEngine;

namespace Enemies
{
  public interface IDamagable
  {
    void Damage(int damagePoints);
  
    Transform GetTransform();

  
  }
}
