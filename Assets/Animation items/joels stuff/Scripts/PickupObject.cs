using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float pickupRange;
    [SerializeField] private float throwForce;
    [SerializeField] private Transform pickupHolder;

    private Rigidbody currentObjectRB;
    private Collider currentObjectCollider;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray pickupRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            if (Physics.Raycast(pickupRay, out RaycastHit hitInfo, pickupRange, pickupLayer))
            {
                if (currentObjectRB)
                {
                    currentObjectRB.isKinematic = false;
                    currentObjectCollider.enabled = true;

                    currentObjectRB = hitInfo.rigidbody;
                    currentObjectCollider = hitInfo.collider;

                    currentObjectRB.isKinematic = true;
                    currentObjectCollider.enabled = false;
                }
                else
                {
                    currentObjectRB = hitInfo.rigidbody;
                    currentObjectCollider = hitInfo.collider;

                    currentObjectRB.isKinematic = true;
                    currentObjectCollider.enabled = false;
                }

                return;
            }

            if (currentObjectRB)
            {
                currentObjectRB.isKinematic = false;
                currentObjectCollider.enabled = true;

                currentObjectRB = null;
                currentObjectCollider = null;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (currentObjectRB)
            {
                currentObjectRB.isKinematic = false;
                currentObjectCollider.enabled = true;

                currentObjectRB.AddForce(playerCamera.transform.forward *throwForce, ForceMode.Impulse);

                currentObjectRB = null;
                currentObjectCollider = null;
            }
        }
        
        if(currentObjectRB)
        {
            currentObjectRB.position = pickupHolder.position;
            currentObjectRB.rotation = pickupHolder.rotation;
        }
    }
}
