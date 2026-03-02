using UnityEngine;

public class EnemyFollowState : EnemyState
{
    float _distanceToPlayer;
    public EnemyFollowState(EnemyController controller) : base(controller){}
    public override void OnEnter() {
        _controller.agent.SetDestination(_controller.player.position);
    }
    public override void OnExit() {}
    public override void OnUpdate()
    {
        if(_controller.player != null)
        {
            _distanceToPlayer = Vector3.Distance(_controller.transform.position, _controller.player.position);
            if(_distanceToPlayer > 10)
            {
                _controller.ChangeState(new EnemyIdleState(_controller));
            }
            else if(_distanceToPlayer < 2)
            {
                _controller.ChangeState(new EnemyAttackState(_controller));
            }
            _controller.agent.SetDestination(_controller.player.position);
        } else {
            _controller.ChangeState(new EnemyIdleState(_controller));
        }
    }

}
