using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;
    private State _currentState;
    
    public State CurrentState => _currentState;
    public State StartState => _startState;

    private void Start() => _currentState = _startState;

    private void OnEnable()
    {
        foreach(State state in GetComponents(typeof(State)))
        {
            if (state.HasOnChangedListener() == false)
                state.AttachOnChangedListener(OnStateCnanged);

            if (state != _currentState)
                state.enabled = false;
        }
    }

    private void OnDisable()
    {
        foreach (State state in GetComponents(typeof(State)))
            state.enabled = false;
    }

    private void Update()
    {
        if (_currentState != null && _currentState.enabled == false)
            _currentState.enabled = true;
    }

    private void OnStateCnanged(State oldState, State newState)
    {
        _currentState = newState;

        if ( newState != null )
            Debug.Log(oldState.GetType().FullName + " has been finished and changed on " + newState.GetType().FullName);
    }
        
}
