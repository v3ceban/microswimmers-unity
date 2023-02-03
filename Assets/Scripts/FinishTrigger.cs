using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinishTrigger : MonoBehaviour
{
    public Text finishText;
    public GameObject Swimmer1;
    public GameObject Swimmer2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Swimmer1") || other.gameObject.CompareTag("Swimmer2"))
        {
            Time.timeScale = 0; // Stop the game
            if (other.gameObject.CompareTag("Swimmer1"))
            {
                finishText.text = "Player 1 wins!"; // Declare Swimmer1 as the winner
            }
            else
            {
                finishText.text = "Player 2 wins!"; // Declare Swimmer2 as the winner
            }

            finishText.gameObject.SetActive(true);
            (Swimmer1.GetComponent("Swimmer") as MonoBehaviour).enabled = false;
            (Swimmer2.GetComponent("Swimmer") as MonoBehaviour).enabled = false;
        }
    }
}
