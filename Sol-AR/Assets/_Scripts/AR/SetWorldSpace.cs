using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorldSpace : MonoBehaviour {

    public LineRenderer[] zones;

    public void SetLinesWorldspace()
    {
        foreach (LineRenderer zone in zones)
        {
            zone.useWorldSpace = true;
        }       
    }
}
