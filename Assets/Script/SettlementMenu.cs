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
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    // Start is called before the first frame update
    void Start()
    {
        settlementMenu = GetComponent<Canvas>();
        settlementMenu.gameObject.SetActive(false);
    }

    public void GameOver() {
        settlementMenu.gameObject.SetActive(true);
        scoreText.text = scoreBoard.GetComponent<ScoreController>().score.ToString();
        if (scoreBoard.GetComponent<ScoreController>().score < 100)
        {
            star2.SetActive(false);
            star3.SetActive(false);
        }
        else if (scoreBoard.GetComponent<ScoreController>().score < 250)
        {
            star3.SetActive(false);
        }
    }

    public void RestartBtnPressed() {
        //to do
        settlementMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
