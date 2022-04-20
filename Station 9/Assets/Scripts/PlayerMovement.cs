using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public static bool canMove = true;

    public float speed = 10.0f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(x, 0.0f, z).normalized; //dont allow player to move vertically, also .normalized will make it so moving diaginonal dosent make u move faster :)

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

                Vector3 movementDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
                controller.Move(movementDirection.normalized * speed * Time.deltaTime);
            }
        }
        

        
    }
}
