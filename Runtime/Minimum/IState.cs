namespace Dave6.StateMachine
{
    public interface IState
    {
        void OnEnter();
        void Update();
        void FixedUpdate();
        void LateUpdate();
        void OnExit();
    }
}