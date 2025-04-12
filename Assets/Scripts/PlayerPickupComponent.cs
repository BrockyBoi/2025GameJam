using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupComponent : MonoBehaviour
{
    private Player _player;
    private PickableObject _currentObjectInHand;

    [SerializeField]
    float raycastDist = 500f;

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
            if (Physics.Raycast(startPos, cameraForward, out hit, raycastDist))
            {
                PickableObject pickableObject = hit.transform.GetComponent<PickableObject>();
                if (pickableObject)
                {
                    _currentObjectInHand = pickableObject;
                    pickableObject.PickUpObject();
                    _currentObjectInHand.transform.SetParent(_player.transform);
                    _currentObjectInHand.transform.position = startPos + cameraForward * 500;
                }
            }

            Debug.DrawLine(startPos, startPos + cameraForward * 500);
        }
    }
}
