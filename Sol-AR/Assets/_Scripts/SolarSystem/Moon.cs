using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

    public float speed;

    private GameObject planet;
    private bool planetFound;

	// Use this for initialization
	void Start () {
        planet = GameObject.FindWithTag("planet");
        if (planet)
        {
            if (planet.activeInHierarchy)
            {
               // transform.parent = planet.transform;
                planetFound = true;
            }
        }
	}

    void Update()
    {
        if (planetFound)
        {
            transform.RotateAround(planet.transform.position, Vector3.up, speed * Time.deltaTime);
            transform.RotateAround(planet.transform.position, Vector3.right, speed * Time.deltaTime);
        }
    }
}