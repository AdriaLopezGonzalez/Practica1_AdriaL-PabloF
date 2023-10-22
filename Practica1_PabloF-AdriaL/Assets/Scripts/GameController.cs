using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static GameController m_GameController = null;
    public GameObject m_DestroyObjects;
    public FPSController m_Player;

    static public GameController GetGameController()
    {
        if(m_GameController == null)
        {
            GameObject l_GameObject = new GameObject("GameController");
            m_GameController = l_GameObject.AddComponent<GameController>();
            m_GameController.m_DestroyObjects = new GameObject("DestroyObjects");
            m_GameController.m_DestroyObjects.transform.SetParent(l_GameObject.transform);
            GameController.DontDestroyOnLoad(l_GameObject);
        }
        return m_GameController;
    }

    public void RestartLevel()
    {
        m_Player.RestartLevel();
        DestroyLevelObjects();
    }

    void DestroyLevelObjects()
    {
        m_Player.RestartLevel();
        Transform[] l_Transforms = m_DestroyObjects.GetComponentsInChildren<Transform>();
        foreach (Transform l_Transform in l_Transforms)
        {
            if (l_Transform != m_DestroyObjects.transform)
                GameObject.Destroy(l_Transform.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            RestartLevel();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GoToLevel1();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            GoToLevel2();
        if (Input.GetKeyDown(KeyCode.M))
            GoToMainMenu();
    }

    public void GoToLevel1()
    {
        DestroyLevelObjects();
        SceneManager.LoadSceneAsync("Level1_Scene");
    }

    public void GoToLevel2()
    {
        DestroyLevelObjects();
        SceneManager.LoadSceneAsync("Level2_Scene");
    }


    public void GoToMainMenu()
    {
        DestroyLevelObjects();
        GameObject.Destroy(m_Player.gameObject);
        SceneManager.LoadSceneAsync("MainMenuScene");
    }
}