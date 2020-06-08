using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    Transform leftPartTransform, rightPartTransform, gateTransform;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        gateTransform = gameObject.GetComponent<Transform>();
        leftPartTransform = gateTransform.GetChild(0).GetComponent<Transform>();
        rightPartTransform = gateTransform.GetChild(1).GetComponent<Transform>();
    }

    public void OpenDoor()
    {
        animator.SetBool("open", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("open", false);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
