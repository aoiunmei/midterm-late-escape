using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _pickupLayer;

    public UnityEvent _onPlaced;
    public UnityEvent _onRemoved;

    private bool isObjectPlaced = false;

    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _checkRadius, _pickupLayer);
        
        foreach(var collider in hitColliders)
        {
            if(collider.gameObject.CompareTag("PressureItem"))
            {
                PlacedObject();
            }
        }
    }

    public void PlacedObject()
    {
        if(_onPlaced != null && !isObjectPlaced) {
            _onPlaced?.Invoke();
            isObjectPlaced = true;
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _checkRadius, _pickupLayer);
        
        if(collision.gameObject.CompareTag("PressureItem"))
        {
            if(hitColliders.Length <= 1)
            {
                _onRemoved?.Invoke();
                isObjectPlaced = false;
            } 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _checkRadius);
    }
}
