﻿using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform targetPlayer;
    private Vector3 offset = new Vector3(0, 10, -15);

    public void SetUp(int playerNumber, int playerCount, Transform target)
    {
        targetPlayer = target;

        Camera cam = GetComponent<Camera>();

        Vector2 position = Vector2.zero;
        Vector2 size = Vector2.one;

        if (playerCount > 1)
        {
            if (playerCount == 3)
                playerCount = 4;

            position = new Vector2(Mathf.Clamp01(playerNumber - 1f) * 0.5f, Mathf.Abs(((playerNumber % 2) - 1f) * 0.5f));
            size = new Vector2(2f / playerCount, 0.5f);
        }

        cam.rect = new Rect(position, size);
    }

    void LateUpdate()
    {
        if (targetPlayer != null)
            transform.position = Vector3.Lerp(transform.position, targetPlayer.position + offset, 5 * Time.deltaTime);
    }
}