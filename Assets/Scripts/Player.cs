using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _moveSpeed = 1f;

    [SerializeField]
    private float _rotateSpeed = 10f;

    [SerializeField]
    private CharacterController _characterController;

    public Vector3 CameraForward { get { return _camera.transform.forward; } }

    private float _pitch;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (EscapeManager.Instance && EscapeManager.Instance.IsPaused)
        {
            return;
        }

        float playerX = Input.GetAxis("Horizontal");
        float playerY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * _rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _rotateSpeed * Time.deltaTime;

        Vector3 forwardVec = _camera.transform.forward;

        Vector3 movementForward = ((playerX * transform.right) + (playerY * forwardVec)).ChangeAxis(ExtensionMethods.VectorAxis.Y, 0);
        _characterController.Move(movementForward * _moveSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, mouseX, 0));

        _pitch -= mouseY;
        _pitch = Mathf.Clamp(_pitch , -60, 60);
        _camera.transform.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }
}
