using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownSelection : MonoBehaviour
{
    Dropdown m_Dropdown;
    MyGameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = MyGameManager.GetInstance();

        m_Dropdown = GetComponent<Dropdown>();

        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });

        gameManager.SetEnemyColor(m_Dropdown.value);
    }

    void DropdownValueChanged(Dropdown change)
    {
        gameManager.SetEnemyColor(change.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
