using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    public float speed;
    public Text enabledText;
    public Button enableButton;
    public GameObject pointer;
    public GameObject scanning;

    private float newWidth;
    private Image img;

	void Start () {
        newWidth = 0;
        img = GetComponent<Image>();
	}

    void Update () {
        img.fillAmount = newWidth;
        if (newWidth > 1)
        {
            scanning.SetActive(false);
            enableButton.enabled = true;
            enabledText.text = "Start exploring";
            pointer.SetActive(true);
        }
        else
            newWidth += speed;
	}
}