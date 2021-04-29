using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Canvas mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = GetComponent<Canvas>();  
    }

    public void ExitBtnPressed() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void PlayBtnPressed() {
        mainMenu.gameObject.SetActive(false);
    }
}
