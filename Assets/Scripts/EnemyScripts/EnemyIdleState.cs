using UnityEngine;
public class EnemyIdleState : EnemyState
{
    int _currentTarget = 0;
    public EnemyIdleState(EnemyController controller) : base(controller){}
    public override void OnEnter() {
        _controller.agent.SetDestination(_controller.targetPoints[_currentTarget].position);
    }
    public override void OnExit(){}
    public override void OnUpdate()
    {
            if(_controller.agent.remainingDistance < 0.1f)
            {
                _currentTarget++;
                if(_currentTarget >= _controller.targetPoints.Length)
                    _currentTarget = 0;

                _controller.agent.SetDestination(_controller.targetPoints[_currentTarget].position);
            }
            RaycastHit hitInfo;
            if(Physics.SphereCast(_controller.enemyEye.position, _controller.checkRadius, _controller.transform.forward, out hitInfo, _controller.playerCheckDistance))
            {
                if (hitInfo.transform.CompareTag("Player"))
                {
                    // Debug.Log("Player Found!");
                    _controller.player = hitInfo.transform;
                    _controller.agent.SetDestination(_controller.player.position);

                    _controller.ChangeState(new EnemyFollowState(_controller));
                }
            }
    }
}