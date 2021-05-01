using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Canvas mainMenu;
    public Canvas controlMenu;
    public GameObject timeCount;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = GetComponent<Canvas>(); 
        timeCount.gameObject.SetActive(false);
    }

    public void ExitBtnPressed() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void PlayBtnPressed() {
        mainMenu.gameObject.SetActive(false);
        timeCount.gameObject.SetActive(true);
    }

    public void ControlBtnPressed() {
        mainMenu.gameObject.SetActive(false);
        controlMenu.gameObject.SetActive(true);
    }
}
