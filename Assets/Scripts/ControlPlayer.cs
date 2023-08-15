using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class ControlPlayer : MonoBehaviour
{
    public float jumpForce = 50.0f;//fuerza de salto
    private Rigidbody2D playerRigidbody2D;

    public Chronometer chronometer;
    public GameManager gameManager;

    public AudioSource audioJump;
    public AudioSource audioGameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerRigidbody2D.AddForce(new Vector2(0, jumpForce));
            audioJump.Play();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
            audioGameOver.Play();

            chronometer.timeEnd();

        }
    }
}