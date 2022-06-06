using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFoodOrWater : MonoBehaviour
{
    private int radiusToLookForFood = 10;
    private int expandLookRadius = 1;


    public GameObject LocateFood()
    {
        GameObject foodLocation = null;
        Collider[] allObjects = Physics.OverlapSphere(this.transform.position, radiusToLookForFood * expandLookRadius);
        
        for(int i = 0; i < allObjects.Length; i++)
        {
            if(allObjects[i].CompareTag("Food") && allObjects[i].GetComponent<Food>().GetIsEdiable())
            {
                foodLocation = allObjects[i].gameObject;
                break;
            }
        }
        if(foodLocation == null)
        {
            expandLookRadius++;
        }
        else
        {
            expandLookRadius = 1;
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
