using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupAnimator : MonoBehaviour
{
    [SerializeField]
    private float fadeDuration;
    [SerializeField]
    private Image backGroundImg;
    [SerializeField]
    private CanvasGroup popup;

    void OnEnable()
    {
        OpenPopup();
    }

    private void OpenPopup()
    {
        LeanTween.cancel(popup.gameObject);
        backGroundImg.color = new Color(backGroundImg.color.r, backGroundImg.color.g, backGroundImg.color.b, 0);
        popup.alpha = 0;
        popup.gameObject.transform.localScale = Vector3.one * .8f;

        LeanTween.alphaCanvas(popup, 1, fadeDuration)
            .setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(popup.gameObject, Vector3.one, fadeDuration)
            .setEase(LeanTweenType.easeInOutQuart);
        LeanTween.value(popup.gameObject, 0, .5f, fadeDuration)
            .setOnUpdate((value) => backGroundImg.color = new Color(backGroundImg.color.r, backGroundImg.color.g, backGroundImg.color.b, value))
            .setEase(LeanTweenType.easeInOutSine);
    }

    public void ClosePopup()
    {
        if (LeanTween.isTweening(popup.gameObject))
            return;

        LeanTween.cancel(popup.gameObject);
        LeanTween.alphaCanvas(popup, 0, fadeDuration/2)
            .setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(popup.gameObject, Vector3.one * .3f, fadeDuration)
            .setEase(LeanTweenType.easeInOutQuart);
        LeanTween.value(popup.gameObject, .5f, 0, fadeDuration)
            .setOnUpdate((value) => backGroundImg.color = new Color(backGroundImg.color.r, backGroundImg.color.g, backGroundImg.color.b, value))
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => gameObject.SetActive(false));
    }

}
