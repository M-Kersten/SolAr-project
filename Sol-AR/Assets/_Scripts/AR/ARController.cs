using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System.Collections;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    /// <summary>
    /// The first-person camera being used to render the passthrough camera image (i.e. AR background).
    /// </summary>
    public GameObject FirstPersonCamera;

    public Transform spawnTransform;

    /// <summary>
    /// A model to place when a raycast from a user touch hits a plane.
    /// </summary>
    public GameObject[] ObjectPrefab;

    public GameObject solarSystem;

    private GameObject spawnedSolarSystem;

    private List<GameObject> activeObjects = new List<GameObject>();
    private List<GameObject> objectAnchors = new List<GameObject>();

    private List<ARReferencePoint> activeAnchors = new List<ARReferencePoint>();

    [SerializeField]
    private ARSession m_Session;
    [SerializeField]
    private ARReferencePointManager anchormanager;

    [SerializeField]
    private Slider scaleSlider;
    
    private void Start()
    {
        scaleSlider.onValueChanged.AddListener((value) => ScaleSolarSystem(value));
    }
    public void SpawnObject(int number)
    {
        Vector3 objectPos = new Vector3(spawnTransform.position.x, FirstPersonCamera.transform.position.y, spawnTransform.position.z);
        Pose cameraPose;
        cameraPose.position = objectPos;
        cameraPose.rotation = FirstPersonCamera.transform.localRotation;
        var newObject = Instantiate(ObjectPrefab[number], objectPos, FirstPersonCamera.transform.localRotation);
        
        activeObjects.Add(newObject);
    }

    public void SpawnSolarSystem()
    {
        Vector3 objectPos = new Vector3(spawnTransform.position.x, FirstPersonCamera.transform.position.y, spawnTransform.position.z);
        Pose cameraPose;
        cameraPose.position = objectPos;
        cameraPose.rotation = FirstPersonCamera.transform.localRotation;
        GameObject newObject = Instantiate(solarSystem, objectPos, Quaternion.identity);
        spawnedSolarSystem = newObject;
        ViewPlanet.Instance.solarSystem = newObject;
        ViewPlanet.Instance.solarSytemFadeIn = newObject.GetComponent<FadeInObject>();
        foreach (GameObject item in objectAnchors)
        {
            Destroy(item);
        }
        Pose pose = new Pose(spawnedSolarSystem.transform.position, Quaternion.identity);
        var anchor = anchormanager.AddReferencePoint(pose);
        activeAnchors.Add(anchor);
    }

    private void ScaleSolarSystem(float scale)
    {
        spawnedSolarSystem.transform.localScale = Vector3.one * scale;
        ViewPlanet.Instance.SolarSystemScale = scale;
    }

    public void ResetActiveObjects()
    {
        foreach (ARReferencePoint anchor in activeAnchors)
        {
            anchormanager.RemoveReferencePoint(anchor);
        }
        foreach (GameObject item in activeObjects)
        {
            Destroy(item);
        }        
        activeObjects.Clear();
    }
    
    /// <summary>
    /// Actually quit the application.
    /// </summary>
    private void _DoQuit()
    {
        Application.Quit();
    }
}