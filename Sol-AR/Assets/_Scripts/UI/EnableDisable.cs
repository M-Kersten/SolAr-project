using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public void EnableDisableNow() => gameObject.SetActive(!gameObject.activeInHierarchy);
}
