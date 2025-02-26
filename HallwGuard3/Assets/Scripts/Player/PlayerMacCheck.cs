using UnityEngine;

public class PlayerMacCheck : MonoBehaviour
{
    public GameManager gameManager;

    //NOT DONE WITH THIS CODE YET


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Mac")
        {
            Destroy(hit.gameObject);


        }
    }



}
