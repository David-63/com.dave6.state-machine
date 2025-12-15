namespace Dave6.StateMachine
{
    public abstract class BaseState<TOwner> : IState
    {
        protected TOwner controller;

        public BaseState(TOwner controller) => this.controller = controller;
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
    }
}