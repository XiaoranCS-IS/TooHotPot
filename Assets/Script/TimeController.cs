using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public int secondsLeft;
    public bool takingAway = false;
    public GameObject settlementMenu;

    private void Start() {
        int min = secondsLeft / 60;
        int sec = secondsLeft % 60;
        if (sec < 10)
        {
            gameObject.GetComponent<Text>().text = "0" + min + ":0" + sec;
        }
        else
        {
            gameObject.GetComponent<Text>().text = "0" + min + ":" + sec;
        }
    }

    private void Update() {
        if (takingAway == false && secondsLeft >= 0)
        {
            StartCoroutine(TimerTake());
        }
        else if (secondsLeft < 0)
        {
            settlementMenu.GetComponent<SettlementMenu>().GameOver();
            gameObject.SetActive(false);
        }
    }
    
    IEnumerator TimerTake(){
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        int min = secondsLeft / 60;
        int sec = secondsLeft % 60;
        if (sec < 10)
        {
            gameObject.GetComponent<Text>().text = "0" + min + ":0" + sec;
        }
        else
        {
            gameObject.GetComponent<Text>().text = "0" + min + ":" + sec;
        }
        takingAway = false;
    }
}
