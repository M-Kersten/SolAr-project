using UnityEngine;
using UnityEngine.Android;

public class IntroMenuManager : MonoBehaviour
{
    private static IntroMenuManager instance;
    public static IntroMenuManager Instance { get { return instance; } }

    [SerializeField]
    private CanvasGroup menuCanvasGroup;
    [SerializeField]
    private CanvasGroup tutorialCanvasGroup;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private float fadeDuration;
    [SerializeField]
    private float rotateDuration;
    [SerializeField]
    private Vector3 tutorialDirection;
    [SerializeField]
    private Vector3 AwakeDirection;

    private void Awake()
    {
        instance = this;        
    }

    private void Start()
    {        
        FadeGroup(menuCanvasGroup, true, fadeDuration + rotateDuration);
        mainCamera.transform.localRotation = Quaternion.Euler(AwakeDirection);
        LeanTween.rotateLocal(mainCamera, Vector3.zero, rotateDuration * 2).setEase(LeanTweenType.easeOutQuart);
#if PLATFORM_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
            }
#endif
    }

    public void ViewTutorial()
    {
        FadeGroup(menuCanvasGroup, false, 0);
        LeanTween.rotateLocal(mainCamera, tutorialDirection, rotateDuration).setEase(LeanTweenType.easeInOutQuart);
        FadeGroup(tutorialCanvasGroup, true, fadeDuration + rotateDuration);
    }

    public void ViewMenu()
    {
        FadeGroup(tutorialCanvasGroup, false, 0);
        LeanTween.rotateLocal(mainCamera, Vector3.zero, rotateDuration).setEase(LeanTweenType.easeInOutQuart);
        FadeGroup(menuCanvasGroup, true, fadeDuration + rotateDuration);
    }

    public void FadeGroup(CanvasGroup group, bool fadeIn, float delayTime)
    {
        if (fadeIn)
        {
            group.gameObject.SetActive(true);
            group.alpha = 0;
            LeanTween.value(gameObject, 0, 1, fadeDuration).setOnUpdate((float val) => { group.alpha = val; }).setEase(LeanTweenType.easeInOutSine).setDelay(delayTime);
        }
        else
        {
            if (gameObject.activeInHierarchy)
                LeanTween.value(gameObject, 1, 0, fadeDuration).setDelay(delayTime).setOnUpdate((float val) => { group.alpha = val; }).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => { group.gameObject.SetActive(false); });
        }
    }
}
