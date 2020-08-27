using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInOnActivate : MonoBehaviour
{    
    private CanvasGroup fadeInCanvas;
    [SerializeField]
    private float fadeDuration;

    void OnEnable()
    {
        fadeInCanvas = GetComponent<CanvasGroup>();
        OpenPopup();
    }

    private void OpenPopup()
    {
        LeanTween.cancel(fadeInCanvas.gameObject);
        fadeInCanvas.alpha = 0;
        fadeInCanvas.gameObject.transform.localScale = Vector3.one * .88f;

        LeanTween.alphaCanvas(fadeInCanvas, 1, fadeDuration)
            .setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(fadeInCanvas.gameObject, Vector3.one, fadeDuration)
            .setEase(LeanTweenType.easeInOutQuart);
    }
}
