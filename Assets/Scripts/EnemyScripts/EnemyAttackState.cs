using UnityEngine;

public class EnemyAttackState : EnemyState
{   
    float _distanceToPlayer;
    private Health _playerHealth;
    private float _damagePerSecond = 20f;

    public EnemyAttackState(EnemyController controller) : base(controller)
    {
        _playerHealth = controller.player.GetComponent<Health>();
    }
    public override void OnEnter() {}
    public override void OnExit() {}
    public override void OnUpdate()
    {
        if(_controller.player != null) {
            Attack();
            _distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.player.position);
            if(_distanceToPlayer > 2)
            {
                _controller.ChangeState(new EnemyFollowState(_controller));
            }
            _controller.agent.SetDestination(_controller.player.position);
        } else {
            _controller.ChangeState(new EnemyIdleState(_controller));
        }
    }
    public void Attack()
    {
        if(_playerHealth != null)
        {
            float damage = _damagePerSecond * Time.deltaTime;
            _playerHealth.DeductHealth(damage);
        }
    }
}
