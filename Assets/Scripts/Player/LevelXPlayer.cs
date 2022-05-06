using Enemies;
using UnityEngine;
using UnityEngine.UI;

public class LevelXPlayer : MonoBehaviour, IDamagable, IKillable
{
      
    public int maxMana;
    public Slider Slider;
    [SerializeField] private string onEnableStr;
    [SerializeField] private string onDisableStr;
    private int CurrentHealth { get; set; }

    private void Start()
    {
        
    }
    
    public void SetHealth(int health)
    {
        Slider.value = health;
    }

    private void OnEnable()
    {
        CurrentHealth = PlayerPrefs.GetInt(onEnableStr);
        SetHealth(CurrentHealth);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(onDisableStr,CurrentHealth);
    }

    public void Damage(int damagePoints)
    {
        
        CurrentHealth -= damagePoints;
        SetHealth(CurrentHealth);
        // Debug.Log("Oh noooo!: " + CurrentHealth);
        if(CurrentHealth <= 0)
        {
            Perish();
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Perish()
    {
        Debug.Log("Dead");
    }   
        
}
