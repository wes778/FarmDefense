using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public int satietyPoints;
    private WaterTrough curTroughWhereWaterAt;
    private void OnDestroy()
    {
        curTroughWhereWaterAt.WaterDrank();
    }
    public void CurrentTrough(WaterTrough ft)
    {
        curTroughWhereWaterAt = ft;
    }
}
