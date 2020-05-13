using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    //Boolean on whether it's on or off.
    public bool isRagDoll;

    //Important components
    private Animator anim;
    private Rigidbody mainRigidbody;
    private Collider mainCollider;

    private Rigidbody[] ragdollRigidbodies;
    private Collider[] ragdollColliders;
    private PlayerController controls;
    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        DisableRagdoll();
    }
    //Important Variables to minimize. DON'T PUT IT ON UPDATE!!!
    void InitializeVariables()
    {
        anim = GetComponent<Animator>();
        mainRigidbody = GetComponent<Rigidbody>();
        mainCollider = GetComponent<Collider>();

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
    }
    //Enable when death.
    public void EnableRagdoll()
    {
        Debug.Log("Ragdoll Enabled");
        isRagDoll = true;

        for (int i = 0; i < ragdollRigidbodies.Length; i++)
        {
            ragdollRigidbodies[i].isKinematic = false;
        }
        //foreach (Rigidbody rigidbody in ragdollRigidbodies)
        //{
        //    rigidbody.isKinematic = true;
        //}
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }

        anim.enabled = false;

        mainRigidbody.isKinematic = true;

        mainCollider.enabled = false;
    }
    //Disable Ragdoll as both Collider and Animator are active.
    public void DisableRagdoll()
    {
        Debug.Log("Ragdoll Disabled");

        foreach (Rigidbody rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
        anim.enabled = true;

        mainRigidbody.isKinematic = false;

        mainCollider.enabled = true;
    }
}
