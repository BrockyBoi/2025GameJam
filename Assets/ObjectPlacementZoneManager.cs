using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementZoneManager : MonoBehaviour
{
    public static ObjectPlacementZoneManager Instance;

    private Dictionary<EPickupType, List<PlaceObjectZone>> _zonesPerType;
    private void Awake()
    {
        Instance = this;
        _zonesPerType = new Dictionary<EPickupType, List<PlaceObjectZone>>();
    }
    
    public void RegisterObject(PlaceObjectZone zone)
    {
        if (!_zonesPerType.ContainsKey(zone.PickupType))
        {
            _zonesPerType.Add(zone.PickupType, new List<PlaceObjectZone>());
        }

        _zonesPerType[zone.PickupType].Add(zone);
    }

    public void HighlightAllViableObjects(EPickupType pickupType, bool shouldHighlight)
    {
        if (_zonesPerType.ContainsKey(pickupType))
        {
            List<PlaceObjectZone> objectZones = _zonesPerType[pickupType];
            foreach (PlaceObjectZone zone in objectZones)
            {
                if (zone)
                {
                    zone.Highlight(shouldHighlight);
                }
            }
        }
    }
}
