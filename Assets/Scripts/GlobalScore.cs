using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{
    public GameObject scoreDisplay01;
    public GameObject scoreDisplay02;
    public static int currentScore = 0;
    public int internalScore;

    // Update is called once per frame
    void Update()
    {
        internalScore = currentScore;
        scoreDisplay01.GetComponent<Text>().text = "" + internalScore;
        scoreDisplay02.GetComponent<Text>().text = "" + internalScore;
    }
}
