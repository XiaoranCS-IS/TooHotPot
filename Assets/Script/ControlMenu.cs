using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public Canvas mainMenu;
    private Canvas controlMenu;
    // Start is called before the first frame update
    void Start()
    {
        controlMenu = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackBtnPressed() {
        mainMenu.gameObject.SetActive(true);
        controlMenu.gameObject.SetActive(false);
    }
}
