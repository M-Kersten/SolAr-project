using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFullButton : MonoBehaviour
{
    private void Start()
    {
        if (GameSettings.Instance.FullVersion)
            gameObject.SetActive(false);
    }
}
