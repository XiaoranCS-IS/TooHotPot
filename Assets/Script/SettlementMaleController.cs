using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementMaleController : MonoBehaviour
{
    private Animator animatorPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKey(KeyCode.Z))
            animatorPlayer.SetBool("IsWalkBtnPressed", true);
        else
            animatorPlayer.SetBool("IsWalkBtnPressed", false);
        
        if (Input.GetKey(KeyCode.X))
            animatorPlayer.SetBool("IsRunBtnPressed", true);
        else
            animatorPlayer.SetBool("IsRunBtnPressed", false);

        if (Input.GetKey(KeyCode.C))
            animatorPlayer.SetBool("IsCheerupBtnPressed", true);
        else
            animatorPlayer.SetBool("IsCheerupBtnPressed", false);

        if (Input.GetKey(KeyCode.V))
            animatorPlayer.SetBool("IsAngryBtnPressed", true);
        else
            animatorPlayer.SetBool("IsAngryBtnPressed", false);
    }
}
