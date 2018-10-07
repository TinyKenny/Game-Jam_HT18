using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public int MaxHealth = 3;
    public int Health;

    private PlayerController MostRecentAttacker;

	// Use this for initialization
	void Start () {
        Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void TakeDamageFrom(PlayerController Attacker)
    {
        Health -= Attacker.AttackDamage;
        if (Health <= 0)
        {
            Attacker.LevelUp();
            Destroy(gameObject);
        }
        else
        {
            MostRecentAttacker = Attacker;
        }
    }

    public void TakeGeneralDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            if (MostRecentAttacker != null)
            {
                MostRecentAttacker.LevelUp();
            }
            Destroy(gameObject);
        }
    }

    public void IncreaseMaxHealth(int MaxHealthIncrease)
    {
        MaxHealth += MaxHealthIncrease;
        Health = MaxHealth;
    }

}
