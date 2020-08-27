using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelectBackgroundMover : MonoBehaviour
{
    [SerializeField]
    private RectTransform planetScrollRect;
    [SerializeField]
    private float parallaxAmount;

    private RectTransform ownRect;

    private void Start()
    {
        ownRect = (RectTransform)gameObject.transform;
    }

    private void Update()
    {
        ownRect.anchoredPosition = (planetScrollRect.anchoredPosition * parallaxAmount);
    }

}
