using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public enum EPickupType
{
    SmallWall,
    LargeWall,
    SmallGround,
    LargeGround,
}

public class PickableObject : MonoBehaviour
{
    private bool _isPickedUp = false;

    [SerializeField]
    private EPickupType pickupType;

    public EPickupType PickupType { get { return pickupType; } }

    [SerializeField]
    private bool _isObjectSuspicious = false;
    public bool IsObjectSuspicous { get { return _isObjectSuspicious; } }

    [SerializeField, Range(0, 1), ShowIf("_isObjectSuspicious")]
    private float _suspicionLevel = 0;

    public float SuspicionLevel { get { return _suspicionLevel; } }
    
    [SerializeField]
    private Collider _collider;

    [SerializeField]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private PlaceObjectZone _zone;

    private void Start()
    {
        _spriteRenderer.enabled = true;
        _meshRenderer.enabled = false;
    }

    private void Update()
    {
        if (_isPickedUp)
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0);
            Vector3 startPos = Player.Instance.transform.position;
            Vector3 cameraForward = Player.Instance.CameraForward;
            transform.position = startPos + cameraForward * 1.5f;
        }
    }

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
        _isPickedUp = true;
        _meshRenderer.enabled = false;
        _spriteRenderer.enabled = true;

        _collider.enabled = false;
        _zone.RemoveObjectFromZone();
        _zone = null;

        HighlightAllSimilarObjects(true);
        gameObject.layer = LayerMask.NameToLayer("PickableObject");
        gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("PickableObject");
    }

    private void PutDownObject()
    {
        _isPickedUp = false;
        _meshRenderer.enabled = false;
        _spriteRenderer.enabled = true;

        _collider.enabled = true;

        HighlightAllSimilarObjects(false);
        gameObject.layer = LayerMask.NameToLayer("Default");
        gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
    }

    private void HighlightAllSimilarObjects(bool shouldShow)
    {
        ObjectPlacementZoneManager.Instance.HighlightAllViableObjects(pickupType, shouldShow);
        if (pickupType == EPickupType.SmallWall)
        {
            ObjectPlacementZoneManager.Instance.HighlightAllViableObjects(EPickupType.LargeWall, shouldShow);
        }
        else if (pickupType == EPickupType.SmallGround)
        {
            ObjectPlacementZoneManager.Instance.HighlightAllViableObjects(EPickupType.LargeGround, shouldShow);
        }
    }
}
