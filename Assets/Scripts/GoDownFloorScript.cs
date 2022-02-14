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


        this.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<BoxCollider>().enabled = true;

        GameObject fl2 = this.transform.GetChild(0).gameObject;
        fl2.GetComponent<MeshRenderer>().enabled = true;
        fl2.GetComponent<BoxCollider>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        CharacterScript cc = GameObject.Find("Character").GetComponent<CharacterScript>();
        if(cc.end_check == 0){
            this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
            if (this.transform.position.y <= (float)-5)
            {
                Destroy(gameObject);
            }
            if (count_point == 0)
            {
                if (character.transform.position.y > this.transform.position.y)
                {
                    count_point = 1;
                    cc.point++;
                }
            }
        }
        else if(cc.end_check == 1){
            Destroy(gameObject);
        }
        
        
    }

}
