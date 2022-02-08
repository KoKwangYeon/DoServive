using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PrintPointScript : MonoBehaviour
{
    private Text myScore;
    private CharacterScript charac;
    // Start is called before the first frame update
    void Start()
    {
        myScore = GameObject.Find("Point_Space").GetComponent<Text>();
        charac = GameObject.Find("Character").GetComponent<CharacterScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        charac = GameObject.Find("Character").GetComponent<CharacterScript>();
        //print("change point_space");
        myScore.text = (charac.point).ToString();
    }
}
