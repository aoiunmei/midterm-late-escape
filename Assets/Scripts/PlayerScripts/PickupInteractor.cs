using UnityEngine;

public class PickupInteractor : Interactor
{
    [Header("Pickup and Drop")]
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _pickupLayer;
    [SerializeField] private float _pickupDistance;
    [SerializeField] private Transform _attachTransform;

    private bool _isPicked = false;
    private IPickable _pickable;

    public override void Interact()
    {
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        Ray ray = _camera.ScreenPointToRay(screenCenter);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, _pickupDistance, _pickupLayer))
        {
            _pickable = hitInfo.transform.GetComponent<IPickable>();
            if(_pickable != null)
            {
                if(_input.activatePressed && !_isPicked)
                {
                    if (_pickable == null) return; //no target

                    _pickable.OnPicked(_attachTransform); //picked up something
                    _isPicked = true; //validated picked up something
                    return;
                }
            }
        }
        if (_input.activatePressed && _isPicked && _pickable != null)
        {
            _pickable.OnDropped();
            _isPicked = false;
        }
    }
}