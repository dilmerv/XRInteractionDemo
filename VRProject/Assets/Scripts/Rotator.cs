using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed;

    [SerializeField]
    private bool rotate;

    void Update()
    {
        if(rotate)
            transform.Rotate(speed * Time.deltaTime, Space.World);
    }

    public void StartRotation()
    {
        rotate = true;
    }

    public void StopRotation()
    {
        rotate = false;
    }
}
