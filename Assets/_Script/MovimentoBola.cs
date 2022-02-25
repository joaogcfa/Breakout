using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour

{
    [Range(1, 15)]
    public float velocidade = 5.0f;
    // private int[1, 2, 3] cantos;

    private Vector3 direcao;
    private bool inicio = true;
    public AudioSource[] audios;
    GameManager gm;

    void Start()

    {
        gm = GameManager.GetInstance();
        inicio = true;
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;

    }
    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (gm.toca == true)
        {
            audios[0].Play();
            gm.toca = false;
        }

        if (inicio == true)
        {
            float inputX = Input.GetAxis("Horizontal");
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inicio = false;
            }
        }
        else
        {
            transform.position += direcao * Time.deltaTime * velocidade;
        }

        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        if (posicaoViewport.x < 0 || posicaoViewport.x > 1)
        {
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        if (posicaoViewport.y > 1)
        {
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        if (posicaoViewport.y < 0)
        {
            inicio = true;
            Reset();
        }
        // Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");

    }

    private void Reset()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.75f, 0);
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);
        direcao = new Vector3(dirX, dirY).normalized;
        gm.vidas--;
        if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // float dirX = Random.Range(-5.0f, 5.0f);
            // float dirY = Random.Range(1.0f, 5.0f);
            direcao = new Vector3(direcao.x, -direcao.y).normalized;
            audios[1].Play();
        }
        else if (col.gameObject.CompareTag("Tijolo"))
        {
            direcao = new Vector3(direcao.x, -direcao.y);
            gm.pontos++;
        }
    }
}
