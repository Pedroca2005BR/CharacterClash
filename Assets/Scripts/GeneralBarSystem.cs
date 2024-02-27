using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBarSystem
{
    private int maxValue;
    private int currentValue;

    public GeneralBarSystem(int maxValue)
    {
        this.maxValue = maxValue;
        currentValue = maxValue;
    }

    public int GetCurrentValue()
    {
        return currentValue;
    }

    public void DecreaseValue(int value)
    {
        currentValue -= value;

        if (currentValue < 0)
        {
            currentValue = 0;
        }
    }

    public void IncreaseValue(int value)
    {
        currentValue += value;

        if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }
    }

    public bool CheckIfZero()
    {
        return currentValue == 0;
    }
}
