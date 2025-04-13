using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimManager : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    Vector3 _prevLoc = Vector3.zero;

    private void Start()
    {
    }

    public void FlipPhoneForward()
    {
        _animator.SetTrigger("FlipPhoneForward");
    }

    public void FlipPhoneBack()
    {
        _animator.SetTrigger("FlipPhoneBack");
    }

    private void Update()
    {
        bool sameLoc = Mathf.Approximately(_prevLoc.x, transform.position.x) && Mathf.Approximately(_prevLoc.z, transform.position.z);
        _animator.SetBool("IsWalking", !sameLoc);
        _prevLoc = transform.position;
    }
}
