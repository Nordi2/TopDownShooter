using Assets.CodeBase.Logic.EnemySamurai;
using UnityEngine;

public class EnemySamuraiTrigger : MonoBehaviour
{
    private EnemySamurai _enemy;
    private void Awake()
    {
        _enemy = GetComponentInParent<EnemySamurai>();
    }
    public void AnimationTrigger() =>
        _enemy.AnimationTrigger();
    public void PulletWeapon() =>
        _enemy.PulletWeapon();
}
