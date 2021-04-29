using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    //1. hotpot 2. food
    public int type;
    public GameObject hotpotIcon;
    public GameObject spicyIcon;
    public GameObject meatIcon;
    public GameObject chopIcon;
    public string taste;
    public string food;
    // Start is called before the first frame update
    void Start()
    {
        type = 1;
        hotpotIcon.SetActive(true);
        spicyIcon.SetActive(true);
        meatIcon.SetActive(false);
        chopIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMenu() {
        if(type == 1){
            type = 2;
            hotpotIcon.SetActive(false);
            spicyIcon.SetActive(false);
            meatIcon.SetActive(true);
            chopIcon.SetActive(true);
        }
        else if (type == 2){
            type = 1;
            hotpotIcon.SetActive(true);
            spicyIcon.SetActive(true);
            meatIcon.SetActive(false);
            chopIcon.SetActive(false);
        }
    }
}
