using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownHandler : MonoBehaviour
{

    public List<GameObject> allPanels;

    // Start is called before the first frame update
    void Start()
    {
        dropdownValueChanged(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dropdownValueChanged(int selected)
    {
        foreach(GameObject panel in allPanels)
        {
                panel.SetActive(false);
        }

        allPanels[selected].SetActive(true);
    }
}
