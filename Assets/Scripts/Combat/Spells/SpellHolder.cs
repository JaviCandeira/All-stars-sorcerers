using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Combat.Spells
{
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
            Ready,
            Active,
            Cooldown
        }

        private SpellState _spellState = SpellState.Ready;
    

        // Update is called once per frame
        void Update()
        {
        
            switch (_spellState)
            {
                case SpellState.Ready:
                    if (Input.GetKeyDown(key))
                    {
                        spell.Activate(gameObject);
                        _spellState = SpellState.Active;
                        activeFor = spell.activeFor;
                        if (textCoolDown != null)
                        {
                            textCoolDown.gameObject.SetActive(false);
                            imageCoolDown.fillAmount = 0.0f;
                        }
                    }

                    break;
                case SpellState.Active:
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
                        _spellState = SpellState.Cooldown;
                        cooldownTime = spell.cooldown;
                    }
                    break;
                case SpellState.Cooldown:
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
                        _spellState = SpellState.Ready;
                    }
                    break;
            }
        }
    }
}
