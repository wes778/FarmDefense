using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowPenStorage : MonoBehaviour
{
    public Queue<Food> animalFeed;
    public Queue<Water> animalWater;
    private WaterTrough wt;
    private FoodTrough ft;
    public Food foodToEat;
    public Water water;
    private VisualStorage vs;


    private void Awake()
    {
        wt = GetComponentInChildren<WaterTrough>();
        ft = GetComponentInChildren<FoodTrough>();
        vs = GetComponentInChildren<VisualStorage>();
        animalFeed = new Queue<Food>();
        animalWater = new Queue<Water>();
        for (int i = 0; i < 3; i++)
        {
            animalFeed.Enqueue(foodToEat);
            if(i != 0)
            {
               vs.AddToStorage(foodToEat.transform);
            }
          
            //AddToStorage();
            
        }
        for (int i = 0; i < 3; i++)
        {
            animalWater.Enqueue(water);
        }

    }
    public void AddToCowPenStorage()
    {

    }
    private void AddToStorage()
    {
        if(ft.GetCurrentFood() != null)
        {
            vs.AddToStorage(foodToEat.transform);
        }
    }

    //re do this when you have done the food trough and water trough
    public void RefillTrough()
    {

        if (animalWater.Count > 0 && wt.GetCurrentWater() == null)
        {
            Water curWaterToAdd = animalWater.Dequeue();
            wt.AddWaterToTrough(curWaterToAdd);
            wt.Instantiate();
        }
        else
        {
            Debug.Log("No water to add");
        }



        if (animalFeed.Count > 0 && ft.GetCurrentFood() == null)
        {
            Food curFoodToAdd = animalFeed.Dequeue();
            ft.AddFoodToTrough(curFoodToAdd);
            ft.Instantiate();
            vs.RemoveFromStorage();
        }
        else
        {
            Debug.Log("No food to add");
        }




    }


    private void Start()
    {

        RefillTrough();
    }



}
