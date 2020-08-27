using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ScaleDoneButton : MonoBehaviour
{

    private Button doneButton;

    void Start()
    {
        doneButton = GetComponent<Button>();
        doneButton.onClick.AddListener(DoneButtonClicked);
    }

    private void DoneButtonClicked()
    {
        UIManager.Instance.SetScalingUI(false);
    }
}
