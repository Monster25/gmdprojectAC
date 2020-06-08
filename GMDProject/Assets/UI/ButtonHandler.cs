using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    public delegate void ButtonClick();
    Button myBtn;

    void Start()
    {
        myBtn = GetComponent<Button>();
        myBtn.onClick.AddListener(delegate {
            
        });
    }

    void OnDestroy(){
        myBtn.onClick.RemoveAllListeners();
    }
}
