using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : Item
{
    public int m_ArmorCount;

    public override bool CanPick()
    {
        return GameController.GetGameController().m_Player.CanPickArmor();
    }

    public override void Pick()
    {
        GameController.GetGameController().m_Player.AddArmor(m_ArmorCount);
        base.Pick();
    }
}
