using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField]
    private float transformScale;
    [SerializeField]
    private bool offsetInZ;

    private Vector3 initPos;

    private void Start()
    {
        initPos = transform.localPosition;
    }

    private void FixedUpdate()
    {
        float offset = Mathf.Sin(Time.time) * transformScale;

        Vector3 newPosition = offsetInZ ? new Vector3(initPos.x, initPos.y, initPos.z + offset) : new Vector3(initPos.x + offset, initPos.y, initPos.z);

        transform.localPosition = newPosition;
    }
}
