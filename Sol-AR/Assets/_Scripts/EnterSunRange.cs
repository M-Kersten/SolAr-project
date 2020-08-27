using UnityEngine;

public class EnterSunRange : MonoBehaviour
{
    [HideInInspector]
    public Transform cameraPos;
    public float radius;
    private bool triggered = false;
    private float dist;

    void Start()
    {
        cameraPos = ARCamera.Instance.CameraTransform;
    }

    void Update()
    {
        dist = Vector3.Distance(cameraPos.position, transform.position);
        if (dist < radius * ViewPlanet.Instance.SolarSystemScale && !triggered)
        {
            triggered = true;
            ViewPlanet.Instance.SunCanvas.SetActive(true);
        }
        if (dist > radius * ViewPlanet.Instance.SolarSystemScale && triggered)
        {
            triggered = false;
            ViewPlanet.Instance.SunCanvas.SetActive(false);
        }
    }
}
