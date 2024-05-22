using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int _xVelocity = Animator.StringToHash("xVelocity");
    private static readonly int _zVelocity = Animator.StringToHash("zVelocity");
    private static readonly int Fire = Animator.StringToHash("Fire");
    private static readonly int Reloading = Animator.StringToHash("Reloading");

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Move(float xVelocity, float zVelocity)
    {
        _animator.SetFloat(_xVelocity, xVelocity, 0.1f, Time.deltaTime);
        _animator.SetFloat(_zVelocity, zVelocity, 0.1f, Time.deltaTime);
    }
    public void Shoot() =>
        _animator.SetTrigger(Fire);
    public void Reload() =>
        _animator.SetTrigger(Reloading);
}
