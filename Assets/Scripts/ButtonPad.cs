using UnityEngine;
using UnityEngine.Events;

public class ButtonPad : MonoBehaviour, ISelectable
{
    public MeshRenderer _meshRenderer;
    public Color _defaultColor;
    public Color _hoverColor;
    private string _hoverMessage = "\"E\" to interact";

    public UnityEvent<string> _onHoverEnter;
    public UnityEvent _onHoverExit;
    public UnityEvent _onInteract;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnHoverEnter()
    {
        _meshRenderer.material.color = _hoverColor;
        _onHoverEnter?.Invoke(_hoverMessage);
    }

    public void OnHoverExit()
    {
        _meshRenderer.material.color = _defaultColor;
        _onHoverExit?.Invoke();
    }

    public void OnSelect()
    {
        _onInteract?.Invoke();
    }
}
