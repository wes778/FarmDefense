using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrough : MonoBehaviour
{
    private Water currentWater;
    private float yOffset;
    private CowPenStorage cps;
    private void Awake()
    {
        cps = GetComponentInParent<CowPenStorage>();
    }
    public void AddWaterToTrough(Water water)
    {
        currentWater = water;
    }

    public Water GetCurrentWater()
    {
        return currentWater;
    }
    public void WaterDrank()
    {
        currentWater = null;
        cps.RefillTrough();
        
    }
    public void Instantiate()
    {
        if(currentWater != null)
        {
            yOffset = currentWater.transform.localScale.y * 3;
            yOffset += transform.localScale.y;
            Water cw = Instantiate(currentWater, this.transform.position + new Vector3(0, yOffset, 0), this.transform.rotation);
            cw.CurrentTrough(this);
        } 
        
    }
}
