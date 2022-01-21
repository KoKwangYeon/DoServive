using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    Animator animator;
    GameObject maincamera;
    GameObject plane;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        maincamera = GameObject.Find("MainCamera");
        plane = GameObject.Find("Plane");
        animator.SetBool("moving",false);
        rigid = GetComponent<Rigidbody>();

    }
    void move(){
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("moving", true);
            this.transform.eulerAngles = new Vector3(0, 90, 0);
            maincamera.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("moving", true);
            this.transform.eulerAngles = new Vector3(0, 270, 0);
            maincamera.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("moving", false);
        }
    }
    void jump()
    {
        if(animator.GetBool("jumping") == false){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("jumping", true);
                animator.SetBool("midair", true);
                rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        
    }
    private void OnCollisionEnter(Collision other) {
        animator.SetBool("midair",false);
        animator.SetBool("jumping", false);
    }
}
