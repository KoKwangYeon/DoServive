using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDownFloorScript : MonoBehaviour
{
    GameObject obj;
    private int count_point = 0;
    GameObject character;
    GameObject cha;
    // Start is called before the first frame update
    void Start()
    {
        count_point = 0;
        this.transform.position += new Vector3(Random.Range(-5,5),0,0);
        character = GameObject.Find("Character");

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0,-1,0)*Time.deltaTime;
        if(this.transform.position.y <= (float)-5){
            Destroy(gameObject);
        }
        if(count_point == 0){
            if(character.transform.position.y > this.transform.position.y){
                print("point++");
                count_point = 1;
                CharacterScript cc = GameObject.Find("Character").GetComponent<CharacterScript>();
                cc.point++;
            }
        }
        
    }

}
