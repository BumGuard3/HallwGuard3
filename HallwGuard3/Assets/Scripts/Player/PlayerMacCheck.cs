using UnityEngine;

public class PlayerMacCheck : MonoBehaviour
{
    public bool mac;

    private void Awake()
    {
        mac = false;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Mac")
        {
            Destroy(hit.gameObject);
            mac = true;
            GameObject.Find("DoorManager").GetComponent<MacDoor>().UpdateMac();
        }
    }
}
