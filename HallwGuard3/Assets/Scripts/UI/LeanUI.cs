using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LeanUI : MonoBehaviour
{
    public GameObject LeanElement;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DisableUI());
    }

    IEnumerator DisableUI()
    {
        yield return new WaitForSeconds(7);
        LeanElement.gameObject.SetActive(false);
        StopAllCoroutines();
    }

}
