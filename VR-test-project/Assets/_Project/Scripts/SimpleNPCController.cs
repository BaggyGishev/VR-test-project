using UnityEngine;

public class SimpleNPCController : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start()
    {
        ChangeToKinematic();
    }

    [ContextMenu("Change to Kinematic")]
    private void ChangeToKinematic()
    {
        foreach (var rb in _rigidbodies) rb.isKinematic = true;
        _animator.enabled = true;
    }

    [ContextMenu("Change to Ragdoll")]
    private void ChangeToRagdoll()
    {
        foreach (var rb in _rigidbodies) rb.isKinematic = false;
        _animator.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        
        if (collision.collider.TryGetComponent(out IProjectile proj))
            ChangeToRagdoll();
    }
}