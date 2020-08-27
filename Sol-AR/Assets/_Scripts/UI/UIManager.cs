using UnityEngine;
using SingletonUtility;

public class UIManager : MonoBehaviour
{
    #region Singleton instance
    private static UIManager instance;
    public static UIManager Instance => instance;
    #endregion

    [SerializeField]
    private ARController aRController;
    [SerializeField]
    private GameObject spawnMenu;
    [SerializeField]
    private GameObject mainMenu;    
    [SerializeField]
    private GameObject toARUI;
    [SerializeField]
    private CanvasGroup scalingUI;

    private void Awake() => instance = this;

    public void SpawnSolarSystem()
    {
        aRController.SpawnSolarSystem();
        SetScalingUI(true, 1.7f);
    }

    public void SetScalingUI(bool active, float delay = 0)
    {
        float movementAmountY = -40;
        scalingUI.alpha = active ? 0 : 1;
        scalingUI.transform.localPosition = active ? new Vector3(0, movementAmountY, 0) : Vector3.zero;
        if (active)
        {
            scalingUI.gameObject.SetActive(true);
            spawnMenu.SetActive(false);
            mainMenu.SetActive(false);
        }
        LeanTween.alphaCanvas(scalingUI, active ? 1 : 0, 1)
            .setDelay(delay);
        LeanTween.moveLocalY(scalingUI.gameObject, active ? 0 : movementAmountY, 1)
            .setEase(LeanTweenType.easeInOutQuart)
            .setDelay(delay * (active ? .8f : 1.5f))
            .setOnComplete(()=> 
            {
                if (!active)
                {
                    scalingUI.gameObject.SetActive(false);
                    spawnMenu.SetActive(false);
                    mainMenu.SetActive(true);
                }
            });
    }

    public void ResetSolarSystem()
    {
        SlideUI.Instance.Slide(false, () =>
        {
            ViewPlanet.Instance.SetLayer(0);
            aRController.ResetActiveObjects();
            spawnMenu.SetActive(true);
            mainMenu.SetActive(false);
            toARUI.SetActive(false);
        });
    }

    public void VisitNasaWWW()
    {
        string url = "https://solarsystem.nasa.gov/planets/";
        switch (ViewPlanet.Instance.currentViewingLocation)
        {
            case Location.sun:
                url += "overview/";
                break;
            case Location.mercury:
                url += "mercury/overview/";
                break;
            case Location.venus:
                url += "venus/overview/";
                break;
            case Location.mars:
                url += "mars/overview/";
                break;
            case Location.earth:
                url += "earth/overview/";
                break;
            case Location.moon:
                url = "https://solarsystem.nasa.gov/moons/earths-moon/overview/";
                break;
            case Location.jupiter:
                url += "jupiter/overview/";
                break;
            case Location.saturn:
                url += "saturn/overview/";
                break;
            case Location.uranus:
                url += "uranus/overview/";
                break;
            case Location.neptune:
                url += "neptune/overview/";
                break;
            case Location.ISS:
                url = "https://www.nasa.gov/audience/forstudents/k-4/stories/nasa-knows/what-is-the-iss-k4.html";
                break;
            case Location.none:
                url += "overview/";
                break;
            default:
                url += "overview/";
                break;
        }
        Application.OpenURL(url);
    }
    
    public void VisitWebsite(string url)
    {
        Application.OpenURL(url);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
