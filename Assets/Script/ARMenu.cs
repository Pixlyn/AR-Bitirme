using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARMenu : MonoBehaviour
{
    //public DummyInventory dummyInventory;

    void Start()
    {
        //dummyInventory = DummyInventoryOBJ.GetComponent<DummyInventory>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
        
    // public void AddInventory(int index)
    // {    
    //     PlayerPrefs.SetInt("selectImageTarget",index); 
    //     dummyInventory.isActive[index]= true;
    // }

    public void AddInventory(int index)
    {    
        PlayerPrefs.SetInt("selectImageTarget"+index,index);
    }

    public void SendLibrary()
    {
        SceneManager.LoadScene("Library");
    }
    
}
