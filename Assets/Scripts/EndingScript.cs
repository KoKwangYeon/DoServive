using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterScript cc = GameObject.Find("Character").GetComponent<CharacterScript>();
        GameObject scr = GameObject.Find("Score");
        scr.GetComponent<Text>().text = "Score : " +  (cc.point).ToString();

        GameObject floor = GameObject.Find("Floor(Clone)");
        Destroy(floor);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
