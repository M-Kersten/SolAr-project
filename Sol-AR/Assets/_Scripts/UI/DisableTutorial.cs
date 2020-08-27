using UnityEngine;

public class DisableTutorial : MonoBehaviour
{
    public float secondsTillDisable;
    private float timeStart;

    void OnEnable()
    {
        timeStart = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeStart > secondsTillDisable)
            Destroy(gameObject);
    }

}
