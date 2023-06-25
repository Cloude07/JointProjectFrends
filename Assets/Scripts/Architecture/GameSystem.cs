using System;
using System.Collections.Generic;
using UnityEngine;

namespace CloudeDev.Architecture
{
    public sealed class GameSystem : MonoBehaviour
    {
        public GameSystem()
        {
            injector = new DependencyInjector(serviceLocator);
        }

        #region GameListeners

        [SerializeField]
        private bool autoRun = true;
        public GameState State => gameManager.State; 

        private readonly GameContext gameManager = new GameContext();

        private void Start()
        {
            if(autoRun)
            {
                InitGame();
            }
        }

        private void Update()
        {
            gameManager.Update();
        }

        private void FixedUpdate()
        {
            gameManager.FixedUpdate();
        }

        private void LateUpdate()
        {
            gameManager.LateUpdate();
        }

        public void AddListener(IGameListeners listener)
        {
            gameManager.AddListener(listener);
        }

        public void AddListeners(IEnumerable<IGameListeners> listeners)
        {
            gameManager.AddListeners(listeners);
        }

        public void RemoveListener(IGameListeners listener)
        {
            gameManager.RemoveListener(listener);
        }

        [ContextMenu("Init")]
        public void InitGame()
        {
            gameManager.InitGame();
        }

        [ContextMenu("Start")]
        public void StartGame()
        {
            gameManager.StartGame();
        }

        [ContextMenu("Pause")]
        public void PauseGame()
        {
            gameManager.PauseGame();
        }

        [ContextMenu("Resume")]
        public void ResumePause()
        {
            gameManager.ResumeGame();
        }

        [ContextMenu("FinishGame")]
        public void FinishGame()
        {
            gameManager.FinishGame();
        }

        #endregion

        #region ServiceLocator

        private readonly ServiceLocator serviceLocator = new ServiceLocator();
        public List<T> GetServices<T>()
        {
            return serviceLocator.GetServices<T>();
        }

        public object GetService(Type serviceType)
        {
            return serviceLocator.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return serviceLocator.GetService<T>();
        }

        public void AddService(object service)
        {
            serviceLocator.AddService(service);
        }

        public void AddServices(IEnumerable<object> service)
        {
            serviceLocator.AddServices(service);
        }

        #endregion

        #region DependencyInjection

        private readonly DependencyInjector injector;
        public  void Inject(object target)
        {
            injector.Inject(target);
        }

        #endregion
    }
}
