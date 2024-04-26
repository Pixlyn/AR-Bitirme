using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item3DViewer : MonoBehaviour, IDragHandler {

    [SerializeField] private DummyInventory dummyInventory;

    private Transform itemPrefab;

    private void Start() {
        dummyInventory.OnItemSelected += DummyInventory_OnItemSelected; //Secilen objeyi al.
    }

    private void DummyInventory_OnItemSelected(object sender, ItemSO itemSO) {
        Debug.Log(itemSO.name);
        if (itemPrefab != null) {
            Destroy(itemPrefab.gameObject); // Olusan objeyi yok et.
        }
        itemPrefab = Instantiate(itemSO.prefab, new Vector3(-330, -0.1f, 1f), Quaternion.Euler(new Vector3(0, 90, 0))); // x/y konumunda olustur.
    }

    public void OnDrag(PointerEventData eventData) {
        itemPrefab.eulerAngles += new Vector3(-eventData.delta.y * (0.2f) , -eventData.delta.x) * (0.2f);  //Cevirme hizini %20 ye dusur.
    }

}