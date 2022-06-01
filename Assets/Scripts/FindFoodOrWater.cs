using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFoodOrWater : MonoBehaviour
{
    private int radiusToLookForFood = 10;


    public GameObject LocateFood()
    {
        GameObject foodLocation = null;
        Collider[] allObjects = Physics.OverlapSphere(this.transform.position, radiusToLookForFood);
        for(int i = 0; i < allObjects.Length; i++)
        {
            if(allObjects[i].CompareTag("Food"))
            {
                foodLocation = allObjects[i].gameObject;
                break;
            }
        }
        
        
        return foodLocation;
    }

    public GameObject LocateWater()
    {
        GameObject waterLocations = null;
        Collider[] allObjects = Physics.OverlapSphere(this.transform.position, radiusToLookForFood);
        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].CompareTag("Water"))
            {
                waterLocations = allObjects[i].gameObject;
                break;
            }
        }


        return waterLocations;
    }

    void OnDrawGizmosSelected()
        
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusToLookForFood);
    }
}
