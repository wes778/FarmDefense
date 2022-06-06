using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FindFoodOrWater))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class CowBrain : MonoBehaviour
{
    private FindFoodOrWater findFood;
    private Movement movement;

    private int hungerLevel = 1;
    private int thirstLevel = 1;

    private const float TickRateForFoodToDeplete = 10f;
    private float foodTimer = TickRateForFoodToDeplete;

    private const float TickRateForThirstToDeplete = 10f;
    private float thirstTimer = TickRateForThirstToDeplete;

    private GameObject currentFood;
    private GameObject currentWater;



    private void Awake()
    {
        findFood = GetComponent<FindFoodOrWater>();
        movement = GetComponent<Movement>();

    }
    public enum State
    {
        Hungry,
        Happy,
        Thirsty
    }

    public State state = State.Happy;


    private void Update()
    {

        if (state == State.Hungry)
        {

            if(currentFood == null)
            {
                currentFood = findFood.LocateFood();
                if(currentFood != null)
                {
                    movement.MoveToTarget(currentFood.transform);
                }
                
            }

            if (movement.HasReachedDestionation())
            {

                Destroy(currentFood);
                currentFood = null;
                hungerLevel += 1;
                CheckCurrentState();
            }

        }
        if (state == State.Thirsty)
        {
            if(currentWater == null)
            {
                currentWater = findFood.LocateWater();
                if (currentWater != null)
                {
                    movement.MoveToTarget(currentWater.transform);
                }
            }
            
            if (movement.HasReachedDestionation())
            {

                Destroy(currentWater);
                currentWater = null;
                thirstLevel += 1;
                CheckCurrentState();
            }


        }
        ReduceHungerAndThirst();
        if (state == State.Happy)
        {
            CheckCurrentState();
        }
    }

    private void ReduceHungerAndThirst()
    {
        foodTimer -= Time.deltaTime;
        thirstTimer -= Time.deltaTime;
        if (foodTimer <= 0)
        {
            foodTimer = TickRateForFoodToDeplete;
            hungerLevel -= 1;
        }
        else if (thirstTimer <= 0)
        {
            thirstTimer = TickRateForThirstToDeplete;
            thirstLevel -= 1;
        }
    }
    private void CheckCurrentState()
    {



        if (hungerLevel <= 0)
        {
            state = State.Hungry;
        }

        //this is thirst

        if (thirstLevel <= 0)
        {
            state = State.Thirsty;
        }

        else if (thirstLevel > 0 && hungerLevel > 0)
        {
            state = State.Happy;
            //Debug.Log("ello");
        }
    }


}
