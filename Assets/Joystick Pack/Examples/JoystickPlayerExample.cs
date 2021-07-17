using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;
    public float _smoothing = 0.1f;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;


        // change the fixedJoystick verticals?? or maybe the Vect3.forward idk have to test and figure out
        // make it so that it relies on the rotation of the camera --> cos() and sin()??

        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (fixedJoystick.Vertical == 0 && fixedJoystick.Horizontal == 0)
        {
            rb.velocity = Vector3.Slerp(rb.velocity, Vector3.zero, _smoothing);
        }
    }
}