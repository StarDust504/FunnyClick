using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Click : MonoBehaviour
{
    [SerializeField] private GameObject circle; //to get location of a circle
    [SerializeField] private GameObject btn;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    AudioSource audioSource;
    private int levelNum;
    private int score, targetScore;


    RotAround rotation;
    private Vector3 changeScale;
    


    void Awake()
    {
        rotation = circle.GetComponent<RotAround>();
        targetScore = 10;
        levelNum = 1;
        audioSource = GetComponent<AudioSource>();
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //spawn white circles
            rotation.Spawn();
            //move circles
            rotation.rotSpeed = 0;
            rotation.move_dir -= 0.05f;
            changeScale = new Vector3(-0.5f, -0.5f, -0.5f);
            //change scale of a button
            btn.transform.localScale += changeScale;
            //change score on click
            score += 1;
            ChangeScore();
            //change target score 
            if (score == targetScore)
            {
                targetScore += 10;
                levelNum++;
            }
            //play audio
            audioSource.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //change button scale back
            btn.transform.localScale -= changeScale;
            rotation.rotSpeed = 200;
            btn.transform.position = new Vector3(circle.transform.position.x, circle.transform.position.y, circle.transform.position.z);

        }
    }

    //function that changes score on click
    void ChangeScore()
    {
        scoreText.text = score.ToString() + " / " + targetScore.ToString();
        levelText.text = "Level " + levelNum.ToString();
    }

}
