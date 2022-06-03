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


    private void Awake()
    {
        wt = GetComponentInChildren<WaterTrough>();
        ft = GetComponentInChildren<FoodTrough>();
        animalFeed = new Queue<Food>();
        animalWater = new Queue<Water>();
        for (int i = 0; i < 3; i++)
        {
            animalFeed.Enqueue(foodToEat);
        }
        Debug.Log(animalFeed.Count);
        //Debug.Log(animalFeed.Count);
        for (int i = 0; i < 3; i++)
        {
            animalWater.Enqueue(water);
        }

    }

    //re do this when you have done the food trough and water trough
    public void RefillTrough()
    {

        if (animalWater.Count > 0 && wt.GetCurrentWater() == null)
        {
            Debug.Log("water");
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
            Debug.Log("Yup");
            Food curFoodToAdd = animalFeed.Dequeue();
            ft.AddFoodToTrough(curFoodToAdd);
            ft.Instantiate();
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
