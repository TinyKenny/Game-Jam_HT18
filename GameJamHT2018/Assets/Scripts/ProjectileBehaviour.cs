using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    private float ProjectileSpeed = 7.5f;
    private float Range = 10.0f;
    private int BaseDamage = 1;

    private Vector3 OriginPosition;
    private PlayerController Shooter;

	// Use this for initialization
	void Start () {
        OriginPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(OriginPosition, transform.position) > Range)
        {
            Destroy(gameObject);
        }
        transform.Translate(new Vector3(0.0f, 0.0f, 1.0f) * ProjectileSpeed * Time.deltaTime);
	}

    public void SetShooter(PlayerController shooter)
    {
        Shooter = shooter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Destructible HealthScript = other.GetComponent<Destructible>();
            if (HealthScript != null)
            {
                if (Shooter != null)
                {
                    HealthScript.TakeDamageFrom(Shooter);
                }
                else
                {
                    HealthScript.TakeGeneralDamage(BaseDamage);
                }
            }
            Destroy(gameObject);
        }
    }
}
