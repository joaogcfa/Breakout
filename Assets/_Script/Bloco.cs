using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public int durabilidade;
    public int probOfLaunch;
    public GameObject PowerUp;
    private Vector3 position;
    public Sprite[] sprites;
    public AudioSource contato;


    GameManager gm;



    // Color White = new Color(255, 255, 255, 1);
    // Color Green = new Color(0, 255, 0, 1);
    // Color Blue = new Color(0, 0, 255, 1);
    // Color Yellow = new Color(255, 255, 0, 1);
    // Color Red = new Color(255, 0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        durabilidade = Random.Range(1, 6);
        probOfLaunch = Random.Range(1, 10);
        position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        gm = GameManager.GetInstance();
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        durabilidade--;
        if (durabilidade == 0)
        {
            gm.toca = true;
            Destroy(gameObject);
            if (probOfLaunch == 1)
            {
                Instantiate(PowerUp, position, Quaternion.identity);
            }
        }
        else
        {
            contato.Play();
        }
    }
    private void ChangeSprite()
    {
        if (durabilidade == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        if (durabilidade == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        if (durabilidade == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        if (durabilidade == 4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        if (durabilidade == 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
    }
}
