using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 1f;
    public float shakeMagnitude = 0.5f; // Increased magnitude for better visibility
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

            // Log to see if the shake effect is occurring
            Debug.Log("Camera Position: " + transform.position);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
    }
}

