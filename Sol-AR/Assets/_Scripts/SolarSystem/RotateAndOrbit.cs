using UnityEngine;

public class RotateAndOrbit : MonoBehaviour
{
    public float RotationSpeed = 100f;
    public float OrbitSpeed = 50f;
    public float DesiredMoonDistance;
    public Transform target;
    
    void Start()
    {
        DesiredMoonDistance = Vector3.Distance(target.position, transform.position);
        target = GameObject.FindWithTag("sun").transform;
        if (target)
        {
            if (target.gameObject.activeInHierarchy)
            {
                // transform.parent = sun.transform;
                //targetFound = true;
            }
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.up, OrbitSpeed * Time.deltaTime);

        //fix possible changes in distance
        float currentMoonDistance = Vector3.Distance(target.position, transform.position);
        Vector3 towardsTarget = transform.position - target.position;
        transform.position += (DesiredMoonDistance - currentMoonDistance) * towardsTarget.normalized;
    }
}