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
    [SerializeField] AudioClip deadSound;
    [SerializeField] AudioClip pointSound;

    private AudioSource audioSource;
    
  
    private SpriteRenderer spriteRenderer;  // Referencia al SpriteRenderer del jugador.

    Rigidbody2D bird;

    int score = 0;
    bool dead = false;

    public ParticleSystem deathParticles;
    public GameObject gameOverScreen;  // Pantalla de Game Over (Canvas u otro GameObject).

    void Start()
    {
        bird = transform.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer.
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !dead)
        {
            bird.velocity = new Vector2(0, 6f);
            PlayJumpSound();
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;  // Asegúrate de reiniciar la escala de tiempo al normal.
        }
    }

    void OnCollisionEnter2D()
    {
        PlayDeadSound();

        dead = true;
        score = 0;
        scoreText.text = "0";

        // Desactivar el sprite para dar la impresión de muerte.
        spriteRenderer.enabled = false;

        // Reproducir las partículas de muerte.
        deathParticles.Play();

        // Iniciar la corrutina para ralentizar el juego después de que las partículas terminen.
        StartCoroutine(HandleDeathSequence());
    }

    IEnumerator HandleDeathSequence()
    {
        // Esperar hasta que las partículas terminen de reproducirse.
        yield return new WaitForSeconds(deathParticles.main.duration);

        // Ralentizar el juego.
        Time.timeScale = 0.1f;

        // Mostrar la pantalla de Game Over.
        gameOverScreen.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "pointTrigger")
        {
            score++;
            PlayCoindSound();
            scoreText.text = score.ToString();

        }
    }

    void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);  // Reproducir el sonido de salto.
    }

    void PlayDeadSound()
    {
        audioSource.PlayOneShot(deadSound);  // Reproducir el sonido de muerte.
    }

    void PlayCoindSound()
    {
        audioSource.PlayOneShot(pointSound);  // Reproducir el sonido de punto.
    }

}

