using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayMove : MonoBehaviour
{
    public Vector2 toMove;

    public CharacterController controller;

    public float speed = 12f;

    void OnMove(InputValue value) => toMove = value.Get<Vector2>();

    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //Vector2 move = transform.right * x + transform.forward * z;

        if(toMove != Vector2.zero && GameController.players[0].canMove)
        {
            controller.Move((new Vector3(toMove.x, 0, toMove.y) * speed + Physics.gravity) * Time.deltaTime);
        }
    }
}
