using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _sprintMultiplier;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundCheckDistance;

    private CharacterController _characterController;
    private PlayerInput _input;

    private Vector3 _playerVelocity;
    private float _moveMultiplier = 1f;
    public bool _isGrounded { get; private set; }

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GroundCheck();
        MovePlayer();
    }

    private void MovePlayer() {
        _moveMultiplier = _input.sprintHeld ? _sprintMultiplier : 1f;

        Vector2 inputVector = Vector2.ClampMagnitude(new Vector2 (
                _input.horizontal,
                _input.vertical
            ),
        1);

        Vector3 movementVector = transform.forward * inputVector.y + transform.right * inputVector.x;
        _characterController.Move(movementVector * _moveSpeed * Time.deltaTime * _moveMultiplier);

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        // build up of gravity
        _playerVelocity.y += _gravity * Time.deltaTime;
        // application over time
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    private void GroundCheck() {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckDistance, _groundMask);
    }
    public void SetYVelocity(float value)
    {
        _playerVelocity.y = value;
    }

    public float GetForwardSpeed()
    {
        return _input.vertical * _moveSpeed *_moveMultiplier;
    }
}