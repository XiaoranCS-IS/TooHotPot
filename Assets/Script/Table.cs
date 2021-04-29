using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public bool isSelected;
    public bool isEmpty;
    //1. empty table 2.food table 3.pot table 4.chopping table
    public int type;
    public GameObject food;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    private void Update() {
        // get food from table
        if (isSelected && type == 2 && Input.GetKeyDown(KeyCode.G) && !player.GetComponent<Player>().isEquipped)
        {
            GameObject duplicate = Instantiate(food);
            duplicate.GetComponent<ObjectController>().table = null;
        }
    }
}
