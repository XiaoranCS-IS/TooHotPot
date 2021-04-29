using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementFemaleController : MonoBehaviour
{
    private Animator animatorPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKey(KeyCode.M))
            animatorPlayer.SetBool("IsWalkBtnPressed", true);
        else
            animatorPlayer.SetBool("IsWalkBtnPressed", false);
        
        if (Input.GetKey(KeyCode.Comma))
            animatorPlayer.SetBool("IsRunBtnPressed", true);
        else
            animatorPlayer.SetBool("IsRunBtnPressed", false);

        if (Input.GetKey(KeyCode.Period))
            animatorPlayer.SetBool("IsCheerupBtnPressed", true);
        else
            animatorPlayer.SetBool("IsCheerupBtnPressed", false);

        if (Input.GetKey(KeyCode.Slash))
            animatorPlayer.SetBool("IsAngryBtnPressed", true);
        else
            animatorPlayer.SetBool("IsAngryBtnPressed", false);
    }
}
