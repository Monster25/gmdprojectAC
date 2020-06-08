using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]
    private GameObject gateLink;
    private bool used = false;
    private Gate gate;
    private Animator animator;

    private List<Collider> collidingList = new List<Collider>();
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        gate = gateLink.GetComponent<Gate>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" || c.gameObject.tag == "Pressure")
        {
            collidingList.Add(c);
            animator.SetBool("pushed", true);
            gate.OpenDoor();

        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Pressure" || c.tag == "Player")
        {
            collidingList.Remove(c);
            if (collidingList.Count <= 0)
            {
                animator.SetBool("pushed", false);
                gate.CloseDoor();
            }
        }
    }
}
