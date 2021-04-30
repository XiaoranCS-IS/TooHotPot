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
    public GameObject arrowPlayer;

    public float pickUpRange;
    public float dropForwardForce;
    public float throwForwardForce;
    public bool isEquipped;

    public GameObject servingWindow;
    public GameObject menu;
    public GameObject table;
    public GameObject tableList;
    public int pickupPlayer;

    private void Start() {
        statusBar.SetActive(false);
        if(table != null){  
            transform.SetParent(table.transform);
            transform.localPosition = new Vector3(0.0f, 0.75f, 0.0f);
        }
        else{
            // get new food
            if (pickupPlayer == 1){
                isEquipped = true;
                rb.isKinematic = true;
                coll.isTrigger = true;
                player.GetComponent<Player>().isEquipped = true;
                transform.SetParent(player.transform);
                transform.localPosition = new Vector3(0.0f, 3.0f, 3.0f);
            }
            else if(pickupPlayer == 2){
                isEquipped = true;
                rb.isKinematic = true;
                coll.isTrigger = true;
                arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = true;
                transform.SetParent(arrowPlayer.transform);
                transform.localPosition = new Vector3(0.0f, 3.0f, 3.0f);
            }
        }
    }

    private void Update() {
        UpdatePlayer();
        UpdateArrowPlayer();
    }

    private void UpdatePlayer() {
        // check if player is in range and "G" is pressed and table is selected
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(!isEquipped && !player.GetComponent<Player>().isEquipped && distanceToPlayer.magnitude <= pickUpRange){
                // if object on ground, pick it up
                if (table == null)
                    PlayerPickUp();
                //if object on table, only pick up object on the selected table
                else if (transform.parent == table.transform){
                    if (table.GetComponent<Table>().isSelected){
                        PlayerPickUp();
                    }
                }
                // if object on ground, pick it up
                else
                    PlayerPickUp();
            }
            //Drop if equipped and "G" is pressed
            else if(player.GetComponent<Player>().isEquipped && isEquipped && transform.parent == player.transform){
                if(Input.GetKeyDown(KeyCode.G)) {
                    // serving food
                    if(servingWindow.GetComponent<ServingWindowController>().isSelected) {
                        //menu match 1. hotpot 2. food
                        if(menu.GetComponent<MenuController>().type == 1){
                            // pot must be heated
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "SpicyHotpot")
                            { 
                                ScoreController.scoreBoard.AddScore();
                                player.GetComponent<Player>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }
                            
                                //to do sound
                        }
                        else if (menu.GetComponent<MenuController>().type == 2){
                            // pot must be chopped
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "MildHotpot")
                            { 
                                ScoreController.scoreBoard.AddScore();
                                player.GetComponent<Player>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }
                            
                                //to do sound
                        }
                        else if (menu.GetComponent<MenuController>().type == 3){
                            // food must be chopped
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "Meat")
                            { 
                                ScoreController.scoreBoard.AddScore();
                                player.GetComponent<Player>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }
                            
                                //to do sound
                        }
                        else if (menu.GetComponent<MenuController>().type == 4){
                            // food must be chopped
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "Mushroom")
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
                        PlayerDropOff();
                }
            }
        } 

        // throw if H pressed and both equipped
        if (player.GetComponent<Player>().isEquipped && isEquipped && Input.GetKeyDown(KeyCode.H))
                    PlayerThrowOut(); 
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

    private void UpdateArrowPlayer() {
        // check if player is in range and "K" is pressed and table is selected
        Vector3 distanceToPlayer = arrowPlayer.transform.position - transform.position;
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(!isEquipped && !arrowPlayer.GetComponent<ArrowPlayer>().isEquipped && distanceToPlayer.magnitude <= pickUpRange){
                // if object on ground, pick it up
                if (table == null)
                    ArrowPlayerPickUp();
                //if object on table, only pick up object on the selected table
                else if (transform.parent == table.transform){
                    if (table.GetComponent<Table>().isSelected){
                        ArrowPlayerPickUp();
                    }
                }
                // if object on ground, pick it up
                else
                    ArrowPlayerPickUp();
            }
            //Drop if equipped and "K" is pressed
            else if(arrowPlayer.GetComponent<ArrowPlayer>().isEquipped && isEquipped && transform.parent == arrowPlayer.transform){
                if(Input.GetKeyDown(KeyCode.K)) {
                    // serving food
                    if(servingWindow.GetComponent<ServingWindowController>().isSelected) {
                        //menu match 1. hotpot 2. food
                        if(menu.GetComponent<MenuController>().type == 1){
                            // pot must be heated
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "SpicyHotpot")
                            {
                                ScoreController.scoreBoard.AddScore();
                                arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }   
                                //to do sound
                        }
                        else if(menu.GetComponent<MenuController>().type == 2){
                            // pot must be chopped
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "MildHotpot")
                            {
                                ScoreController.scoreBoard.AddScore();
                                arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }   
                                //to do sound
                        }
                        else if(menu.GetComponent<MenuController>().type == 3){
                            // pot must be chopped
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "Meat")
                            {
                                ScoreController.scoreBoard.AddScore();
                                arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }   
                                //to do sound
                        }
                        else if(menu.GetComponent<MenuController>().type == 4){
                            // pot must be chopped
                            if (progressBar.GetComponent<Slider>().value == 1 && gameObject.tag == "Mushroom")
                            {
                                ScoreController.scoreBoard.AddScore();
                                arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = false;
                                Destroy(gameObject);

                                //refresh menu
                                menu.GetComponent<MenuController>().UpdateMenu();
                            }   
                                //to do sound
                        }
                    }
                    else
                        ArrowPlayerDropOff();
                }
            }
        } 

        // throw if L pressed and both equipped
        if (arrowPlayer.GetComponent<ArrowPlayer>().isEquipped && isEquipped && Input.GetKeyDown(KeyCode.L))
                    ArrowPlayerThrowOut(); 
        else if(!arrowPlayer.GetComponent<ArrowPlayer>().isEquipped && !isEquipped && Input.GetKeyDown(KeyCode.L)){
            if (table != null){
                if (transform.parent == table.transform){
                    //if L pressed and food on selected chopping table
                    if (table.GetComponent<Table>().isSelected && table.GetComponent<Table>().type == 4){
                        ChoppingFood();
                    }
                }
            }
           
        }
    }


    private void PlayerPickUp() {
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

    private void ArrowPlayerPickUp() {
        isEquipped = true;
        rb.isKinematic = true;
        coll.isTrigger = true;

        if (table != null)
        {
            table.GetComponent<Table>().isEmpty = true;
        }
        arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = true;
        transform.SetParent(arrowPlayer.transform);
        transform.localPosition = new Vector3(0.0f, 3.0f, 3.0f);
    }

    private void PlayerDropOff() {

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
                transform.localRotation = Quaternion.LookRotation(new Vector3(0.0f, 0.0f, 1.0f));
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

    private void ArrowPlayerDropOff() {

        //if one table is selected, put object on table
        if (tableList.GetComponent<TableController>().arrowPlayerSelectedTable != null)
        {
            table = tableList.GetComponent<TableController>().arrowPlayerSelectedTable;
            if (table.GetComponent<Table>().isEmpty)
            {
                isEquipped = false;
                rb.isKinematic = false;
                coll.isTrigger = false;
                arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = false;

                table.GetComponent<Table>().isEmpty = false;
                transform.SetParent(table.transform);
                transform.localRotation = Quaternion.LookRotation(new Vector3(0.0f, 0.0f, 1.0f));
                transform.localPosition = new Vector3(0.0f, 0.75f, 0.0f);
            }
        }
        // drop object on ground
        else
        {
            isEquipped = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = false;
            
            transform.SetParent(null);
            rb.velocity = arrowPlayer.GetComponent<Rigidbody>().velocity;
            rb.AddForce(arrowPlayer.transform.forward * dropForwardForce, ForceMode.Impulse);
        }
    }

    private void PlayerThrowOut() {
        isEquipped = false;
        rb.isKinematic = false;
        coll.isTrigger = false;

        player.GetComponent<Player>().isEquipped = false;

        transform.SetParent(null);
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(player.transform.forward * throwForwardForce, ForceMode.Impulse);
    }

    private void ArrowPlayerThrowOut() {
        isEquipped = false;
        rb.isKinematic = false;
        coll.isTrigger = false;

        arrowPlayer.GetComponent<ArrowPlayer>().isEquipped = false;

        transform.SetParent(null);
        rb.velocity = arrowPlayer.GetComponent<Rigidbody>().velocity;
        rb.AddForce(arrowPlayer.transform.forward * throwForwardForce, ForceMode.Impulse);
    }

    private void ChoppingFood() {
        if (progressBar.GetComponent<Slider>().value == 1){
            //to do change status
            //statusBar.SetActive(false);
            return;
        }
        progressBar.GetComponent<Slider>().value += 0.1f;
        statusBar.SetActive(true);
    }
}
