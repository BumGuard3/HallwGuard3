using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField]
    private float Speed = 1f;
    [Header("Sliding Configs")]
    [SerializeField]
    private Vector3 SlideDirection = Vector3.back;
    [SerializeField]
    private float SlideAmount = 3f;

    private Vector3 StartPosition;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        StartPosition = transform.position;
    }
    
    public void Open(Vector3 UserPosition)
    {
        if (!IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            
            AnimationCoroutine = StartCoroutine(DoSlidingOpen());
            
        }
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = StartPosition + transform.TransformDirection(SlideDirection) * SlideAmount;
        Vector3 startPosition = transform.position;

        float time = 0;
        IsOpen = true;
        
        while(time < 1)
        {
            time += Time.deltaTime * Speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
        }

        transform.position = endPosition;

    }

    public void Close()
    {
        if (IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            AnimationCoroutine = StartCoroutine(DoSlidingClose());
            
        }
    }

    private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition = StartPosition;
        Vector3 startPosition = transform.position;

        float time = 0;
        IsOpen = false;
        while(time < 1)
        {
            time += Time.deltaTime * Speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
        }

        transform.position = endPosition;
    }
}
