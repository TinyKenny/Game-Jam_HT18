using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    private float ProjectileSpeed = 7.5f;
    private float Range = 10.0f;
    private Vector3 OriginPosition;

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
}
