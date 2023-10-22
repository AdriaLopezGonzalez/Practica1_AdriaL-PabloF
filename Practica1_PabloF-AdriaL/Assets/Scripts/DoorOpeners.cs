using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeners : MonoBehaviour
{
    public Animation m_DoorAnimation;
    public AnimationClip m_DoorOpeningAnimationClip;

    void SetDoorOpeningAnimation()
    {
        m_DoorAnimation.CrossFade(m_DoorOpeningAnimationClip.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
           SetDoorOpeningAnimation();
    }
}
