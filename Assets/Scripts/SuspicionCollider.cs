using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
        Player player = other.GetComponent<Player>();
        if (player)
        {
            Debug.Log("Seen player");
            SuspicionManager.Instance.OnSeePlayer();
        }

        PickableObject pickableObject = other.GetComponent<PickableObject>();
        if (pickableObject && pickableObject.IsObjectSuspicous)
        {
            Debug.Log("Seen suspicious object");
            SuspicionManager.Instance.OnSeeSuspicousObject(pickableObject);
        }
    }
}
