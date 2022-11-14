using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damage;
    public int armor;

    public event System.Action<int, int> OnHealthChanged;

    public void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void takeDamage(int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        Debug.Log(transform.name + " took " + damage + " damage");

        if (OnHealthChanged != null)
            OnHealthChanged(maxHealth, currentHealth);

        if (currentHealth <= 0)
            dead();
    }

    public virtual void recoverHealth(int heal)
    {
        if(currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        } else
        {
            currentHealth += heal;
        }

        OnHealthChanged(maxHealth, currentHealth);
    }

    public virtual void dead()
    {
        Debug.Log(transform.name + " died");
    }
}
