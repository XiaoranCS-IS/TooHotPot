using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingWindowController : MonoBehaviour
{
    public GameObject window;
    public Transform player;
    public Transform arrowPlayer;
    public bool isSelected;

    public float selectedRange;
    public Color selectedColor;
    public Color unSelectedColor;

    private void Start() {
        window.GetComponent<Renderer>().material.color = unSelectedColor;
    }

    // Update is called once per frame
    private void Update()
    {
        // check if table is in range
        bool playerInRange = false;
        bool arrowPlayerInRange = false;
        Vector3 distanceToPlayer = player.position - window.transform.position;
        if (distanceToPlayer.magnitude < selectedRange){
            playerInRange = true;
        }
        else if (distanceToPlayer.magnitude >= selectedRange){
            playerInRange = false;
        }

        distanceToPlayer = arrowPlayer.position - window.transform.position;
        if (distanceToPlayer.magnitude < selectedRange){
            arrowPlayerInRange = true;
        }
        else if (distanceToPlayer.magnitude >= selectedRange){
            arrowPlayerInRange = false;
        }

        if (playerInRange || arrowPlayerInRange){
            isSelected = true;
            window.GetComponent<Renderer>().material.color = selectedColor;
        }
        else{
            isSelected = false;
            window.GetComponent<Renderer>().material.color = unSelectedColor;
        }
    }
}
