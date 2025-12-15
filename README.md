# com.dave6.state-machine
게임플레이 로직을 위한 간단한 상태머신 모듈.


## 핵심요소

##### 1. StateMachine
`StateMachine`은 여러 `State` 객체를 관리,
조건(Predicate)이 만족될 때 상태 전이를 수행함.

* 하나의 `StateMachine` 은 단일 책임의 상태 집합을 관리함.
* 서로 다른 관심사는 여러 `StateMachine` 으로 분리하는게 좋음.


##### 2. State
각 `State` 는 다음과 같은 라이프사이클 메서드를 가진다.

```csharp
protected virtual void OnEnter() {}
protected virtual void OnExit() {}
protected virtual void OnUpdate() {}
protected virtual void OnFixedUpdate() {}
protected virtual void OnLateUpdate() {}
```

##### 3. Transition
상태 전이는 `At(from, to, predicate)` 형태로 정의됨
```csharp
stateMachine.At(fromState, toState, new FuncPredicate(() => condition));
```

- `fromState` -> `toState`
- `predicate`가 `true`가 되는 순간 전이 발생
- 조건은 람다혹은 함수로 선언

### Locomotion StateMachine
```csharp
m_LocomotionStateMachine = new();

var freeLook = new FreeLookState(this);
var strafeMove = new StrafeMoveState(this);

// 조준 입력에 따라 이동 방식 전환
m_LocomotionStateMachine.At(
    freeLook,
    strafeMove,
    new FuncPredicate(() => aimInput)
);

m_LocomotionStateMachine.At(
    strafeMove,
    freeLook,
    new FuncPredicate(() => !aimInput)
);
```
이런식으로 상태 전이를 구현