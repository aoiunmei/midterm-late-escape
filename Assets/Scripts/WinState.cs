using UnityEngine;
using UnityEngine.Events;

public class WinState : MonoBehaviour
{
    public UnityEvent _onGameWin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onGameWin?.Invoke();
        }
    }
}