using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public Text healthText;
    public float healthMax;
    void Start()
    {
        healthText.text = health + "/" + healthMax;
        healthBar.fillAmount = health / healthMax;
    }

    public void AddHealth(int number)
    {
        if (health + number < healthMax)
        {
            health += number;
        }
        else
        {
            health = healthMax;
        }
        healthText.text = health + "/" + healthMax;
        healthBar.fillAmount = health / healthMax;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health < 1)
        {
            health = 0;
        }
        healthText.text = health + "/" + healthMax;
        healthBar.fillAmount = health / healthMax;

    }

    void Update()
    {
        
    }
}
