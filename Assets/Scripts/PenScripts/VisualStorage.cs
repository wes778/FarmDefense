using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualStorage : MonoBehaviour
{
    private bool hasItemInStorage = false;
    private Transform item;
    private int curItemCount;

    public enum StorageType
    {
        Food,
        Water,
    }

    public StorageType type = StorageType.Food;
    private void Awake()
    {
        
    }

    public void AddToStorage(Transform t)
    {
        curItemCount++;
        Instantiate(t, transform.position + new Vector3(0,curItemCount,0), transform.rotation);
       
    }

    public void RemoveFromStorage()
    {
        if(hasItemInStorage)
        {
            Destroy(item.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Food") || other.CompareTag("Water"))
        {
            hasItemInStorage = true;
            item = other.transform;
        }
    }

    public int GetCurrentItemCount()
    {
        return curItemCount;
    }

}
