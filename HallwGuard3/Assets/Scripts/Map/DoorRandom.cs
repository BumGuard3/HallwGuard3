using UnityEngine;

public class DoorRandom : MonoBehaviour
{
    
    public void DoorRandomOpen()
    {
        int randomRoll = Random.Range(0, 4);

        if (randomRoll == 0 )
        {
            transform.position -= transform.right * 2.6f;
        }
    }
}
