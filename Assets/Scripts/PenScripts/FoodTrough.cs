using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrough : MonoBehaviour
{
    private Food currentFood = null;
    private float yOffset;
    private CowPenStorage cps;
    private void Awake()
    {
        cps = GetComponentInParent<CowPenStorage>();
    }

    public void AddFoodToTrough(Food food)
    {
        currentFood = food;
    }

    public Food GetCurrentFood()
    {
        return currentFood;
    }

    public void FoodEaten()
    {
        currentFood = null;
        cps.RefillTrough();
        
    }

    public void Instantiate()
    {
        if(currentFood != null)
        {
            yOffset = currentFood.transform.localScale.y * 3;
            yOffset += transform.localScale.y;
            Food cf = Instantiate(currentFood, this.transform.position + new Vector3(0, yOffset, 0), this.transform.rotation);
            cf.SetIsEdiable(true);
            cf.CurrentTrough(this);
            
        }
        
    }
}
