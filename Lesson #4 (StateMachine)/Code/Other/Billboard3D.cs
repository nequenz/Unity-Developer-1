using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Billboard3D : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.rotation = transform.rotation * Quaternion.Euler(90f,0f,0f);
    }
}
