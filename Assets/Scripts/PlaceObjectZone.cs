using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectZone : MonoBehaviour
{
    [SerializeField]
    private PickableObject _objectInZone;

    [SerializeField]
    private Transform _spotToPlaceItem;

    public void PlaceObjectInZone(PickableObject heldObject)
    {
        if (!_objectInZone)
        {
            _objectInZone = heldObject;
            heldObject.transform.position = _spotToPlaceItem.position;
        }
    }
}
