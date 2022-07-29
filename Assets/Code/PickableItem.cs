using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private float _rotateY = 0.0f;
    [SerializeField] private float _rotationStep = 10.0f;

    private void Start()
    {
        _rotateY = transform.rotation.y;
    }

    private void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy( gameObject );
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.AngleAxis(transform.rotation.eulerAngles.y + _rotationStep * Time.deltaTime, Vector3.up );
    }
}
