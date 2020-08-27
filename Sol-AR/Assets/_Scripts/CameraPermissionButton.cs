using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CameraPermissionButton : MonoBehaviour
{
    [SerializeField]
    private PopupAnimator window;

    private Button permissionButton;

    void Start()
    {
        permissionButton = GetComponent<Button>();
        permissionButton.onClick.AddListener(GivePermission);
    }


    private void GivePermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);

        window.ClosePopup();
    }
}
