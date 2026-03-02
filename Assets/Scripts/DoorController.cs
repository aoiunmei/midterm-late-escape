using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private float _openPositionY;
    [SerializeField] private float _closePositionY;
    [SerializeField] private int _lockNumber;

    private bool _locked = true;
    private int _keysCollected = 0;
    
    // Update is called once per frame
    void Update()
    {
        OpenDoor();
        CloseDoor();
    }

    public void OpenDoor() {
        if(!_locked)
        {
            _doorTransform.position = Vector3.Lerp(_doorTransform.position, new Vector3(_doorTransform.position.x, _openPositionY, _doorTransform.position.z), Time.deltaTime);
        }
     }

    public void CloseDoor() {
        _doorTransform.position = Vector3.Lerp(_doorTransform.position, new Vector3(_doorTransform.position.x, _closePositionY, _doorTransform.position.z), Time.deltaTime);
    }

    public void LockDoor() {
        _locked = true;
    }

    public void UnlockDoor() {
        _locked = false;
    }

    public void checkLocks() {
        if(_keysCollected >= _lockNumber) {
            UnlockDoor();
        } else {
            LockDoor();
        }
    }

    public void AddKeysCollected() {
        _keysCollected++;
        checkLocks();
    }
    public void RemoveKeysCollected() {
        _keysCollected--;
        checkLocks();
    }
}
