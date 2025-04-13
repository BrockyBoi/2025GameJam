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
        if (Input.GetMouseButtonDown(0) && !EscapeManager.Instance.IsPaused && !SuspicionManager.Instance.IsGameOver)
        {
            Vector3 startPos = Camera.main.transform.position;
            Vector3 cameraForward = _player.CameraForward;
            RaycastHit hit;
            if (Physics.Raycast(startPos, cameraForward, out hit, _raycastDist))
            {
                Debug.Log(hit.transform.gameObject.name);
                PickableObject pickableObject = hit.transform.GetComponent<PickableObject>();
                if (!_currentObjectInHand && pickableObject)
                {
                    PickUpObject(pickableObject);
                }
                else
                {
                    PlaceObjectZone zone = hit.transform.GetComponent<PlaceObjectZone>();
                    if (zone)
                    {
                        if (_currentObjectInHand && zone.CanUseZone(_currentObjectInHand))
                        {
                            zone.PlaceObjectInZone(_currentObjectInHand);
                            _currentObjectInHand = null;
                        }
                        else if (!_currentObjectInHand && zone.HasObject())
                        {
                            PickUpObject(zone.ObjectInZone);
                        }
                    }
                }
            }

            Debug.DrawLine(startPos, startPos + cameraForward * _raycastDist, Color.red, 3);
        }
    }

    void PickUpObject(PickableObject pickableObject)
    {
        Vector3 startPos = Camera.main.transform.position;
        Vector3 cameraForward = _player.CameraForward;

        _currentObjectInHand = pickableObject;
        pickableObject.PickUpObject();
        _currentObjectInHand.transform.SetParent(_player.transform);
        _currentObjectInHand.transform.position = startPos + cameraForward * _distToKeepObjectInFrontOfPlayer;
        _currentObjectInHand.transform.rotation = Quaternion.identity;
        _currentObjectInHand.transform.localScale = _currentObjectInHand.StartScale;
    }
}
