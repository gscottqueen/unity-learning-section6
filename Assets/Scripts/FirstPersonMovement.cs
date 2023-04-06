using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    // players movment parameters
    public Vector3 direction;
    public float speed;

    public Rigidbody rb; // the players rigig body

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // all physics calculations happen in FixedUpdate
    void FixedUpdate()
    {
      // dont mix transfrom translate with rigid bodies
      // transform.Translate(direction * speed * Time.deltaTime);
      Vector3 localDirection = transform.TransformDirection(direction);
      //move using physics
      rb.MovePosition(rb.position + (localDirection * speed * Time.deltaTime));
    }

    // OnPlayerMove event handler
    public void OnPlayerMove(InputValue value)
    {
        // player controls input [-1,1]
        Vector2 InputVector = value.Get<Vector2>();
        // direction = new Vector3(InputVector.x, 0, InputVector.y);

        direction.x = InputVector.x;
        direction.z = InputVector.y;
    }
}
