using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hamsterScoreDeath : MonoBehaviour
{
    private SphereCollider playerCol;

    public TextMeshProUGUI gameOver, scoreText;

    public GameObject groundTilt;

    public float score;

    public AudioSource failSound;


    void Start()
    {
        playerCol = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hole")
        {
            gameOver.gameObject.SetActive(true);
            failSound.Play();
            groundTilt.GetComponent<ArdTilt>().enabled = false;
        }

        if (other.gameObject.tag == "Carrot")
        {
            score += 1;
            other.gameObject.SetActive(false);
        }
    }
}
