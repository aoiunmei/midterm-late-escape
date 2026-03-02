using UnityEngine;

public abstract class Interactor : MonoBehaviour
{
    protected PlayerInput _input;
    
    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        Setup();
    }

    private void Update()
    {
        Interact();
    }

    public virtual void Setup()
    {

    }
    public abstract void Interact();
}