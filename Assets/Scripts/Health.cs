using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    public UnityEvent<float> OnHealthUpdated;
    public UnityEvent OnKnockOut;
    public bool _isKnockedOut { get; private set; }
    public float _health;

    private void Start()
    {
        _health = _maxHealth;
        OnHealthUpdated?.Invoke(_maxHealth);
    }

    public void DeductHealth(float value)
    {
        if(_isKnockedOut) return;
        _health -= Mathf.Floor(value);
        if(_health <= 0)
        {
            _health = 0;
            _isKnockedOut = true;
            OnKnockOut?.Invoke();
        }
        OnHealthUpdated?.Invoke(_health);
    }
}