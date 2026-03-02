using UnityEngine;

public class SimpleInteractor : Interactor
{

    [Header("Interact")]
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _interactionLayer;
    [SerializeField] private float _interactionDistance;

    private ISelectable _selectable;

    public override void Interact()
    {
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        Ray ray = _camera.ScreenPointToRay(screenCenter);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, _interactionDistance, _interactionLayer))
        {
            _selectable = hitInfo.transform.GetComponent<ISelectable>();
            if(_selectable != null)
            {
                _selectable.OnHoverEnter();
                if(_input.activatePressed)
                {
                    _selectable.OnSelect();
                }
            }
        }

        if(hitInfo.transform == null && _selectable != null)
        {
            _selectable.OnHoverExit();
            _selectable = null;
        } 
    }
}