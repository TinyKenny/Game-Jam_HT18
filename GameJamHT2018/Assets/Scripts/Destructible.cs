using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public int MaxHealth = 3;
    public int Health;

	// Use this for initialization
	void Start () {
        Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
