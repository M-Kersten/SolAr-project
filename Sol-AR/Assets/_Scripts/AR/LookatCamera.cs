using UnityEngine;

public class LookatCamera : MonoBehaviour
{
    private Transform target;

    private void Awake() => target = ARCamera.Instance.CameraTransform;

    private void Update()
    {
        if (target != null)
            transform.LookAt(target);
    }
}
