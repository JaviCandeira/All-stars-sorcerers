using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    public Spell spell;
    public KeyCode key;
    
    public float cooldownTime;
    public float activeFor;

    private Animator _animator;
    private float animSpeed;
    
    enum SpellState
    {
        ready,
        active,
        cooldown
    }

    private SpellState spellState = SpellState.ready;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        animSpeed = _animator.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (spellState)
        {
            case SpellState.ready:
                if (Input.GetKeyDown(key))
                {
                    spell.Activate(gameObject);
                    spellState = SpellState.active;
                    activeFor = spell.activeFor;
                    _animator.speed = 0;
                }

                break;
            case SpellState.active:
                if (activeFor > 0)
                {
                    activeFor -= Time.deltaTime;
                }
                else
                {
                    _animator.speed = animSpeed;
                    spellState = SpellState.cooldown;
                    cooldownTime = spell.cooldown;
                }
                break;
            case SpellState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    spellState = SpellState.ready;
                }
                break;
        }
    }
}
