using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectZone : MonoBehaviour
{
    [SerializeField]
    private EPickupType _pickupType;
    public EPickupType PickupType { get { return _pickupType; } }

    [SerializeField]
    private PickableObject _currentObjectInZone;

    public PickableObject ObjectInZone { get { return _currentObjectInZone; } }

    [SerializeField]
    private Collider _selectionCollider;

    [SerializeField]
    private MeshRenderer _highlightRenderer;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private Vector3 _extraRotationAdjustment = Vector3.zero;

    private void Start()
    {
        if (_currentObjectInZone)
        {
            ForceObjectInZone(_currentObjectInZone);
        }

        Highlight(false);

        ObjectPlacementZoneManager.Instance.RegisterObject(this);

        _selectionCollider.enabled = true;
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

    public bool HasObject()
    {
        return _currentObjectInZone;
    }

    private void ForceObjectInZone(PickableObject heldObject)
    {
        _currentObjectInZone = heldObject;
        _currentObjectInZone.transform.SetParent(transform);
        _currentObjectInZone.transform.position = transform.position;
        _currentObjectInZone.transform.rotation = Quaternion.identity;
        if (_extraRotationAdjustment != Vector3.zero)
        {
            _currentObjectInZone.transform.Rotate(_extraRotationAdjustment);
        }
        _currentObjectInZone.SetZone(this);

        _currentObjectInZone.transform.localScale = _currentObjectInZone.StartScale / transform.localScale.x;
    }

    public void PlaceObjectInZone(PickableObject heldObject)
    {
        if (!_currentObjectInZone && heldObject)
        {
            ForceObjectInZone(heldObject);

            _audioSource.Play();
        }
    }

    public void RemoveObjectFromZone()
    {
        _currentObjectInZone = null;

        _audioSource.Play();
    }

    public void Highlight(bool shouldHighlight)
    {
        if (HasObject())
        {
            shouldHighlight = false;
        }

        _highlightRenderer.enabled = shouldHighlight;
    }
}
