using UnityEngine;

public class ISSMover : MonoBehaviour
{
    public ISSRoom[] rooms;

    private void OnEnable() => ChangeRooms(0);

    public void ChangeRooms(int i)
    {
        UIFader.Instance.FadeWithAction(.7f, action: () =>
        {
            for (int index = 0; index < rooms.Length; index++)
            {
                ISSRoom item = rooms[index];
                if (item.room.activeInHierarchy)
                    item.room.SetActive(false);
            }
            rooms[i].room.SetActive(true);
            RenderSettings.skybox = rooms[i].mat;
        });
    }	
}
