using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public string name;
    [SerializeField] private int baseValue;
    private int finalValue;

    private int permanentBuffedValue;
    private int temporaryBuffLifetime;
    private int temporaryBuffAmount;

    public int GetValue()
    {
        finalValue = baseValue + permanentBuffedValue + temporaryBuffAmount;
        return finalValue;
    }

    private void ApplyPermanentModifier(int modifier)
    {
        permanentBuffedValue += modifier;
    }

    private void ApplyTemporaryModifier(int modifier, int lifetime)
    {
        temporaryBuffAmount = modifier;

        temporaryBuffAmount = modifier;
        temporaryBuffLifetime = lifetime;
    }

    public void LifetimeDown()
    {
        if (temporaryBuffLifetime > 0)
        {
            temporaryBuffLifetime--;

            if (temporaryBuffLifetime == 0)
            {
                temporaryBuffAmount = 0;
            }
        }
    }

    public void Setup()
    {
        temporaryBuffAmount = 0;
        temporaryBuffLifetime = 0;
        permanentBuffedValue = 0;
    }

    public void ApplyBuff(Stat buff, int lifetime)
    {
        if (lifetime == 0)
        {
            ApplyPermanentModifier(buff.GetValue());
        }
        else
        {
            ApplyTemporaryModifier(buff.GetValue(), lifetime);
        }
    }
}
