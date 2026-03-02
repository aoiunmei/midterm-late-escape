using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Transform _liftPlatform;
    [SerializeField] public float _liftStartingPointY;
    [SerializeField] public float _liftEndingPointY;
    [SerializeField] private bool _liftOn = false;
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if(_liftOn)
        {
            Translate(_liftEndingPointY);
        } else {
            Translate(_liftStartingPointY);
        }
    }

    public void LiftDown() {
        if(!_liftOn)
        {
            //Debug.Log("Lift Down");
            Translate(_liftStartingPointY);
        }
    }
    public void LiftUp() {
        if(_liftOn)
        {
            //Debug.Log("Lift Up");
            Translate(_liftEndingPointY);
        }
    }

    public void Translate(float translateY)
    {
        /*_liftPlatform.transform.position = Vector3.Lerp(
            _liftPlatform.transform.position,
            new Vector3(_liftPlatform.transform.position.x, translateY, _liftPlatform.transform.position.z),
            Time.deltaTime);
        */
        
        _rb.MovePosition(Vector3.Lerp(
            _rb.position,
            new Vector3(_liftPlatform.transform.position.x, translateY, _liftPlatform.transform.position.z),
            Time.deltaTime)
        );
    }
    public void LiftOn()
    {
        _liftOn = true;
    }
    public void LiftOff()
    {
        _liftOn = false;
    }
}
