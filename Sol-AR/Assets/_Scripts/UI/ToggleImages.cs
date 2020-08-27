using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImages : MonoBehaviour
{

    [SerializeField]
    private Button toggleButton;
    [SerializeField]
    private float animationDuration;
    [SerializeField]
    private CanvasGroup firstImg;
    [SerializeField]
    private CanvasGroup secondImg;

    private bool toggeled;

    private void Start()
    {
        toggleButton.onClick.AddListener(() => Toggle(!toggeled));
    }

    public void Toggle(bool toggle)
    {
        toggeled = !toggeled;
        LeanTween.alphaCanvas(toggle ? firstImg : secondImg, 0, animationDuration / 2);
        LeanTween.alphaCanvas(toggle ? secondImg : firstImg, 1, animationDuration / 2).setDelay(animationDuration / 2);
    }
}
