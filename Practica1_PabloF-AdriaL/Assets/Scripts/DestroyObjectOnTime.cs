using UnityEngine;
using System.Collections;

public class DestroyObjectOnTime : MonoBehaviour
{
    public float m_DestroyOnTime = 3.0f;

    private void Start()
    {
        StartCoroutine(DestroyObjectOnTimeCoroutine());
    }
    IEnumerator DestroyObjectOnTimeCoroutine()
    {
        yield return new WaitForSeconds(m_DestroyOnTime);
        GameObject.Destroy(gameObject);
    }
}
