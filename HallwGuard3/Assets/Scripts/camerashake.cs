using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 1f;
    public float shakeMagnitude = 0.5f;
    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float shakeX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float shakeY = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.position = originalPos + new Vector3(shakeX, shakeY, 0f);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
    }
}

