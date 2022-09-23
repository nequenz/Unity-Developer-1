using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class State : MonoBehaviour
{
    private Action<State, State> _onChanged;
    protected StateMachine OwnStateMachine;

    protected virtual void Awake() => enabled = false;

    protected void ChangeState(State newState)
    {
        enabled = false;
        _onChanged?.Invoke(this, newState);
    }

    public bool HasOnChangedListener() => _onChanged != null;

    public void AttachOnChangedListener(Action<State, State> onChanged) => _onChanged = onChanged;
}
