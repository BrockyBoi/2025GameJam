using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupComponent : MonoBehaviour
{
    private Player _player;
    private PickableObject _currentObjectInHand;

    [SerializeField]
    private float _raycastDist = 500f;

    private float _distToKeepObjectInFrontOfPlayer = 1.5f;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 startPos = _player.transform.position;
            Vector3 cameraForward = _player.CameraForward;
            RaycastHit hit;
            if (Physics.Raycast(startPos, cameraForward, out hit, _raycastDist))
            {
                PickableObject pickableObject = hit.transform.GetComponent<PickableObject>();
                if (pickableObject)
                {
                    _currentObjectInHand = pickableObject;
                    pickableObject.PickUpObject();
                    _currentObjectInHand.transform.SetParent(_player.transform);
                    _currentObjectInHand.transform.position = startPos + cameraForward * _distToKeepObjectInFrontOfPlayer;
                    _currentObjectInHand.transform.rotation = Quaternion.identity;
                }
                else if (_currentObjectInHand)
                {
                    PlaceObjectZone zone = hit.transform.GetComponent<PlaceObjectZone>();
                    if (zone && zone.CanUseZone(_currentObjectInHand))
                    {
                        zone.PlaceObjectInZone(_currentObjectInHand);
                        _currentObjectInHand = null;
                    }
                }
            }

            Debug.DrawLine(startPos, startPos + cameraForward * _raycastDist, Color.red, 3);
        }
    }
}
