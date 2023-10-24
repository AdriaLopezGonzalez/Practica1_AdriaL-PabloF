using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    public int m_HealthCount;

    public override bool CanPick()
    {
        return GameController.GetGameController().m_Player.CanPickHealth();
    }

    public override void Pick()
    {
        GameController.GetGameController().m_Player.AddHealth(m_HealthCount);
        base.Pick();
    }
}
