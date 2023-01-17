using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;

    private Rigidbody2D myBody; //RigidBody2D component for later use
    private Animator anim; //animator component for later use

    private float directionVector; //set later to Input.GetAxisRaw("Horizontal"), which basically sets it to 1 when D(d) or Rigth Arrow is pressed and to -1 when A(a) or Left arrow is pressed; used to change direction on different button presses
    private float Displacement; //arbitrary value of 1 for now, may be removed/replaced later
    private bool Animation; //boolean value of animation condition, used later
    private bool Rext = true; //Default Right arm position set to be extended
    private bool Lext = true; //Default Left arm position set to be extended

    //assigning component variables to their respected components
    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    //function to animate left arm, uses Extended as the boolean animation condition
    void LarmAnimate(string Extended) {
        //Left and Right arms are extended by default
        if (Lext == true && Rext == true) {
            //setting up animation condition to contract left arm
            anim.SetBool(Extended, false);
            //setting up new state of left arm
            Lext = false;
        //similarly set up animation conditions and new arm status for each possible scenario when left arm is moved
        } else if (Lext == false && Rext == true) {
            anim.SetBool(Extended, true);
            Lext = true;
        } else if (Lext == true && Rext == false) {
            anim.SetBool(Extended, false);
            Lext = false;
        } else if (Lext == false && Rext == false) {
            anim.SetBool(Extended, true);
            Lext = true;
        } else if (Lext == false && Rext == true) {
            anim.SetBool(Extended, true);
            Lext = true;
        }
        //run movement function with boolean conditions passed when an arm is conracted or extended
        SwimmerMove(Lext, Rext);
    }

     //function to animate right arm, uses Extended as the boolean animation condition
    void RarmAnimate(string Extended) {
        //Left and Right arms are extended by default
        if (Lext == true && Rext == true) {
            //setting up animation condition to contract right arm
            anim.SetBool(Extended, false);
            //setting up new position for right arm
            Rext = false;
        //similarly set up animation conditions and new arm status for each possible scenario when right arm is moved
        } else if (Lext == true && Rext == false) {
            anim.SetBool(Extended, true);
            Rext = true;
        } else if (Lext == false && Rext == true) {
            anim.SetBool(Extended, false);
            Rext = false;
        } else if (Lext == false && Rext == false) {
            anim.SetBool(Extended, true);
            Rext = true;
        } else if (Lext == true && Rext == false) {
            anim.SetBool(Extended, true);
            Rext = true;
        }
        //run movement function with boolean conditions passed when an arm is conracted or extended
        SwimmerMove(Lext, Rext);
    }

    //moves swimmer a certain Displacement on X axis based on the inserted booleans that show if Left or Right arms are extended
    void SwimmerMove(bool Lext, bool Rext) {
        //sets default state of both arm contracted to false
        bool bothContracted = false;
        //checks the status of left and right arm and moves the swimmer a certain Displacement on X axis
        if (Lext == false && Rext == true) {
            Displacement = 2.6469f;
        } 
        if (Lext == true && Rext == true) {
            Displacement = -2.6469f;
        }
        //note that when both Left and Right arm booleans are false - bothContracted value has to be set to true
        if (Lext == false && Rext == false) {
            Displacement = 1.4391f;
            bothContracted = true;
        //if Left and Right arm booleans are not false - bothContracted goes back to false
        } else {
            bothContracted = false;
        }
        if (Lext == true && Rext == false) {
            Displacement = 2.5609f;
        }
        //checks if both arms are contracted to prevent movement of the swimmer by moving only one arm while keeping the other one contracted
        /*Displacement here mitigates forward motion but allows backward motion with a very small displacement (-0.00086 on X axis).
        Mitigating both forward and backward motion will require knowledge of previous inputs which is too hard to predict and code.
        With current setup player doesn't progress forward with incorrect inputs which prevents unfair play. 
        Player yet can progress backwards, ever so slightly, but it doesn't serve any purpose and hence can be ignored.*/
        if (bothContracted == true) {
            Displacement = -2.5609f;
            bothContracted = false;
        }
        //Input.GetAxisRaw("Horizontal") returns 1 when D or Right Arrow is pressed and -1 when A or Left Arrow is pressed
        //directionVector is set to the opposite direction to move swimmer forward when movement sequence is started from left arm and backwards when it's started from right arm
        directionVector = Input.GetAxisRaw("Horizontal") * -1;
        //moves the swimmer on X axis a certain Displacement * direction and / by 100 to make movement smooth
        //Time.DeltaTime is not used as it returns different values and adds a random factor to the movements
        transform.position += new Vector3(Displacement, 0f, 0f) * directionVector / 100;
    }

    //run movement and animation functions based on key input;
    void PlayerInput() {
        //run move function and animate right arm on right arrow press
        if (Input.GetKeyDown(Right)) {    
            //animate right arm, passes RsphereExtended boolean animation condition (set in unity animator), is used as Extended keyword in the function
            RarmAnimate("RsphereExtended");
        //run move function and animate left arm on left arrow press
        } else if (Input.GetKeyDown(Left)) {
            //animate left arm, passes LsphereExtended boolean animation condition (set in unity animator), is used as Extended keyword in the function
            LarmAnimate("LsphereExtended");
        }
    }
}