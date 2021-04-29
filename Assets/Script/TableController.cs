using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject[] table;
    public Transform player;

    public float selectedRange;
    public Color selectedColor;
    public Color unSelectedColor;
    public GameObject selectedTable;

    private float shortestDis;
    

    private void Start() {
        for (int i = 0; i < table.Length; i++)
            table[i].GetComponent<Renderer>().material.color = unSelectedColor;
    }

    // Update is called once per frame
    private void Update()
    {
        shortestDis = selectedRange;
        for (int i = 0; i < table.Length; i++)
        {
            // check if table is in range
            Vector3 distanceToPlayer = player.position - table[i].transform.position;
            if (distanceToPlayer.magnitude < shortestDis)
            {
                shortestDis = distanceToPlayer.magnitude;
                selectedTable = table[i];
            }

            LeaveTable(table[i].GetComponent<Renderer>());
        }

        if (selectedTable)
        {
            Vector3 distance = player.position - selectedTable.transform.position;
            if(distance.magnitude <= selectedRange)
                SelectTable(selectedTable.GetComponent<Renderer>());
            else
                selectedTable = null;
        }
    }

     private void SelectTable(Renderer tableR) {  
        tableR.material.color = selectedColor;
        tableR.GetComponent<Table>().isSelected = true;
    }

    private void LeaveTable(Renderer tableR) {
        tableR.material.color = unSelectedColor;
        tableR.GetComponent<Table>().isSelected = false;
    }
}
