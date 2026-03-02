using UnityEngine;

public class PlayerTurnBehaviour : MonoBehaviour
{
    [Header("Player Turn")]
    [SerializeField] private float _turnSpeed;

    private PlayerInput _input;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * _input.mouseX);
    }
}