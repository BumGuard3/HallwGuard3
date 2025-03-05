using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public void DoorAlwaysClose()
    {
        transform.position += transform.up * 3f;
    }
}
