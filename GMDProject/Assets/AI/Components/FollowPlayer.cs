using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float followSpeed = 2;
    private float _distance, speed;
    private Transform myTransform;
    private Rigidbody rb;
    private MyGameManager gameManager;
    void Awake()
    {
        gameManager = MyGameManager.GetInstance();
        myTransform = gameObject.transform.GetComponent<Transform>();
        rb = gameObject.transform.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        speed = followSpeed*Time.deltaTime;
        _distance = Vector3.Distance(myTransform.position, gameManager.GetPlayerTransform().position);
        
        //Vector3 _targetVector = (myTransform.position, gameManager.GetPlayerTransform().position).normalized; 
        //rb.AddForce(myTransform.forward*100);
    }

    void FixedUpdate()
    {
        if (_distance < 10 && _distance > 3)
        {
            //rb.AddForce(myTransform.forward * 100);
            myTransform.position = Vector3.Lerp(myTransform.position, gameManager.GetPlayerTransform().position, speed);
        }
        else
        {
            Vector3 _vel = rb.velocity;
            _vel = new Vector3(0, _vel.y, 0);
            rb.velocity = _vel;
        }
    }
}
