using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class State : MonoBehaviour
{
    protected StateMachine OwnStateMachine;

    public event Action<State, State> Changed;

    protected virtual void Awake() => enabled = false;

    protected void ChangeState(State newState)
    {
        enabled = false;
        Changed?.Invoke(this, newState);
    }

    public bool HasOnChangedListener() => Changed != null;
}
