using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    // camera attached to player
    public Camera playerCamera;

    // container variables for mouse sensitivity values
    public float sensX;
    public float sensY;

    // container variables for the mouse delta values each frame
    public float deltaX;
    public float deltaY;

    // container variables for the players rotation around X and Y axis
    public float xRot; // rotation around x-axis in degrees
    public float yRot; // rotation around y-axis in degrees
    
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main; // set player camera
        Cursor.visible = false; // hides the cursor
    }

    // Update is called once per frame
    void Update()
    {
        // keep track of the players x and y rotation
        yRot += deltaX * Time.deltaTime * sensX;
        xRot -= deltaY * Time.deltaTime * sensY;

        // keep the players x rotation clampled to [-90,90] degrees
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // rotate the camera around the x-axis;
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    // OnCameraLook event handler
    public void OnCameraLook(InputValue value)
    {
        // reading the mouse deltas as a vector 2 (deltaX is the x component and deltaY is the y component)
        Vector2 InputVector = value.Get<Vector2>();
        deltaX = InputVector.x;
        deltaY = InputVector.y;
    }
}
