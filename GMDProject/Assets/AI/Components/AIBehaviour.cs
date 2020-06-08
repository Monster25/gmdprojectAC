using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    MyGameManager gameManager;
    Material redMat, yellowMat, purpleMat;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = MyGameManager.GetInstance();
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        switch(gameManager.GetEnemyMaterialId())
        {
            case 1:
            redMat = Resources.Load<Material>("M_Gate0");
            meshRenderer.material = redMat;
            break;
            case 0:
            yellowMat = Resources.Load<Material>("M_Gate1");
            meshRenderer.material = yellowMat;
            break;
            case 2:
            purpleMat = Resources.Load<Material>("M_Gate8");
            meshRenderer.material = purpleMat;
            break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
