using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettlementMenu : MonoBehaviour
{
    private Canvas settlementMenu;

    public GameObject scoreBoard;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        settlementMenu = GetComponent<Canvas>();
        settlementMenu.gameObject.SetActive(false);
    }

    public void GameOver() {
        settlementMenu.gameObject.SetActive(true);
        scoreText.text = scoreBoard.GetComponent<ScoreController>().score.ToString();
    }

    public void RestartBtnPressed() {
        //to do
        settlementMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
