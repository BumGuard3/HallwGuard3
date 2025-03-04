using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fuze : MonoBehaviour
{
    public UnityEvent fuzeCollect;

    void Start()
    {
        GameObject[] randomDoors = GameObject.FindGameObjectsWithTag("DoorRandom");
        foreach (GameObject door in randomDoors)
        {
            fuzeCollect.AddListener(door.GetComponent<DoorRandom>().DoorRandomOpen);
        }

        GameObject[] lights = GameObject.FindGameObjectsWithTag("CeilingLights");
        foreach (GameObject lightObj in lights)
        {
            fuzeCollect.AddListener(lightObj.GetComponent<Lights>().ShutOff);
        }

        fuzeCollect.AddListener(GameObject.FindGameObjectWithTag("DoorAlwaysOpen").GetComponent<DoorOpen>().DoorAlwaysOpen);
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
