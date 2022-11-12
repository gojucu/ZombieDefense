using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private FloatingJoystick floatingJoystick;
    [SerializeField] float rotateSpeed = 15f;
    public GameObject cinemachineCameraTarget;

    private float _rotationVelocity;
    private float _cinemachineTargetPitch;
    public float BottomClamp;
    public float TopClamp;

    // Start is called before the first frame update
    void Start()
    {
        floatingJoystick = FindObjectOfType<FloatingJoystick>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (floatingJoystick.Vertical == 0 && floatingJoystick.Horizontal == 0)
    //    //{

    //    //}
    //    //else
    //    //{
            
    //    //}
    //}

    private void LateUpdate()
    {

        //Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        //float facing = Camera.main.transform.eulerAngles.y;
        //Vector3 turnedInputVector = Quaternion.Euler(0, facing, 0) * direction;
        ////movement
        ////_charController.SimpleMove(turnedInputVector * moveSpeed);

        ////mesh Rotate
        //if (floatingJoystick.Vertical != 0 && floatingJoystick.Horizontal != 0)
        //    transform.rotation = Quaternion.LookRotation(turnedInputVector);
        CameraRotation();

    }

    private void CameraRotation()
    {
        if (floatingJoystick.Vertical != 0 && floatingJoystick.Horizontal != 0)
        { 
            //Don't multiply mouse input by Time.deltaTime


            _cinemachineTargetPitch += floatingJoystick.Vertical * rotateSpeed ;
            _rotationVelocity = floatingJoystick.Horizontal * rotateSpeed;

            // clamp our pitch rotation
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Update Cinemachine camera target pitch
            cinemachineCameraTarget.transform.localRotation = Quaternion.Euler(-_cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            transform.Rotate(Vector3.up * _rotationVelocity);
        }
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}
