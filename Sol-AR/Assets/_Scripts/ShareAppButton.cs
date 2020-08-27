using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShareAppButton : MonoBehaviour
{
    void Start() => GetComponent<Button>().onClick.AddListener(Share);

    private void Share()
    {
        NativeShare shareObject = new NativeShare();
        shareObject.SetText("Sol.AR is an immersive AR experience that guides you through the solar system. Try it for free on the playstore: https://play.google.com/store/apps/details?id=com.MKProductions.SolARFree ");
        shareObject.SetTitle("Discover the solar system in AR and explore the surface of each planet with Sol.AR");
        shareObject.SetSubject("Discover the solar system in AR");
        shareObject.Share();
    }
}
