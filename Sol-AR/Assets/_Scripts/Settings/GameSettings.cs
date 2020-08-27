using UnityEngine;
using SingletonUtility;

public class GameSettings : SingletonBehaviour<GameSettings>
{
    [Header("Game settings")]
    [SerializeField]
    private bool fullVersion;

    public bool FullVersion => fullVersion;
}