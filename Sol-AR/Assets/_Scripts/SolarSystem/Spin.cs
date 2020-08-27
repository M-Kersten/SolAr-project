using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private Vector3 rotationForce;
    public float rotationSpeed;

    private void Start()
    {
        rotationForce = new Vector3(0, rotationSpeed, 0);
    }

    void Update ()
    {

        transform.Rotate(rotationForce * Time.deltaTime);
	}
}
