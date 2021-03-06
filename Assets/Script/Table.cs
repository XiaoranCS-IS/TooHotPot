using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public bool isSelected;
    public bool isEmpty;
    //1. empty table 2.food table 3.pot table 4.chopping table 5.heat table
    public int type;
    public GameObject food;
    public GameObject player;
    public GameObject arrowPlayer;
    public GameObject tableList;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    private void Update() {
        // get food or pot from table
        
        if (type == 2 || type == 3)
        {
            if (isSelected && Input.GetKeyDown(KeyCode.G) && !player.GetComponent<Player>().isEquipped)
            {   
                Vector3 distanceToPlayer = player.transform.position - transform.position;
                if (distanceToPlayer.magnitude <= tableList.GetComponent<TableController>().selectedRange)
                {  
                    GameObject duplicate = Instantiate(food);
                    duplicate.GetComponent<ObjectController>().table = null;
                    duplicate.GetComponent<ObjectController>().pickupPlayer = 1;
                }
            }
        }

        if (type == 2 || type == 3)
        {
            if (isSelected && Input.GetKeyDown(KeyCode.K) && !arrowPlayer.GetComponent<ArrowPlayer>().isEquipped)
            {
                Vector3 distanceToPlayer = arrowPlayer.transform.position - transform.position;
                if (distanceToPlayer.magnitude <= tableList.GetComponent<TableController>().selectedRange)
                {  
                    GameObject duplicate = Instantiate(food);
                    duplicate.GetComponent<ObjectController>().table = null;
                    duplicate.GetComponent<ObjectController>().pickupPlayer = 2;
                }
            }
        }
    }
}
