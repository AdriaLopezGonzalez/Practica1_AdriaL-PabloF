using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeners : MonoBehaviour
{
    public Animation m_DoorAnimation;
    public AnimationClip m_DoorOpeningAnimationClip;
    public AnimationClip m_DoorOpenAnimationClip;
    public AnimationClip m_DoorClosingAnimationClip;

    void OpenDoor()
    {
        m_DoorAnimation.CrossFade(m_DoorOpeningAnimationClip.name, 0.1f);
        m_DoorAnimation.CrossFadeQueued(m_DoorOpenAnimationClip.name, 0.1f);
    }

    void CloseDoor()
    {
        m_DoorAnimation.CrossFade(m_DoorClosingAnimationClip.name, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
           OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            CloseDoor();
    }
}
