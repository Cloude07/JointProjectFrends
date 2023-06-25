using System.Collections.Generic;
using UnityEngine;

namespace CloudeDev.Architecture
{
    internal sealed class GameContext
    {
        public GameState State => state;

        private GameState state;

        private readonly List<IGameListeners> listeners = new();
        private readonly List<IGameUpdateListeners> updateListeners = new();
        private readonly List<IGameFixedUpdateListeners> fixedUpdateListeners = new();
        private readonly List<IGameLateUpdateListeners> lateUpdateListeners = new();

        internal void Update()
        {
            if (state != GameState.PLAYING) return;

            var deltaTime = Time.deltaTime;

            foreach (var listener in updateListeners)
            {
                listener.OnUpdate(deltaTime);
            }
        }

        internal void FixedUpdate()
        {
            if (state != GameState.PLAYING) return;

            var fixedDeltaTime = Time.fixedDeltaTime;

            foreach (var listener in fixedUpdateListeners)
            {
                listener.OnFixedUpdate(fixedDeltaTime);
            }
        }

        internal void LateUpdate()
        {
            if (state != GameState.PLAYING) return;

            var deltaTime = Time.deltaTime;

            foreach (var listener in lateUpdateListeners)
            {
                listener.OnLateUpdate(deltaTime);
            }
        }

        internal void AddListener(IGameListeners listener)
        {
            if (listener == null)
                return;

            listeners.Add(listener);

            if (listener is IGameUpdateListeners updatelistener)
                updateListeners.Add(updatelistener);

            if (listener is IGameFixedUpdateListeners fixedUpdatelistener)
                fixedUpdateListeners.Add(fixedUpdatelistener);

            if (listener is IGameLateUpdateListeners lateUpdateListener)
                lateUpdateListeners.Add(lateUpdateListener);
        }

        internal void AddListeners(IEnumerable<IGameListeners> listeners)
        {
            foreach (var listener in listeners)
            {
                AddListener(listener);
            }
        }

        internal void RemoveListener(IGameListeners listener)
        {
            if (listener == null)
                return;

            listeners.Remove(listener);

            if (listener is IGameUpdateListeners updatelistener)
                updateListeners.Remove(updatelistener);

            if (listener is IGameFixedUpdateListeners fixedUpdatelistener)
                fixedUpdateListeners.Remove(fixedUpdatelistener);

            if (listener is IGameLateUpdateListeners lateUpdateListener)
                lateUpdateListeners.Remove(lateUpdateListener);
        }

        internal void InitGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IGameInitListeners initLisiner)
                {
                    initLisiner.OnInitGame();
                }
            }
            state = GameState.INITING;
        }

        internal void StartGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IGameStartListeners startLisiner)
                {
                    startLisiner.OnStartGame();
                }
            }
            state = GameState.PLAYING;
        }

        [ContextMenu("PauseGame")]
        public void PauseGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IGamePauseListeners pauseLisiner)
                {
                    pauseLisiner.OnPauseGame();
                }
            }
            state = GameState.PAUSED;
        }

        [ContextMenu("ResumeGame")]
        public void ResumeGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IGameResumeListeners resumerLisiner)
                {
                    resumerLisiner.OnResumeGame();
                }
            }
            state = GameState.RESUME;
        }

        internal void FinishGame()
        {
            foreach (var listener in listeners)
            {
                if (listener is IGameFinishListeners finishLisiner)
                {
                    finishLisiner.OnFinishGame();
                }
            }
            state = GameState.FINISHED;
        }

    }
}
