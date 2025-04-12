using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPickupType
{
    SmallWall,
    LargeWall,
    SmallGround,
    LargeGround,
}

public class PickableObject : MonoBehaviour
{
    [SerializeField]
    private EPickupType pickupType;

    public EPickupType PickupType { get { return pickupType; } }
    
    [SerializeField]
    private Collider _collider;

    private PlaceObjectZone _zone;

    public void SetZone(PlaceObjectZone zone)
    {
        _zone = zone;
        if (zone)
        {
            PutDownObject();
        }
    }

    public void PickUpObject()
    {
        _collider.enabled = false;
        _zone.RemoveObjectFromZone();
        _zone = null;
    }

    private void PutDownObject()
    {
        _collider.enabled = true;
    }
}
