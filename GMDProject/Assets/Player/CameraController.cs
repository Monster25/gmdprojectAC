using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotY, rotX;
    private float lookUpDownValue, lookLeftRightValue;
    [SerializeField]
    private float lookSpeed = 0;

    private Transform cameraTransform;

    void Awake()
    {
        cameraTransform = gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Read Input
        lookUpDownValue = Input.GetAxis("Mouse Y");
       // lookLeftRightValue = Input.GetAxis("Mouse X");
        //Calculate Camera Rotation
        rotY += lookUpDownValue * lookSpeed;
      //  rotX += lookLeftRightValue * lookSpeed;

        rotY = Mathf.Clamp(rotY, -90f, 90f);

        //Rotate camera
        cameraTransform.localRotation = Quaternion.Euler(rotY*-1.0f, 0f, 0f);
    }

    public float GetLookSpeed()
    {
        return lookSpeed;
    }

    public Transform GetCameraTransform()
    {
        return cameraTransform;
    }
}
