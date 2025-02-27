using UnityEngine;

public class MacDoor : MonoBehaviour
{
    public GameObject Player;
    private bool mac;

    //OpenDoors - DOORS THAT WILL CLOSE WHEN THE PLAYER GRABS THE MAC
    //ClosedDoors - DOORS THAT WILL OPEN WHEN THE PLAYER GRABS THE MAC

    [SerializeField] private GameObject OpenDoors;
    [SerializeField] private GameObject ClosedDoors;

    private void Awake()
    {
        mac = Player.GetComponent<PlayerMacCheck>().mac;
    }

    void Update()
    {
        if (mac == false)
        {
            OpenDoors.SetActive(false);
            ClosedDoors.SetActive(true);
        }
        else if (mac == true)
        {
            OpenDoors.SetActive(true);
            ClosedDoors.SetActive(false);
        }
    }

    public void UpdateMac()
    {
        mac = Player.GetComponent<PlayerMacCheck>().mac;
    }


}
