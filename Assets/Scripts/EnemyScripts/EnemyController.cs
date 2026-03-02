using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public int health = 10;
    [SerializeField] public Transform[] targetPoints;
    [SerializeField] public Transform enemyEye;
    [SerializeField] public float playerCheckDistance;
    [SerializeField] public float checkRadius = 0.4f;
    [HideInInspector] public Transform player;
    [HideInInspector] public NavMeshAgent agent;

    private EnemyState _currentState;
    public UnityEvent _onKnockout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _currentState = new EnemyIdleState(this);
        _currentState.OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject != null) {
            _currentState.OnUpdate();
        }
    }

    public void ChangeState(EnemyState newState)
    {
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Collide Enemy with Bullet");
            TakeDamage();
            Destroy(other.gameObject);
            if(health < 1 && gameObject != null)
            {
                //Debug.Log("Destroy enemy");
                _onKnockout?.Invoke();
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionExit(Collision other) {}
    private void TakeDamage()
    {
        health--;
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        if (enemyEye == null) return;
        Gizmos.DrawWireSphere(enemyEye.position, checkRadius);
        Gizmos.DrawWireSphere(enemyEye.position + enemyEye.forward * playerCheckDistance, checkRadius);
        Gizmos.DrawLine(enemyEye.position, enemyEye.position + enemyEye.forward * playerCheckDistance);
    }
}
