using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(CanvasGroup))]
public class PlanetInfo : MonoBehaviour
{
    [SerializeField]
    private Text leftText;
    [SerializeField]
    private Text rightText;
    [SerializeField]
    private List<PlanetData> planetData;
    [SerializeField]
    private CanvasGroup chooseDestinationText;

    private CanvasGroup canvasGroup;


    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Display(Location world)
    {
        if (chooseDestinationText.gameObject.activeInHierarchy)
            LeanTween.alphaCanvas(canvasGroup, 0, .7f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => chooseDestinationText.gameObject.SetActive(false));

        foreach (PlanetData item in planetData.Where(item => item.world == world).Select(item => item))
        {
            leftText.text = item.leftData;
            rightText.text = item.rightData;
        }
        LeanTween.alphaCanvas(canvasGroup, 1, .5f).setEase(LeanTweenType.easeInOutSine).setDelay(.7f);
    }

    public void Hide()
    {
        LeanTween.alphaCanvas(canvasGroup, 0, .2f).setEase(LeanTweenType.easeInOutSine);
    }
}
