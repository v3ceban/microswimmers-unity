using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    /* Variables

    Main 5 vars
    float speed = 1.4f; //decimal number, needs "f" in the end
    double mana = 100.2; //decimal number with larger number of decimals
    int health = 100; //whole number integer
    string playerName = "Warrior228"; //string
    bool isDead = true; //boolean true/false

    Bonus
    char oneChar = 'a'; //one character string, uses ' instead of "
    */

    private void Start() {
        //calcAplusB();
        //calcTwoNums(30, 22);
        Debug.Log("The sum is " + ReturnTwoNumbers(1,2));
    }

    //function that doesn't return a value and doesn't use params
    void calcAplusB() {
        float a = 10;
        float b = 3;
        float c = a+b;
        Debug.Log("Printed from a function. The Sum of " + a + " and " + b + " is " + c);
    }

    //function that doesn't return a value but uses params
    void calcTwoNums(float a, float b) {
        Debug.Log("The sum of two numbers is: " + (a+b));
    }

    //function that returns a float and uses params
    float ReturnTwoNumbers(float a, float b) {
        return a+b;
    }
}
