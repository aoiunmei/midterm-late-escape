using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Shoot")]
    [SerializeField] private Input _inputType;
    [SerializeField] private Rigidbody _projectilePrefab;
    [SerializeField] private float _shootVelocity;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private PlayerMovementBehaviour _movementBehaviour;
    private float _finalShootVelocity;
    
    public override void Interact()
    {
        if (IsFirePressed())
        {
            Shoot();
        }
    }

    private bool IsFirePressed()
    {
        return _input.shootPressed;
    }

    private void Shoot()
    {
        _finalShootVelocity = _movementBehaviour.GetForwardSpeed() + _shootVelocity;
        Rigidbody projectile = Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);
        projectile.linearVelocity = _shootPoint.forward * _finalShootVelocity;
        Destroy(projectile.gameObject, 5.0f); // Destroy the projectile after 5 seconds to clean up the scene
    }
}