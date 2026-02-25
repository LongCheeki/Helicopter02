using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public int soldiersInHelicopter = 0;
    public int soldiersRescued = 0;
    public int maxCapacity = 3;
    public bool isGameOver = false;

    [Header("UI References")]
    public TMP_Text rescuedText;
    public TMP_Text inHeliText;
    public TMP_Text messageText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        if (messageText != null)
            messageText.text = "";

        RefreshUI();
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
        RefreshUI();
        CheckWinCondition();
    }


    public void UnloadAtHospital()
    {
        soldiersRescued += soldiersInHelicopter;
        soldiersInHelicopter = 0;

        RefreshUI();
        CheckWinCondition();
    }


    public void GameOver()
    {
        isGameOver = true;

        if (messageText != null)
            messageText.text = "Game Over";
    }

    public void CheckWinCondition()
    {
        if (isGameOver) return;

        int soldiersLeft = GameObject.FindGameObjectsWithTag("Soldier").Length;

        if (soldiersLeft == 0 && soldiersInHelicopter == 0)
        {
            isGameOver = true;

            if (messageText != null)
                messageText.text = "You Win";
        }
    }


    public void RefreshUI()
    {
        if (rescuedText != null)
            rescuedText.text = "Soldiers Rescued: " + soldiersRescued;

        if (inHeliText != null)
            inHeliText.text = "Soldiers In Helicopter: " + soldiersInHelicopter;
    }
}