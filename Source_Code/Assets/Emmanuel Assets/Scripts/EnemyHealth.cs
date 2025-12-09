using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public Sprite[] healthBar;
    public Image healthBarImage;
    
    public int healthMax = 7;
    public int healthCurrent;
    
    public int damage;
    public Animator anim;
    
    void Start()
    {
        healthCurrent = healthMax;
        UpdateHealthBar();
       
    }

    public void UpdateHealthBar()
    {
        int spriteIndex = Mathf.Clamp(healthCurrent - 1, 0, healthBar.Length - 1);
        healthBarImage.sprite = healthBar[spriteIndex];
        Die();
    }

    public void Die()
    {
        if (healthCurrent <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
    public void AddHealth(int number)
    {
        if (healthCurrent + number < healthMax)
        {
            healthCurrent += number;
        }
        else
        {
            healthCurrent = healthMax;
        }
      
    }

    public void Damage(int damage)
    {
        healthCurrent -= damage;
        healthCurrent = Mathf.Clamp(healthCurrent, 0, healthMax);
        UpdateHealthBar();
        

    }
}
