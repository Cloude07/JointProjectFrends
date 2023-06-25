namespace CloudeDev.Architecture
{
    public interface IGameListeners
    {
    }


    public interface IGameInitListeners : IGameListeners
    {
        void OnInitGame();
    }

    public interface IGameStartListeners : IGameListeners
    {
        void OnStartGame();
    }

    public interface IGamePauseListeners : IGameListeners
    {
        void OnPauseGame();
    }

    public interface IGameResumeListeners : IGameListeners
    {
        void OnResumeGame();
    }

    public interface IGameFinishListeners : IGameListeners
    {
        void OnFinishGame();
    }
    
    public interface IGameUpdateListeners : IGameListeners
    {
        void OnUpdate(float deltaTime);
    }

    public interface IGameFixedUpdateListeners : IGameListeners
    {
        void OnFixedUpdate(float FixedDeltaTime);
    }

    public interface IGameLateUpdateListeners : IGameListeners
    {
        void OnLateUpdate(float deltaTime);
    }
}