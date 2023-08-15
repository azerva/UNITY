using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public Renderer background;
    public GameObject floor;
    public GameObject roof;
    //Obstaculos
    public GameObject piedra;
    public GameObject columna;
    public GameObject rana;
    public List<GameObject> obstaculos;
    //Pantallas 
    public GameObject menuInicio;
    public GameObject menuGameOver;
    public GameObject menuTime;

    public bool gameOver = false;
    public bool startGame = false;

    public AudioSource audioGameStart;

    public Chronometer chronometer;

    // Start is called before the first frame update
    void Start()
    {
        //Creando suelo para que el juegador no desaparezca
        for (int x = 0; x < 21; x++)
        {
            Instantiate(floor, new Vector2(-10 + x, -5), Quaternion.identity);
        }
        //Creando techo para que el jugador no salga de la pantalla
        for (int x = 0; x < 21; x++)
        {
            Instantiate(roof, new Vector2(-10 + x, 5.5f), Quaternion.identity);
        }

        //Creando obstaculos
        obstaculos.Add(Instantiate(piedra, new Vector2(2, -3.8f), Quaternion.identity));
        obstaculos.Add(Instantiate(rana, new Vector2(8, -3.59f), Quaternion.identity));
        obstaculos.Add(Instantiate(columna, new Vector2(14, -3.5f), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {

        if (startGame == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                startGame = true;
                //audioGameStart.Play();

            }
        }

        if (startGame == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            menuTime.SetActive(false);

            audioGameStart.Stop();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (startGame == true && gameOver == false)
        {
            menuInicio.SetActive(false);

            chronometer.timeStart();

            //Movimiento del background
            background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.08f, 0) * Time.deltaTime;

            //Moviendo obstaculos a la izquierda
            for (int x = 0; x < obstaculos.Count; x++)
            {
                if (obstaculos[x].transform.position.x <= -10)
                {
                    float objectX = Random.Range(8, 20);
                    obstaculos[x].transform.position = new Vector3(objectX, -3.7f, 0);
                }

                obstaculos[x].transform.position = obstaculos[x].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime;

            }

        }
    }
}
