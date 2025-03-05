using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lean : MonoBehaviour
{
    public Animator cameraAnim;
    public LayerMask layers;
    RaycastHit hit;

    void Update()
    {
        if((Input.GetKey(KeyCode.Q) || Input.GetButton("Fire2")) && !Physics.Raycast(transform.position, -transform.right, out hit, 2.8f, layers))
        {
            cameraAnim.ResetTrigger("Idle");
            cameraAnim.ResetTrigger("Right");
            cameraAnim.SetTrigger("Left");
        }
        else if((Input.GetKey(KeyCode.E) || Input.GetButton("Fire1")) && !Physics.Raycast(transform.position, transform.right, out hit, 2.8f, layers))
        {
            cameraAnim.ResetTrigger("Idle");
            cameraAnim.ResetTrigger("Left");
            cameraAnim.SetTrigger("Right");
        }
        else
        {
            cameraAnim.ResetTrigger("Left");
            cameraAnim.ResetTrigger("Right");
            cameraAnim.SetTrigger("Idle"); 
        }
    }
}
