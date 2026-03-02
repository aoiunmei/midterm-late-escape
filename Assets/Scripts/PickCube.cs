using UnityEngine;
using UnityEngine.Events;

public class PickCube : MonoBehaviour, IPickable
{
    Rigidbody _cubeRigidbody;

    public void OnPicked(Transform attachTransform)
    {
        transform.position = attachTransform.position;
        transform.rotation = attachTransform.rotation;
        transform.SetParent(attachTransform);

        _cubeRigidbody.isKinematic = true;
        _cubeRigidbody.useGravity = false;
    }

    public void OnDropped()
    {
        _cubeRigidbody.isKinematic = false;
        _cubeRigidbody.useGravity = true;
        transform.SetParent(null);
    }

    void Start()
    {
        _cubeRigidbody = GetComponent<Rigidbody>();
    }
}