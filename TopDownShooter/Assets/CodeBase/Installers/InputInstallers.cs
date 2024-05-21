using Assets.CodeBase.Services;
using Zenject;

public class InputInstallers : MonoInstaller
{
    public InputService InputService;
    public override void InstallBindings()
    {
        Container
            .Bind<InputService>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}
