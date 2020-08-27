using UnityEngine;
using UnityEngine.UI;

public class FillCircle : MonoBehaviour
{
    public float speed;
    private Image img;

	void Start()
    {
        img = GetComponent<Image>();
	}
	
	void Update()
    {
        if (img.fillAmount < 1)
            img.fillAmount += speed;
	}
}
