using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
[RequireComponent (typeof(CanvasGroup))]
public class SpawnButton : MonoBehaviour
{
    private Button btn_spawn;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        btn_spawn = GetComponent<Button>();
        btn_spawn.onClick.AddListener(() => UIManager.Instance.SpawnSolarSystem());
    }

    private void OnEnable()
    {
        canvasGroup.alpha = 0;
        gameObject.transform.localScale = Vector3.one * .85f;
        LeanTween.alphaCanvas(canvasGroup, 1, 1);
        LeanTween.scale(gameObject, Vector3.one, 1).setEase(LeanTweenType.easeOutBack);
    }
}
