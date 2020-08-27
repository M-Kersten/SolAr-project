using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitUrl : MonoBehaviour
{
    public void VisitPlaystore()
    {
        Application.OpenURL("market://details?id=com.MKProductions.SolAR");
    }
}
