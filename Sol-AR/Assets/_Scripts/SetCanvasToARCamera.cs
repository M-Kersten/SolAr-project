using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class SetCanvasToARCamera : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Canvas>().worldCamera = ARCamera.Instance.Camera;
    }

    void OnDisable()
    {
        GetComponent<Canvas>().worldCamera = null;
    }
}
