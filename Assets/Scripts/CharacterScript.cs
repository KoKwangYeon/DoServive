    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    Animator animator;
    private Rigidbody rigid;
    GameObject ending;
    GameObject floor;

    static int camera_mode = 0;
    public int point;
    public float playTime;
    public CreateNewFloorScript createfloor;
    public GoDownFloorScript godown;
    int timecheck;
    public int end_check;
    // Start is called before the first frame update
    void Start()
    {
        end_check = 0;
        ending = GameObject.Find("EndingCanvas");
        ending.SetActive(false);
        floor = GameObject.Find("Floor");
        floor.SetActive(true);
        animator = GetComponent<Animator>();
        animator.SetBool("moving",false);
        rigid = GetComponent<Rigidbody>();
        createfloor = GetComponent<CreateNewFloorScript>();
        godown = GetComponent<GoDownFloorScript>();
        camera_mode = 0;

        timecheck = 1;
        point = 0;
        playTime = 0;

    }
    void game_end_check(){
        if(this.transform.position.y <= -5f && end_check == 0){
            floor.SetActive(false);
            ending.SetActive(true);
            ending.AddComponent<EndingScript>();
            GameObject point = GameObject.Find("PointCanvas");
            point.SetActive(false);
            end_check = 1;  
        }
    }
    void move_2d(){
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moving", true);
            this.transform.eulerAngles = new Vector3(0, 90, 0);
            if(animator.GetBool("running") == false){
                this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
            }
            else{
                this.transform.position += new Vector3(3,0,0) * Time.deltaTime;
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("moving", true);
            this.transform.eulerAngles = new Vector3(0, 270, 0);
            if(animator.GetBool("running") == false){
                this.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
            }
            else{
                this.transform.position += new Vector3(-3,0,0)*Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("moving", false);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("running",true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetBool("running",false);
        }
    }
    void jump_2d()
    {
        if(animator.GetBool("jumping") == false){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("jumping", true);
                animator.SetBool("midair", true);
                rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
            }
        }
    }
    void move_3d(){


        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("moving", true);
            this.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;;
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("moving", true);
            this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("moving", true);
            this.transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moving", true);
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
        playTime += Time.deltaTime;
        if(camera_mode == 0){
            move_2d();
            jump_2d();
        }
        else if(camera_mode == 1){
            move_3d();
            jump_2d();
        }         
        
        if(timecheck == Mathf.Round(playTime)){
            if(timecheck%5 == 0){
                print(timecheck % 5 + "  timecheck : " + timecheck + "  playTime : " + Mathf.Round(playTime) + "\n");
                createfloor = GameObject.Find("Floor").GetComponent<CreateNewFloorScript>();
                createfloor.time -= 0.1f;
                godown = GameObject.Find("Floor(Clone)").GetComponent<GoDownFloorScript>();
                godown.speed -= 0.05f;
                print("floor time : " + createfloor.time + "  godown speed : " + godown.speed + "\n");
            }
            timecheck+=1;    
        }

        game_end_check();
    }
    private void OnCollisionEnter(Collision other) {
        animator.SetBool("midair",false);
        animator.SetBool("jumping", false);
    }
}
