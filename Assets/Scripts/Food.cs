using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int satietyPoints;
    private FoodTrough curTroughWhereThisFoodIs;
    private void OnDestroy()
    {
        curTroughWhereThisFoodIs.FoodEaten();
        Debug.Log("ate");
    }
    public void CurrentTrough(FoodTrough ft)
    {
        curTroughWhereThisFoodIs = ft;
    }
}
