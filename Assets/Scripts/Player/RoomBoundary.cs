using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoundary : MonoBehaviour
{
    public float leftBound;
    public float rightBound;

    private void Update()
    {
        DetectBoundary();
    }

    void DetectBoundary()
    {
        Vector3 posAdjustment = GameManager.Instance.player.transform.position;

        // Adjust
        if (GameManager.Instance.player.transform.position.x < leftBound) posAdjustment.x = leftBound;
        if (GameManager.Instance.player.transform.position.x > rightBound) posAdjustment.x = rightBound;

        // Reset it back
        GameManager.Instance.player.transform.position = posAdjustment;
    }

}
