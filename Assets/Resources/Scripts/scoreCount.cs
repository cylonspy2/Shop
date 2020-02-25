using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class scoreCount : MonoBehaviour
{
    [SerializeField]
    private Text score;

    private int startingScore = 0;
    private static int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = startingScore;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = currentScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentScore++;
    }
}
