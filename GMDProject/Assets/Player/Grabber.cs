using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrabberState
{
    NOTGRABBING,
    GRABBING
}
public class Grabber : MonoBehaviour
{
    public GrabberState grabberState {get; private set;}
    private Transform cameraTransform;
    private Transform grabbedObjectTransform;
    private Camera playerCamera;
    [SerializeField]
    private float grabDistance = 2.0f;
    [SerializeField]
    private float dropDistance = 3.0f;
    private bool objectInFront;
    private bool grabValue;
    private RaycastHit hitInfo;

    void SetState(GrabberState grabberState)
    {
        this.grabberState = grabberState;
    }

    GrabberState GetState()
    {
        return this.grabberState;
    }

    void Awake()
    {
        cameraTransform = gameObject.transform.GetChild(0).GetComponent<Transform>();
       Debug.Log(cameraTransform);
    }
    // Start is called before the first frame update
    void Start()
    {
         //.GetComponent<CameraController>().GetCameraTransform();
    }

    // Update is called once per frame
    void Update()
    {
        //Grab Input
        grabValue = Input.GetButtonDown("Grab");

        //Check if object in front

        objectInFront = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitInfo, grabDistance);

        if (grabValue && objectInFront && grabberState.Equals(GrabberState.NOTGRABBING))
        {
            if (hitInfo.transform.gameObject.GetComponent<Grabable>() != null)
            {
                if (hitInfo.transform.gameObject.GetComponent<Grabable>().GetGrabbedState().Equals(GrabbedState.UNGRABBED))
                {
                    GrabObject();
                }

            }
        }
        else if (grabValue && grabberState.Equals(GrabberState.GRABBING))
        {
            UnGrabObject();
        }

        if (grabbedObjectTransform!=null)
        {
            float d = Vector3.Distance(gameObject.transform.position, grabbedObjectTransform.position);
            if (d > dropDistance)
            {
                UnGrabObject();
            }
        }
        if (grabbedObjectTransform == null)
        {
            SetState(GrabberState.NOTGRABBING);
        }
    }

    public void GrabObject()
    {
        grabbedObjectTransform = hitInfo.transform;
        grabbedObjectTransform.gameObject.GetComponent<Grabable>().Grab(cameraTransform, grabDistance);
        SetState(GrabberState.GRABBING);
    }

    public void UnGrabObject()
    {
        grabbedObjectTransform.gameObject.GetComponent<Grabable>().UnGrab();
        SetState(GrabberState.NOTGRABBING);
        grabbedObjectTransform = null;
    }

}
