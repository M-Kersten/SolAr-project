using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class SlideUI : MonoBehaviour
{
    private static SlideUI instance;
    public static SlideUI Instance => instance;

    [SerializeField]
    private Button optionsButton;
    [SerializeField]
    private float animationDuration;
    [SerializeField]
    private CanvasGroup optionsImg;
    [SerializeField]
    private CanvasGroup backImg;

    private float startXPosition;
    private float currentXPosition;
    private RectTransform rectTransform;
    private bool menuVisible;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        menuVisible = false;
        rectTransform = GetComponent<RectTransform>();
        startXPosition = rectTransform.anchoredPosition.x;
        optionsButton.onClick.AddListener(() => Slide(!menuVisible));
    }

    public void Slide(bool visible, Action callback = null)
    {
        currentXPosition = rectTransform.anchoredPosition.x;
        menuVisible = !menuVisible;
        LeanTween.cancel(gameObject);
        LeanTween.alphaCanvas(visible ? optionsImg : backImg,  0, animationDuration / 3);
        LeanTween.alphaCanvas(visible ? backImg : optionsImg, 1, animationDuration / 3).setDelay(animationDuration / 2);
        LeanTween.value(currentXPosition, visible ? startXPosition - rectTransform.sizeDelta.x : startXPosition, animationDuration)
            .setOnUpdate((value) => rectTransform.anchoredPosition = new Vector2(value, rectTransform.anchoredPosition.y))
            .setEase(LeanTweenType.easeInOutQuart)
            .setOnComplete(()=>callback?.Invoke());
    }    
}
