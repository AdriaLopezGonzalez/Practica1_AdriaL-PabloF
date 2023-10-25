using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public Animation m_DoorAnimation;
    public AnimationClip m_DoorOpeningAnimationClip;
    public AnimationClip m_DoorOpenAnimationClip;
    public GameObject m_Key;
    bool m_DoAnimation = true;

    void Update()
    {
        if(m_Key.activeSelf == false && m_DoAnimation)
        {
            OpenDoor();
            m_DoAnimation = false;
        }  
    }

    void OpenDoor()
    {
        m_DoorAnimation.CrossFade(m_DoorOpeningAnimationClip.name, 0.1f);
        m_DoorAnimation.CrossFadeQueued(m_DoorOpenAnimationClip.name, 0.1f);
    }
}
