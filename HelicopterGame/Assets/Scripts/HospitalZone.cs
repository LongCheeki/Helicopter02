using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.Instance != null && !GameManager.Instance.isGameOver)
        {
            if (GameManager.Instance.soldiersInHelicopter > 0)
            {
                GameManager.Instance.UnloadAtHospital();
                Debug.Log("Unloaded at hospital. Rescued: " + GameManager.Instance.soldiersRescued);
            }
        }
    }
}