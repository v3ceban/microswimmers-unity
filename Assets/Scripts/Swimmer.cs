using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    private float movementX;
    private float Displacement;
    private int Animation;
    private string PreviousKey;
    private string PreviousKey2;
    private string PreviousKey3;
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

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

    void PlayerMove(float x) {
        //movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x, 0f, 0f);
    }

    void SwimmerAnimate(int i) {
        anim.SetInteger("i", i);
    }

    void CheckKeyInputs(string Key) {
        if (Key == "Left Arrow" && PreviousKey == null && PreviousKey2 == null && PreviousKey3 == null) {
                PreviousKey = Key;
                PreviousKey2 = null;
                PreviousKey3 = null;
                Animation = 1;
                Displacement = -1.3531f;
            } else if (Key == "Left Arrow" && PreviousKey == "Left Arrow" && PreviousKey2 == null && PreviousKey3 == null) {
                PreviousKey = null;
                PreviousKey2 = null;
                PreviousKey3 = null;
                Animation = 0;
                Displacement = 1.3531f;
            } else if (Key == "Right Arrow" && PreviousKey == "Left Arrow" && PreviousKey2 == null && PreviousKey3 == null) {
                PreviousKey = Key;
                PreviousKey2 = "Left Arrow";
                PreviousKey3 = null;
                Animation = 2;
                Displacement = 1.4391f;
            } else if (Key == "Right Arrow" && PreviousKey == "Right Arrow" && PreviousKey2 == "Left Arrow" && PreviousKey3 == null) {
                PreviousKey = "Left Arrow";
                PreviousKey2 = null;
                PreviousKey3 = null;
                Animation = 1;
                Displacement = -1.4391f;
            } else if (Key == "Left Arrow" && PreviousKey == "Right Arrow" && PreviousKey2 == "Left Arrow" && PreviousKey3 == null) {
                PreviousKey = Key;
                PreviousKey2 = "Right Arrow";
                PreviousKey3 = "Left Arrow";
                Animation = 3;
                Displacement = 1.4391f;
            } else if (Key == "Left Arrow" && PreviousKey == "Left Arrow" && PreviousKey2 == "Right Arrow" && PreviousKey3 == "Left Arrow") {
                PreviousKey = "Right Arrow";
                PreviousKey2 = "Left Arrow";
                PreviousKey3 = null;
                Animation = 2;
                Displacement = -1.4391f;
            } else if (Key == "Right Arrow" && PreviousKey == "Left Arrow" && PreviousKey2 == "Right Arrow" && PreviousKey3 == "Left Arrow") {
                PreviousKey = Key;
                PreviousKey2 = "Left Arrow";
                PreviousKey3 = "Right Arrow";
                Animation = 4;
                Displacement = -1.3531f;
            } else if (Key == "Left Arrow" && PreviousKey == "Right Arrow" && PreviousKey2 == "Left Arrow" && PreviousKey3 == "Right Arrow") {
                PreviousKey = null;
                PreviousKey2 = null;
                PreviousKey3 = null;
                Animation = 0;
            }
    }

    void PlayerInput() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            CheckKeyInputs("Right Arrow");
            PlayerMove(Displacement);
            SwimmerAnimate(Animation);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            CheckKeyInputs("Left Arrow");
            PlayerMove(Displacement);
            SwimmerAnimate(Animation);
        }
    }
}

// else if (Key == "Right Arrow" && PreviousKey == null) {
//                 PreviousKey = Key;
//                 sr.flipX = true;
//                 Animation = 1;
//                 Displacement = 1.3531f;
//             } else if (Key == "Left Arrow" && PreviousKey == "Left Arrow") {
//                 PreviousKey = null;
//                 PreviousKey2 = null;
//                 Animation = 0;
//                 Displacement = 1.3531f;
//             } else if (Key == "Right Arrow" && PreviousKey == "Right Arrow") {
//                 PreviousKey = null;
//                 PreviousKey2 = null;
//                 sr.flipX = true;
//                 Animation = 0;
//                 Displacement = -1.3531f;
//              } 
// else if (Key == "Left Arrow" && PreviousKey == "Right Arrow" && PreviousKey2 == "Left Arrow") {
//                 PreviousKey = null;
//                 PreviousKey2 = null;
//                 Animation = 0;
//                 Displacement = 0;
//             }