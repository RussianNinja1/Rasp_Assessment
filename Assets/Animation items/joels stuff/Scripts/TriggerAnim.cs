using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    //dataspace for the Animator component of the object
    [Header("Animation/Collider Options")]
    [SerializeField] private Animator anim = null;
    [SerializeField] private MeshRenderer triggerMesh = null;
    [SerializeField] private string colliderTagName;

    [Header("Enter Trigger Options")]
    [SerializeField] private bool hasEnterTrigger = false;
    [SerializeField] private bool destroyTriggerOnEnter = false;
    [SerializeField] private string animClipEnter;

    [Header("Exit Trigger Options")]
    [SerializeField] private bool hasExitTrigger = false;
    [SerializeField] private bool destroyTriggerOnExit = false;
    [SerializeField] private string animClipExit;

    [Header("Debugging Info/Options")]
    [SerializeField] private bool hasTriggered = false;
    [SerializeField] private bool showTriggerMesh = false;

    void Start()
    {
        if(showTriggerMesh)
        {
            triggerMesh.enabled = true;
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(hasEnterTrigger==true && hasTriggered == false)
        {
            if (other.CompareTag(colliderTagName))
            {
                anim.Play(animClipEnter, 0, 0.0f);
                hasTriggered = true;

                if (destroyTriggerOnEnter)
                {
                    gameObject.SetActive(false);
                }
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasExitTrigger == true && hasTriggered == true)
        {
            if (other.CompareTag(colliderTagName))
            {
                anim.Play(animClipExit, 0, 0.0f);
                hasTriggered = false;

                if (destroyTriggerOnExit)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
