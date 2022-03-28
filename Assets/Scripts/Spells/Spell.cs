using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject
{
    public new string name;
    public float cooldown;
    public float activeFor;

    public virtual void Activate(GameObject parent)
    {
        
    }
}
