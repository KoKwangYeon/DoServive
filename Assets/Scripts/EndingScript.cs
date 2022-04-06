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

        GameObject time = GameObject.Find("Time");
        time.GetComponent<Text>().text = "Time : " + (Mathf.Floor(cc.playTime*10) * 0.1f).ToString();
        

        GameObject floor = GameObject.Find("Floor(Clone)");
        Destroy(floor);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
