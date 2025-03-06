using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent keyCollect;

    void Start()
    {
        GameObject[] skeletonDoors = GameObject.FindGameObjectsWithTag("DoorInteractable");
        foreach (GameObject Trigger in skeletonDoors)
        {
            keyCollect.AddListener(Trigger.GetComponent<DoorTrigger>().SkeletonKeyPickedUp);
        }

        keyCollect.AddListener(GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().KeysSFX);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            keyCollect.Invoke();
            Destroy(gameObject);
        }
    }
}