using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInventoryItem : MonoBehaviour
{
    public ItemSO[] characterPrefabs;//tüm karakterleri tutmak için dizi

    public DummyInventory dummyInventory;

    void Awake()
    {
        


        // int selectCharacterIndex = PlayerPrefs.GetInt("selectImageTarget");
        // Debug.Log(selectCharacterIndex);
        
        // ItemSO currentPrefab = characterPrefabs[selectCharacterIndex]; //diziden menude seçilen karakter indexine göre prefab seçm
        // dummyInventory.AddItemList(currentPrefab);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
