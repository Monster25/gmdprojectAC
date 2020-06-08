using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPlayer : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 5;
    private Transform attachedEntityTransform;
    private MyGameManager gameManager;
    void Awake()
    {
        attachedEntityTransform = gameObject.transform.GetComponent<Transform>();
        gameManager = MyGameManager.GetInstance();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = gameManager.GetPlayerTransform().position - attachedEntityTransform.position;
        attachedEntityTransform.rotation = Quaternion.Lerp(attachedEntityTransform.rotation, Quaternion.LookRotation(relativePos), Time.deltaTime*turnSpeed);
    }

}
