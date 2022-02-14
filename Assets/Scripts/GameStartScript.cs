using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void startgame(){
        SceneManager.LoadScene("GameScene");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
