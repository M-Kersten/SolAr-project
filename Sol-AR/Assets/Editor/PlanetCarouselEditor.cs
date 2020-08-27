using UnityEditor;

/// <summary>
/// These are editor scripts making sure serialised and 
/// Publc variables are visisble of the carrousel extensions.
/// </summary>
[CustomEditor(typeof(PlanetCarousel))]
public class PlanetCarouselEditor : Editor
{
    public override void OnInspectorGUI() => base.OnInspectorGUI();
}