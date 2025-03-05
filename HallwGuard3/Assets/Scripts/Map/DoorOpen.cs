using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public void DoorAlwaysOpen()
    {
        transform.position -= transform.up * 3f;
    }
}
