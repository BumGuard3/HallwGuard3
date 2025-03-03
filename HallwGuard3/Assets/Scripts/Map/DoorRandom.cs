using UnityEngine;

public class DoorRandom : MonoBehaviour
{
    
    public void DoorRandomOpen()
    {
        int randomRoll = Random.Range(0, 2);

        if (randomRoll == 0 )
        {
            Destroy(gameObject);
        }
    }
}
