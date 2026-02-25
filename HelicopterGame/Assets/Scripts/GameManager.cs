using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int soldiersInHelicopter = 0;
    public int soldiersRescued = 0;

    public int maxCapacity = 3;
    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public bool CanPickUp()
    {
        return !isGameOver && soldiersInHelicopter < maxCapacity;
    }

    public void PickUpSoldier()
    {
        soldiersInHelicopter++;
    }

    public void UnloadAtHospital()
    {
        soldiersRescued += soldiersInHelicopter;
        soldiersInHelicopter = 0;
    }
}