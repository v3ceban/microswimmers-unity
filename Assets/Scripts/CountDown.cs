using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text countdownText; // Assign this in the Inspector to a Text component in your scene
    public GameObject Swimmer1;
    public GameObject Swimmer2;
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    
    IEnumerator CountdownToStart()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        
        countdownText.text = "START!";
        yield return new WaitForSeconds(1);
        
        countdownText.gameObject.SetActive(false); // Hide the countdown text after the start
        (Swimmer1.GetComponent("Swimmer") as MonoBehaviour).enabled = true;
        (Swimmer2.GetComponent("Swimmer") as MonoBehaviour).enabled = true;
    }
}