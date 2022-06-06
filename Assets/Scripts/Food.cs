using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int satietyPoints;
    private FoodTrough curTroughWhereThisFoodIs;
    private bool isEdiable = false;
    private void OnDestroy()
    {
        if(isEdiable)
        {
            curTroughWhereThisFoodIs.FoodEaten();
        }
        
    }
    public void CurrentTrough(FoodTrough ft)
    {
        curTroughWhereThisFoodIs = ft;
    }

    public bool GetIsEdiable()
    {
        return isEdiable;
    }

    public void SetIsEdiable(bool b)
    {
        isEdiable = b;
    }
}
