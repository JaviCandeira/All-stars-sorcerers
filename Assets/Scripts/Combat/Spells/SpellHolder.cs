using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellHolder : MonoBehaviour
{
    public Spell spell;
    public KeyCode key;
    
    public float cooldownTime;
    public float activeFor;
    [SerializeField] private Image imageCoolDown;
    [SerializeField] private TextMeshProUGUI textCoolDown;
    
    enum SpellState
    {
        ready,
        active,
        cooldown
    }

    private SpellState spellState = SpellState.ready;
    

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
                    if (textCoolDown != null)
                    {
                        textCoolDown.gameObject.SetActive(false);
                        imageCoolDown.fillAmount = 0.0f;
                    }
                }

                break;
            case SpellState.active:
                if (activeFor > 0)
                {
                    activeFor -= Time.deltaTime;
                    if (textCoolDown != null)
                    {
                        textCoolDown.gameObject.SetActive(true);
                        imageCoolDown.fillAmount = 0.0f;
                    }
                    
                }
                else
                {
                    spellState = SpellState.cooldown;
                    cooldownTime = spell.cooldown;
                }
                break;
            case SpellState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                    if (textCoolDown != null)
                    {
                        imageCoolDown.fillAmount =  cooldownTime/  activeFor;
                        //textCoolDown.text = Mathf.RoundToInt(cooldownTime).ToString();
                        
                    }
                }
                else
                {
                    spellState = SpellState.ready;
                }
                break;
        }
    }
}
