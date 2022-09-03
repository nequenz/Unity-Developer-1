using UnityEngine;

public class InputChanger : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] float _valueToAccept = 10f;

    public void TakeValue() => _health?.TakeAmount(_valueToAccept);
}
