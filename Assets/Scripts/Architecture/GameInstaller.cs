using UnityEngine;

namespace CloudeDev.Architecture
{
    [RequireComponent(typeof(GameSystem))]
    public sealed class GameInstaller : MonoBehaviour
    {
        [SerializeField]
        private GameModule[] modules;

        private GameSystem gameSystem;
        private void Awake()
        {
            gameSystem = GetComponent<GameSystem>();
            InstallService();
            InstallListeners();
            ResolverDependencies();
        }

        private void InstallListeners()
        {
            foreach (var module in modules)
            {
                var listeners = module.GetListeners();
                gameSystem.AddListeners(listeners);
            }
        }

        private void InstallService()
        {
            foreach (var module in modules)
            {
                var service = module.GetServices();
                gameSystem.AddServices(service);
            }
        }

        private void ResolverDependencies()
        {
            foreach (var module in modules)
            {
                module.ResolveDependencies(gameSystem);
            }
        }
    }
}
