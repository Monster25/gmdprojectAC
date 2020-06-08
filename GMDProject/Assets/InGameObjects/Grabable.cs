using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrabbedState
    {
        UNGRABBED,
        GRABBED
    }
public class Grabable : MonoBehaviour
{
    private Transform objectTransform;
    private Outline cubeOutline;
    private Rigidbody rb;
    private float holdDistance, lerpProg;
    private Transform grabberTransform;
    private float originalAngularDrag, dropDistance;
    private bool hoveredOn;
    [SerializeField]
    private float distanceToPlayer = 3;
    private Color currentOutlineColor = new Color(255, 255, 255);
    public GrabbedState grabbedState {get; private set;}


    void SetGrabbedState(GrabbedState grabbedState)
    {
        this.grabbedState = grabbedState;
    }

    public GrabbedState GetGrabbedState()
    {
        return this.grabbedState;
    }

    void Awake()
    {
        
        objectTransform = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        cubeOutline = gameObject.GetComponent<Outline>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originalAngularDrag = rb.angularDrag;
    }

    // Update is called once per frame
    void Update()
    {
        //Highlight on distance
        
        float dtp  = Vector3.Distance(MyGameManager.GetInstance().GetPlayerTransform().position, objectTransform.position);

        if (grabbedState.Equals(GrabbedState.GRABBED))
        {
            cubeOutline.OutlineColor = new Color (255,0,0);
            cubeOutline.OutlineMode = Outline.Mode.OutlineVisible;
        }

        else
            if (dtp<=distanceToPlayer)
            {
                if (hoveredOn)
                cubeOutline.OutlineColor = new Color (0,255,0);
                else
                cubeOutline.OutlineColor = new Color (255,255,255);

                cubeOutline.OutlineMode = Outline.Mode.OutlineVisible;
            }
            else if (dtp>distanceToPlayer)
            {
                cubeOutline.OutlineMode = Outline.Mode.SilhouetteOnly;
            }
    }

    void FixedUpdate()
    {
        //Move With Grabber
        if (grabbedState.Equals(GrabbedState.GRABBED))
        {
            gameObject.transform.rotation = grabberTransform.rotation;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,grabberTransform.position+grabberTransform.forward*holdDistance,0.1f);
        }
    }

    void OnMouseOver()
    {
        hoveredOn = true;
    }

    void OnMouseExit()
    {
        hoveredOn = false;
    }

    public void Grab(Transform grabberTransform, float holdDistance)
    {
        if (grabbedState.Equals(GrabbedState.UNGRABBED))
        {
        SetGrabbedState(GrabbedState.GRABBED);
        this.grabberTransform = grabberTransform;
        rb.useGravity = false;
        //Physics.IgnoreCollision(GetComponent<Collider>(), grabberTransform.GetComponent<Collider>());
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        //rb.angularDrag = 9999;
        this.holdDistance = holdDistance;
        this.dropDistance = dropDistance;
        }
    }

    public void UnGrab()
    {
        SetGrabbedState(GrabbedState.UNGRABBED);
       // rb.angularDrag = originalAngularDrag;
        //rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
    }

    void OnDestroy()
    {
        SetGrabbedState(GrabbedState.UNGRABBED);
        // rb.angularDrag = originalAngularDrag;
        //rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
    }
}
