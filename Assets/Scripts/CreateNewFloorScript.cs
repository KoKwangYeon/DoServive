using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewFloorScript : MonoBehaviour
{
    GameObject floor; 
    GameObject floor2;

    public float time = 4f;
    static float selectCountdown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.Find("Floor");
        //floor.SetActive(false);
        
        //floor.renderer.enabled = false;  
        floor.GetComponent<MeshRenderer>().enabled = false;
        floor.GetComponent<BoxCollider>().enabled = false;
        floor2 = transform.GetChild(0).gameObject;
        floor2.GetComponentInChildren<MeshRenderer>().enabled = false;
        floor2.GetComponentInChildren<BoxCollider>().enabled = false;

        selectCountdown = 0f;
    }

    void create_obj(){
        if(Mathf.Floor(selectCountdown) <= 0){
            //print("new!");
            GameObject floor_clone = Instantiate(floor, new Vector3(-3.38f, 8.02f, -5.31f), Quaternion.identity);
            floor_clone.SetActive(true);
            floor_clone.GetComponent<CreateNewFloorScript>().enabled = false;
            floor_clone.AddComponent<GoDownFloorScript>();
            

            selectCountdown = time;
        }
        else{
            //print("time : " + selectCountdown);
            selectCountdown -= Time.deltaTime;
        }

    }
    // Update is called once per frame
    void Update()
    {
        create_obj();
        
    }

}
