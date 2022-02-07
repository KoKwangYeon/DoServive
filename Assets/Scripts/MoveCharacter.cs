    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    Animator animator;
    GameObject maincamera;
    GameObject plane;
    GameObject floor; //test
    private Rigidbody rigid;

    public float time = 4f;
    public float selectCountdown;
    int camera_mode = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 4f;
        animator = GetComponent<Animator>();
        maincamera = GameObject.Find("MainCamera");
        animator.SetBool("moving",false);
        rigid = GetComponent<Rigidbody>();
        camera_mode = 0;
        selectCountdown = 0f;
        print("init selectcountdown : "+selectCountdown);
        //test
        floor = GameObject.Find("Floor");

        //GameObject floor_clone = Instantiate(floor, this.transform.position + new Vector3(0, -1, 0), Quaternion.identity);
        //floor_clone.AddComponent<FloorScript>();
        


    }
    void create_obj(){
        if(Mathf.Floor(selectCountdown) <= 0){
            print("new!");
            GameObject floor_clone = Instantiate(floor, new Vector3(-3.38f, 8.02f, -5.31f), Quaternion.identity);
            floor_clone.AddComponent<FloorScript>();
            selectCountdown = time;
        }
        else{
            print("time : " + selectCountdown);
            selectCountdown -= Time.deltaTime;
        }

    }
    void change_camera(){
        if(Input.GetKeyDown(KeyCode.P)){
            if(camera_mode == 0){
                if (this.transform.eulerAngles == new Vector3(0, 90, 0))
                {
                    maincamera.transform.position = this.transform.position + new Vector3(-4, 1, 0);
                    maincamera.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else if (this.transform.eulerAngles == new Vector3(0, 270, 0))
                {
                    maincamera.transform.position = this.transform.position + new Vector3(4, 1, 0);
                    maincamera.transform.eulerAngles = new Vector3(0, -90, 0);
                }
                camera_mode = 1;
            }
            else{
                maincamera.transform.position = this.transform.position + new Vector3(0,1,-4);
                maincamera.transform.eulerAngles = new Vector3(0,0,0);

                camera_mode = 0;
            }
        }
    }
    void move_2d(){
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moving", true);
            this.transform.eulerAngles = new Vector3(0, 90, 0);
            maincamera.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
            this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("moving", true);
            this.transform.eulerAngles = new Vector3(0, 270, 0);
            maincamera.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
            this.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("moving", false);
        }
    }
    void jump_2d()
    {
        if(animator.GetBool("jumping") == false){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("jumping", true);
                animator.SetBool("midair", true);
                rigid.AddForce(Vector3.up * 6, ForceMode.Impulse);
            }
        }
    }
    void move_3d(){


        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("moving", true);
            maincamera.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
            this.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;;
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("moving", true);
            maincamera.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
            this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("moving", true);
            maincamera.transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
            this.transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moving", true);
            maincamera.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
            this.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("moving", false);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("moving", false);
        }
    }
    void jump_3d(){

    }
    // Update is called once per frame
    void Update()
    {
        change_camera();
        if(camera_mode == 0){
            move_2d();
            jump_2d();
        }
        else if(camera_mode == 1){
            move_3d();
            jump_2d();
        }
        
        create_obj();

        
    }
    private void OnCollisionEnter(Collision other) {
        animator.SetBool("midair",false);
        animator.SetBool("jumping", false);
    }
}
