using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectZone : MonoBehaviour
{
    [SerializeField]
    private EPickupType _pickupType;

    [SerializeField]
    private PickableObject _currentObjectInZone;

    [SerializeField]
    private Collider _selectionCollider;

    private void Start()
    {
        if (_currentObjectInZone)
        {
            ForceObjectInZone(_currentObjectInZone);
        }
    }

    public bool CanUseZone(PickableObject pickableObject)
    {
        return !HasObject() && IsValidPickupType(pickableObject.PickupType);
    }

    private bool IsValidPickupType(EPickupType pickupType)
    {
        if (pickupType == _pickupType)
        {
            return true;
        }

        if (pickupType == EPickupType.SmallGround && _pickupType == EPickupType.LargeGround)
        {
            return true;
        }

        if (pickupType == EPickupType.SmallWall && _pickupType == EPickupType.LargeWall)
        {
            return true;
        }

        return false;
    }

    private bool HasObject()
    {
        return _currentObjectInZone;
    }

    private void ForceObjectInZone(PickableObject heldObject)
    {
        _currentObjectInZone = heldObject;
        _currentObjectInZone.transform.SetParent(transform);
        _currentObjectInZone.transform.position = transform.position;
        _currentObjectInZone.transform.rotation = Quaternion.identity;
        _currentObjectInZone.SetZone(this);

        _selectionCollider.enabled = false;
    }

    public void PlaceObjectInZone(PickableObject heldObject)
    {
        if (!_currentObjectInZone && heldObject)
        {
            ForceObjectInZone(heldObject);
        }
    }

    public void RemoveObjectFromZone()
    {
        _currentObjectInZone = null;
        _selectionCollider.enabled = true;
    }
}
