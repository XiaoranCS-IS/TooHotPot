using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public GameObject statusBar;
    public GameObject progressBar;
    public GameObject player;

    public float pickUpRange;
    public float dropForwardForce;
    public float throwForwardForce;
    public bool isEquipped;

    public GameObject servingWindow;
    public GameObject menu;
    public GameObject table;
    public GameObject tableList;

    private void Start() {
        statusBar.SetActive(false);
        if(table != null){  
            transform.SetParent(table.transform);
            transform.localPosition = new Vector3(0.0f, 0.75f, 0.0f);
        }
        else{
            isEquipped = true;
            rb.isKinematic = true;
            coll.isTrigger = true;

            player.GetComponent<Player>().isEquipped = true;
            transform.SetParent(player.transform);
            transform.localPosition = new Vector3(0.0f, 3.0f, 3.0f);
        }
    }

    private void Update() {
        // check if player is in range and "G" is pressed and table is selected
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(!isEquipped && !player.GetComponent<Player>().isEquipped && distanceToPlayer.magnitude <= pickUpRange){
                // if object on ground, pick it up
                if (table == null)
                    PickUp();
                //if object on table, only pick up object on the selected table
                else if (transform.parent == table.transform){
                    if (table.GetComponent<Table>().isSelected){
                        PickUp();
                    }
                }
                // if object on ground, pick it up
                else
                    PickUp();
            }
            //Drop if equipped and "G" is pressed
            else if(player.GetComponent<Player>().isEquipped && isEquipped){
                if(Input.GetKeyDown(KeyCode.G)) {
                    // serving food
                    if(servingWindow.GetComponent<ServingWindowController>().isSelected) {
                        //menu match 1. hotpot 2. food
                        // if(menu.GetComponent<MenuController>().type == 1){

                        // }
                        // else if (menu.GetComponent<MenuController>().type == 2){
                        if (true){
                            // food must be chopped
                            if (progressBar.GetComponent<Slider>().value == 1)
                            { 
                                ScoreController.scoreBoard.AddScore();
                                player.GetComponent<Player>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }
                            
                                //to do sound
                        }
                    }
                    else
                        DropOff();
                }
            }
        } 

        // throw if H pressed and both equipped
        if (player.GetComponent<Player>().isEquipped && isEquipped && Input.GetKeyDown(KeyCode.H))
                    ThrowOut(); 
        else if(!player.GetComponent<Player>().isEquipped && !isEquipped && Input.GetKeyDown(KeyCode.H)){
            if (table != null){
                if (transform.parent == table.transform){
                    //if H pressed and food on selected chopping table
                    if (table.GetComponent<Table>().isSelected && table.GetComponent<Table>().type == 4){
                        ChoppingFood();
                    }
                }
            }
           
        }
    }

    private void PickUp() {
        isEquipped = true;
        rb.isKinematic = true;
        coll.isTrigger = true;

        if (table != null)
        {
            table.GetComponent<Table>().isEmpty = true;
        }
        player.GetComponent<Player>().isEquipped = true;
        transform.SetParent(player.transform);
        transform.localPosition = new Vector3(0.0f, 3.0f, 3.0f);
    }

    private void DropOff() {

        //if one table is selected, put object on table
        if (tableList.GetComponent<TableController>().selectedTable != null)
        {
            table = tableList.GetComponent<TableController>().selectedTable;
            if (table.GetComponent<Table>().isEmpty)
            {
                isEquipped = false;
                rb.isKinematic = false;
                coll.isTrigger = false;
                player.GetComponent<Player>().isEquipped = false;

                table.GetComponent<Table>().isEmpty = false;
                transform.SetParent(table.transform);
                transform.localPosition = new Vector3(0.0f, 0.75f, 0.0f);
            }
        }
        // drop object on ground
        else
        {
            isEquipped = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            player.GetComponent<Player>().isEquipped = false;
            
            transform.SetParent(null);
            rb.velocity = player.GetComponent<Rigidbody>().velocity;
            rb.AddForce(player.transform.forward * dropForwardForce, ForceMode.Impulse);
        }
    }

    private void ThrowOut() {
        isEquipped = false;
        rb.isKinematic = false;
        coll.isTrigger = false;

        player.GetComponent<Player>().isEquipped = false;

        transform.SetParent(null);
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(player.transform.forward * throwForwardForce, ForceMode.Impulse);
    }

    private void ChoppingFood() {
        if (progressBar.GetComponent<Slider>().value == 1){
            //to do change status
            statusBar.SetActive(false);
            return;
        }
        progressBar.GetComponent<Slider>().value += 0.1f;
        statusBar.SetActive(true);
    }
}
