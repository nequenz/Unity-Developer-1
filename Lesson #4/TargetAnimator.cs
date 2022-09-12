using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnimator : MonoBehaviour
{
    [SerializeField] private float _angleSpeed = 15;

    void Update()
    {
        Animate();
    }

    private void Animate()
    {
        transform.rotation = Quaternion.AngleAxis(transform.rotation.eulerAngles.y + _angleSpeed * Time.deltaTime, Vector3.up);
    }
}
