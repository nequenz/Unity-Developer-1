using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _positionTolook;

    private void Start()
    {
        
    }

    private void Update()
    {
        LookAtPosition();
    }

    private void LookAtPosition()
    {
        if( _positionTolook != null )
        {
            transform.LookAt(_positionTolook, Vector3.up);
        }
    }
}
