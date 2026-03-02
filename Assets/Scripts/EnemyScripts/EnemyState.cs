using UnityEngine;

public abstract class EnemyState
{
    protected EnemyController _controller;

    public EnemyState(EnemyController controller)
    {
        _controller = controller;
    }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();
}
