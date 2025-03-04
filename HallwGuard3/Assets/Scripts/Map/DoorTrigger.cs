using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Door Door;
    public bool SkeletonKey;

    public void SkeletonKeyPickedUp()
    {
        SkeletonKey = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (SkeletonKey == false)
        {
            if (other.CompareTag("Enemy"))
            {
                if(!Door.IsOpen)
                {
                    Door.Open(other.transform.position);
                }
            }
        }

        if (SkeletonKey == true)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Player"))
            {
                if(!Door.IsOpen)
                {
                    Door.Open(other.transform.position);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (SkeletonKey == false)
        {
            if (other.CompareTag("Enemy"))
            {
                if(Door.IsOpen)
                {
                    Door.Close();
                }
            }
        }

        if (SkeletonKey == true)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Player"))
            {
                if(Door.IsOpen)
                {
                    Door.Close();
                }
            }
        }
    }
}