using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public float scoreAmount;

    public float increasePerSec;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        increasePerSec = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + (int)scoreAmount;
        scoreAmount += increasePerSec * Time.deltaTime;
    }
}
