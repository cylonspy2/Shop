using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    float startY = + 0.5f;

    void Update()
    {
        Vector3 playerPos = playerTransform.position;
        transform.position = new Vector3 (playerPos.x, startY, playerPos.z);
    }
}
