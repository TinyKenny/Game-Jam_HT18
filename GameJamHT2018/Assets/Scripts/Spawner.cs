using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public bool IncrementHealth = false;
    public GameObject TargetDummyPrefab;

    private GameObject CurrentDummy;
    private float SpawnDelay = 2.0f;
    private float TimeUntillSpawn = 0.0f;
    private int DummiesSpawned = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentDummy != null)
        {
            return;
        }
        else
        {
            TimeUntillSpawn -= Time.deltaTime;
            if (TimeUntillSpawn <= 0.0f)
            {
                CurrentDummy = Instantiate(TargetDummyPrefab, transform.position, Quaternion.identity);
                if (IncrementHealth)
                {
                    CurrentDummy.GetComponent<Destructible>().IncreaseMaxHealth(DummiesSpawned/2);
                }
                DummiesSpawned++;
                TimeUntillSpawn = SpawnDelay;
            }
        }
	}
}
