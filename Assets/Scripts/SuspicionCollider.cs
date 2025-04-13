using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            SuspicionManager.Instance.OnSeePlayer();
        }

        PickableObject pickableObject = other.GetComponent<PickableObject>();
        if (pickableObject && pickableObject.IsObjectSuspicous)
        {
            SuspicionManager.Instance.OnSeeSuspicousObject(pickableObject);
        }
    }
}
