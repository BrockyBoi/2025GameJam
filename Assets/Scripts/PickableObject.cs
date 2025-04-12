using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpObject()
    {
        _collider.enabled = false;
    }

    public void PutDownObject()
    {
        _collider.enabled = false;
    }
}
