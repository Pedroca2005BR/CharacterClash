using MyUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAim : MonoBehaviour
{
    public GameEvent OnShowTarget;
    public GameEvent OnAttackUsed;

    public int[] targetsId;

    private void OnMouseDown()
    {
        //gets all target aims deactivated
        OnShowTarget.Raise(this, null);
        //Lanca a posicao dos alvos pro battleStateManager
        OnAttackUsed.Raise(this, targetsId);
    }

    public void Activate(Component sender, object data)
    {
        if (data == null)
        {
            this.gameObject.SetActive(false);
        }
    }
}
