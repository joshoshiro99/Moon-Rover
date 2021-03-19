using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //This are the public variables for speed. They can be changed in the inspector in the unity window.
    public float forwardSpeed = 3.0f;
    public float turnSpeed = 2.0f;

    //This is a private variable and can only be accessed through the script.
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        //This makes the rb variable represent the rigidbody on the Moon Rover game object.
        rb = GetComponent<Rigidbody>();
    }
    //For physics it is best practice to use Fixed update rather than update as it is more reliable to due to being done at a fixed time, meaning lag or graphical strain won’t affect physics calculations
    private void FixedUpdate()
    {
        //These variables get input from the keys/joysticks as a float
        float forwardMoveAmount = Input.GetAxis("Vertical") * forwardSpeed;

        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed;

        transform.Rotate(0, turnAmount, 0);

        //MAKE SURE THE FRONT OF YOUR ROVER IS LINED UP WITH THE X AXIS OF THE MOON ROVER GAME OBJECT THE MODEL IS A CHILD OF
        //This applies a force on the rigidbody in the x dimension relative to its forward direction
        rb.AddRelativeForce(0, 0, forwardMoveAmount*forwardSpeed);

    }
}

