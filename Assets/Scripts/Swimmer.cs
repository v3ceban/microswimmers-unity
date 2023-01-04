using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    private float movementX; //set later to Input.GetAxisRaw("Horizontal"), which basically sets it to 1 when D(d) or Rigth Arrow is pressed and to -1 when A(a) or Left arrow is pressed; used to change direction on different button presses, may be removed later
    private float Displacement = 1f; //arbitrary value of 1 for now
    private bool Animation; //boolean value of animation condition
    private bool Rext = true; //Default Right Sphere animation condition
    private bool Lext = true; //Default Left Sphere animation condition

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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

    void SwimmerMove(float x) {
        movementX = Input.GetAxisRaw("Horizontal");
        //transform.position += new Vector3(x, 0f, 0f) * movementX; //moves the swimmer
    }

    //function to animate left sphere
    void LsphereAnimate(string Extended) {
        //right sphere always extended, left sphere moves
        if (Lext == true && Rext == true) {
            anim.SetBool(Extended, false);
            Lext = false;
        } else if (Lext == false && Rext == true) {
            anim.SetBool(Extended, true);
            Lext = true;
        }
    }

     //function to animate right sphere
    void RsphereAnimate(string Extended) {
        print(Rext + " " + Lext);
    }

    //run movement and animation functions based on key input;
    void PlayerInput() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SwimmerMove(Displacement);
            RsphereAnimate("RsphereExtended");
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SwimmerMove(Displacement);
            LsphereAnimate("LsphereExtended");
        }
    }
}