using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingWindowController : MonoBehaviour
{
    public GameObject window;
    public Transform player;
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
        Vector3 distanceToPlayer = player.position - window.transform.position;
        if (!isSelected && distanceToPlayer.magnitude < selectedRange){
            isSelected = true;
            window.GetComponent<Renderer>().material.color = selectedColor;
        }
        else if (isSelected && distanceToPlayer.magnitude >= selectedRange){
            isSelected = false;
            window.GetComponent<Renderer>().material.color = unSelectedColor;
        }
    }
}
