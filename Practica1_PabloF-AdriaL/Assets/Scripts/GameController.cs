﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static GameController m_GameController = null;
    public GameObject m_DestroyObjects;
    public FPSController m_Player;
    List<Enemy> m_Enemies;
    static bool m_AlreadyInitializated = false;

    static public GameController GetGameController()
    {
        if(m_GameController == null && !m_AlreadyInitializated)
        {
            GameObject l_GameObject = new GameObject("GameController");
            m_GameController = l_GameObject.AddComponent<GameController>();
            m_GameController.m_DestroyObjects = new GameObject("DestroyObjects");
            m_GameController.m_DestroyObjects.transform.SetParent(l_GameObject.transform);
            m_GameController.m_Enemies = new List<Enemy>();
            GameController.DontDestroyOnLoad(l_GameObject);
            m_AlreadyInitializated = true;
        }
        return m_GameController;
    }

    public void RestartLevel()
    {
        m_Player.RestartLevel();
        foreach(Enemy l_Enemy in m_Enemies)
        {
            l_Enemy.RestartLevel();
        }
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

    public void AddEnemy(Enemy _Enemy)
    {
        m_Enemies.Add(_Enemy);
    }

    public void RemoveEnemy(Enemy _Enemy)
    {
        m_Enemies.Remove(_Enemy);
    }
}