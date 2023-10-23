using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public CanvasGroup m_CanvasGroup;
    public bool m_FadeOut = false;
    public float m_TimeToFade = 2.0f;

    void Update()
    {
        if (m_FadeOut)
        {
            if(m_CanvasGroup.alpha <= 1)
            {
                m_CanvasGroup.alpha += m_TimeToFade * Time.deltaTime;
                if(m_CanvasGroup.alpha >= 1)
                    m_FadeOut = false;
            }
        }
    }

    public void FadeingOut()
    {
        m_FadeOut = true;
    }
}
