using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DummyInventory : MonoBehaviour{

    public event EventHandler<ItemSO> OnItemSelected;

    [SerializeField] private List<ItemSO> itemList;

    [SerializeField] public bool[] isActive = new bool[30] {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false}; 
    [SerializeField] private GameObject On,Off,TxBg,tmp;
    private Transform itemTemplate;
    private Dictionary<ItemSO, Transform> itemSOTransformDic;
    
    
    private void Awake() {                                               // Sahne olusmadan aktiflesir...

        //GameObject tmp = GameObject.Find("BilgiTxt");
        TextMeshProUGUI mText = tmp.GetComponent<TextMeshProUGUI>();     // TextMeshPro Componentini mText'e Ata.
        //int index = PlayerPrefs.GetInt("selectImageTarget"+index);
        //isActive[index] = true;
        itemTemplate = transform.Find("InventoryItemTemplate");          //Sahnede bulunan ornek tasarima ulas.
        itemTemplate.gameObject.SetActive(false);                        //Onu devre disi birak.

        itemSOTransformDic = new Dictionary<ItemSO, Transform>();        //Scriptable objectleri al.
        int j=0;

        for(int i=0;i<itemList.Count;i++)
        {
            if(PlayerPrefs.HasKey("selectImageTarget"+i))
            {
                isActive[i] = true;                                      //Taratilmis obje varsa boolunu true yap.
            }
        }

        foreach (ItemSO itemSO in itemList) {                                //Itemlistte bulunan tum scriptable objectler icin ...
            
            Transform itemTransform = Instantiate(itemTemplate, transform);  //Ornek tasarimlari olustur.
            itemTransform.gameObject.SetActive(false);                       //Devre disi birak
            if(isActive[j] == true)                                          //Eger isActive boolu true ise
            {
                itemTransform.gameObject.SetActive(true);                    //Etkinlestir
            }
            
            itemTransform.Find("Image").GetComponent<Image>().sprite = itemSO.sprite; //Scriptable objectte bulunan gorseli ornek tasarimin gorseliyle degistir.
            
            itemTransform.Find("Selected").gameObject.SetActive(false);               //Secildiginde aktiflesen sprite'i devre disi birak.
            itemSOTransformDic[itemSO] = itemTransform;
            j++;
            itemTransform.GetComponent<Button>().onClick.AddListener(() => {          //Basildiginde sec ve mText.text'i scriptable objectte bulunan text ile degistir.
                SelectItem(itemSO);
                //Debug.Log("Selecting");
                mText.text = itemSO.text;
            });
        }
    }
    

    public void SelectItem(ItemSO selectedItemSO) {
        foreach (ItemSO itemSO in itemSOTransformDic.Keys) {
            itemSOTransformDic[itemSO].Find("Selected").gameObject.SetActive(false);
        }

        itemSOTransformDic[selectedItemSO].Find("Selected").gameObject.SetActive(true);
        

        OnItemSelected?.Invoke(this, selectedItemSO);
    } 

    public void DetailOn()
    {
        On.SetActive(false);
        Off.SetActive(true);
        TxBg.SetActive(true);
    }

    public void DetailOff()
    {

        On.SetActive(true);
        Off.SetActive(false);
        TxBg.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
