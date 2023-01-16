using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;

    private Rigidbody2D myBody; //RigidBody2D component for later use
    private Animator anim; //animator component for later use

    private float movementX; //set later to Input.GetAxisRaw("Horizontal"), which basically sets it to 1 when D(d) or Rigth Arrow is pressed and to -1 when A(a) or Left arrow is pressed; used to change direction on different button presses
    private float Displacement; //arbitrary value of 1 for now, may be removed/replaced later
    private bool Animation; //boolean value of animation condition, used later
    private bool Rext = true; //Default Right Sphere position set to be extended
    private bool Lext = true; //Default Left Sphere position set to be extended

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

    //function to animate left sphere, uses Extended as the boolean animation condition
    void LsphereAnimate(string Extended) {
        //Left and Right spheres are extended by default
        if (Lext == true && Rext == true) {
            //setting up animation condition to contract left sphere
            anim.SetBool(Extended, false);
            //setting up new position for left sphere
            Lext = false;
            SwimmerMove(Lext, Rext);
        //similarly set up animation conditions and new sphere positions for each possible scenario when left sphere is moved
        } else if (Lext == false && Rext == true) {
            anim.SetBool(Extended, true);
            Lext = true;
            SwimmerMove(Lext, Rext);
        } else if (Lext == true && Rext == false) {
            anim.SetBool(Extended, false);
            Lext = false;
            SwimmerMove(Lext, Rext);
        } else if (Lext == false && Rext == false) {
            anim.SetBool(Extended, true);
            Lext = true;
            SwimmerMove(Lext, Rext);
        } else if (Lext == false && Rext == true) {
            anim.SetBool(Extended, true);
            Lext = true;
            SwimmerMove(Lext, Rext);
        }
    }

     //function to animate right sphere, uses Extended as the boolean animation condition
    void RsphereAnimate(string Extended) {
        //Left and Right spheres are extended by default
        if (Lext == true && Rext == true) {
            //setting up animation condition to contract right sphere
            anim.SetBool(Extended, false);
            //setting up new position for right sphere
            Rext = false;
            SwimmerMove(Lext, Rext);
            
        //similarly set up animation conditions and new sphere positions for each possible scenario when right sphere is moved
        } else if (Lext == true && Rext == false) {
            anim.SetBool(Extended, true);
            Rext = true;
            SwimmerMove(Lext, Rext);
        } else if (Lext == false && Rext == true) {
            anim.SetBool(Extended, false);
            Rext = false;
            SwimmerMove(Lext, Rext);
        } else if (Lext == false && Rext == false) {
            anim.SetBool(Extended, true);
            Rext = true;
            SwimmerMove(Lext, Rext);
        } else if (Lext == true && Rext == false) {
            anim.SetBool(Extended, true);
            Rext = true;
            SwimmerMove(Lext, Rext);
        }
    }

    void SwimmerMove(bool Lext, bool Rext) {
        if (Lext == false && Rext == true) {
            Displacement = 2.6469f;
        } 
        if (Lext == true && Rext == true) {
            Displacement = -2.6469f;
        }
        if (Lext == false && Rext == false) {
            Displacement = 1.4391f;
        }
        if (Lext == true && Rext == false) {
            Displacement = 2.5609f;
        } 
        movementX = Input.GetAxisRaw("Horizontal") * -1;
        transform.position += new Vector3(Displacement, 0f, 0f) * movementX / 100; //moves the swimmer
    }

    //run movement and animation functions based on key input;
    void PlayerInput() {
        //run move function and animate right sphere on right arrow press
        if (Input.GetKeyDown(Right)) {    
            //animate right sphere, passes RsphereExtended boolean animation condition, is used as Extended keyword in the function
            RsphereAnimate("RsphereExtended");
        //run move function and animate left sphere on left arrow press
        } else if (Input.GetKeyDown(Left)) {
            //animate left sphere, passes LsphereExtended boolean animation condition, is used as Extended keyword in the function
            LsphereAnimate("LsphereExtended");
        }
    }
}