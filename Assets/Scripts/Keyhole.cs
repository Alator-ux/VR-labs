using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Keyhole : XRSocketInteractor
{
    [SerializeField]
    HingeJoint doorJoint;
    [SerializeField]
    Rigidbody doorRigidBody;
    [SerializeField]
    Key desiredKey;

    JointLimits defaultDoorJointLimits;
    float doorAngleTolerance = 1.0f;

    private bool DoorAtDefaultPosition { get => Mathf.Abs(doorJoint.angle) < doorAngleTolerance; }
    public bool Locked { get; private set; }

    new private void Start()
    {
        base.Start();
        defaultDoorJointLimits = doorJoint.limits;
        Lock();
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if(!base.CanHover(interactable)) return false;

        var key = interactable.transform.GetComponent<Key>();
        return desiredKey.CanOpenSameDoorAs(key);
    }
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (!base.CanSelect(interactable)) return false;

        var key = interactable.transform.GetComponent<Key>();
        return desiredKey.CanOpenSameDoorAs(key);
    }

    //protected override void OnSelectExited(SelectExitEventArgs args)
    //{
    //    base.OnSelectExited(args);

    //    var key = args.interactableObject.transform.GetComponent<Key>();
    //    Debug.Log("select exited");
    //    if (desiredKey.CanOpenSameDoorAs(key))
    //    {
    //        ChangeStatus();
    //    }
    //}

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        var key = args.interactableObject.transform.GetComponent<Key>();
        Debug.Log("select entered");
        if (desiredKey.CanOpenSameDoorAs(key))
        {
            ChangeStatus(key);
        }
    }


    //protected override void OnHoverEntered(HoverEnterEventArgs args)
    //{
    //    base.OnHoverEntered(args);

    //    var key = args.interactableObject.transform.GetComponent<Key>();
    //    Debug.Log("hover entered");
    //    if (desiredKey.CanOpenSameDoorAs(key))
    //    {
    //        ChangeStatus();
    //    }
    //}


    void ChangeStatus(Key key)
    {
        if (!DoorAtDefaultPosition)
        {
            return;
        }

        if(Locked)
        {
            Unlock();
        }
        else
        {
            Lock();
        }
        key.OnKeyUsed?.Invoke(key);
    }

    void Lock()
    {
        var tempLimits = doorJoint.limits;
        tempLimits.min = 0;
        tempLimits.max = 0;
        doorJoint.limits = tempLimits;

        doorRigidBody.constraints = RigidbodyConstraints.FreezeAll;

        Debug.Log("locked");
        Locked = true;
    }

    void Unlock()
    {
        doorJoint.limits = defaultDoorJointLimits;

        doorRigidBody.constraints = RigidbodyConstraints.None;

        Debug.Log("unlocked");
        Locked = false;

        Timer.Instance.StopTimer();
    }
}
