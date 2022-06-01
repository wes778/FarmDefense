using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FindFood))]
[RequireComponent(typeof(Movement))]
public class CowBrain : MonoBehaviour
{
    private FindFood findFood;
    private Movement movement;

    private int hungerLevel = 1;
    private int thirstLevel = 1;

    private const float TickRateForFoodToDeplete = 4f;
    private float foodTimer = TickRateForFoodToDeplete;

    private const float TickRateForThirstToDeplete = 5f;
    private float thirstTimer = TickRateForThirstToDeplete;



    private void Awake()
    {
        findFood = GetComponent<FindFood>();
        movement = GetComponent<Movement>();

    }
    public enum State
    {
        Hungry,
        Happy,
        Thirsty
    }

    public State state = State.Happy;


    private void LateUpdate()
    {
        if (state == State.Hungry)
        {
            GameObject currentFood = findFood.LocateFood();
            if (currentFood != null && movement.MoveToTarget(currentFood.transform))
            {
                if(movement.HasReachedDestionation())
                {
                    Destroy(currentFood);
                    hungerLevel += 1;
                    CheckCurrentState();
                }
                
            }

            //find food
            //move to food
            //eat food
        }

        //countdown for food to lower
        



    }
    private void Update()
    {
        CheckCurrentState();
    }

    private void CheckCurrentState()
    {
        foodTimer -= Time.deltaTime;
        thirstTimer -= Time.deltaTime;

        if (foodTimer <= 0)
        {
            foodTimer = TickRateForFoodToDeplete;
            hungerLevel -= 1;
            if (hungerLevel <= 0)
            {
                state = State.Hungry;
            }
        }
        //this is thirst
        else if (thirstTimer <= 0)
        {
            thirstTimer = TickRateForThirstToDeplete;
            thirstLevel -= 1;
            if (thirstLevel <= 0)
            {
                state = State.Thirsty;
            }
        }
        else if( thirstLevel >0 && hungerLevel > 0)
        {
            state = State.Happy;
            //Debug.Log("ello");
        }
    }
}
