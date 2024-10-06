using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip jumpSound;
    private AudioSource audioSource;
    Rigidbody2D bird;

    int score = 0;

    bool dead = false;
    public ParticleSystem deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        bird = transform.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !dead){
            bird.velocity = new Vector2(0, 6f);
            PlayJumpSound();
        }
        if (Input.GetKeyDown("r")){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D()
    {
        dead = true;
        score = 0;
        scoreText.text = "0";

        // Reproducir el sistema de partículas.
        deathParticles.Play();

       


    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "pointTrigger")
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound); // Reproducir el sonido de salto
    }
}

