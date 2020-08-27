using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AnimateBackground : MonoBehaviour
{
    public float animationSpeed;
    private Image backgroundImg;
    private Vector2 backgroundPosition;

	void Start () {
        backgroundImg = GetComponent<Image>();
        backgroundImg.material.mainTextureOffset = new Vector2(0, 0);
    }

	void Update () {
        backgroundPosition = new Vector2(Time.deltaTime * animationSpeed, 0);
        backgroundImg.material.mainTextureOffset += backgroundPosition;

        if (backgroundImg.material.mainTextureOffset.x > 1)
            backgroundImg.material.mainTextureOffset = new Vector2(-1, 0);
	}
}
