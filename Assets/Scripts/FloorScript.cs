using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0,-1,0)*Time.deltaTime;
        if(this.transform.position.y <= (float)-5){
            Destroy(gameObject);
        }
    }

}
