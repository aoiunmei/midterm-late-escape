using UnityEngine;

[RequireComponent (typeof(PlayerMovementBehaviour))]
public class PlayerJumpBehaviour : Interactor
{
    [Header("Jump")]
    [SerializeField] private float _jumpVelocity;

    private PlayerMovementBehaviour _movementBehaviour;

    public override void Setup()
    {
        _input = GetComponent<PlayerInput>();
        _movementBehaviour = GetComponent<PlayerMovementBehaviour>();
    }

    public override void Interact()
    {
        if (_input.jumpPressed && _movementBehaviour._isGrounded)
        {
            _movementBehaviour.SetYVelocity(_jumpVelocity);
        }
    }
}