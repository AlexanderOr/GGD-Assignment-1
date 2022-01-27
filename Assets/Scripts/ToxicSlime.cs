using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ToxicSlime : MonoBehaviour
{
    private bool Stance;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public float restartDelay = .1f;
    private int maxLives = 3;
    private int lives = 3;
    public Text livesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Sword")
        {
            Destroy(collision.gameObject);
            spriteRenderer.sprite = newSprite;
            Stance = true;
        }

        if (collision.gameObject.tag == "Enemy" && Stance == true)
        {
            Destroy(collision.gameObject);
            Stance = false;
        }
        else if (Stance == false && collision.gameObject.tag == "Enemy")
        {
            lives = lives - 1;
            livesText.text = lives + " / " + maxLives;
            spriteRenderer.color = new Color(1, 0, 0, 1);

            Invoke("revertColor", 1f);

            loss();
            
        }

    }

    private void revertColor()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void RestartLevel() //Restarts the level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loss()
    {
        if (lives == 0)
        {
            SceneManager.LoadScene(0);
        }


    }
     

}
