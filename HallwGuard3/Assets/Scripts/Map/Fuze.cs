using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fuze : MonoBehaviour
{
    public UnityEvent fuzeCollect;

    void Start()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("CeilingLights");
        foreach (GameObject lightObj in lights)
        {
            fuzeCollect.AddListener(lightObj.GetComponent<Lights>().ShutOff);
        }

        GameObject[] openDoors = GameObject.FindGameObjectsWithTag("DoorAlwaysOpen");
        foreach (GameObject doors in openDoors)
        {
        fuzeCollect.AddListener(doors.GetComponent<DoorOpen>().DoorAlwaysOpen);
        }

        fuzeCollect.AddListener(GameObject.FindGameObjectWithTag("DoorAlwaysClose").GetComponent<DoorClose>().DoorAlwaysClose);
        fuzeCollect.AddListener(GameObject.FindGameObjectWithTag("DoorRandom").GetComponent<DoorRandom>().DoorRandomOpen);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            fuzeCollect.Invoke();
            Destroy(gameObject);
        }
    }
}
