using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    //1. spicy hotpot 2. mild hotpot 3.meat 4.mushroom
    public int type;
    public GameObject hotpotIcon;
    public GameObject spicyIcon;
    public GameObject mildIcon;
    public GameObject chopIcon;
    public GameObject meatIcon;
    public GameObject mushroomIcon;
    public string food;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMenu() {
        //random menu
        type = Random.Range(1, 5);
        switch (type)
        {
            case 1:
                hotpotIcon.SetActive(true);
                spicyIcon.SetActive(true);
                mildIcon.SetActive(false);
                chopIcon.SetActive(false);
                meatIcon.SetActive(false);
                mushroomIcon.SetActive(false);
                break;
            case 2:
                hotpotIcon.SetActive(true);
                spicyIcon.SetActive(false);
                mildIcon.SetActive(true);
                chopIcon.SetActive(false);
                meatIcon.SetActive(false);
                mushroomIcon.SetActive(false);
                break;
            case 3:
                hotpotIcon.SetActive(false);
                spicyIcon.SetActive(false);
                mildIcon.SetActive(false);
                chopIcon.SetActive(true);
                meatIcon.SetActive(true);
                mushroomIcon.SetActive(false);
                break;
            case 4:
                hotpotIcon.SetActive(false);
                spicyIcon.SetActive(false);
                mildIcon.SetActive(false);
                chopIcon.SetActive(true);
                meatIcon.SetActive(false);
                mushroomIcon.SetActive(true);
                break;
            default:
                print("Error!!!");
                break;
        }
    }
}
