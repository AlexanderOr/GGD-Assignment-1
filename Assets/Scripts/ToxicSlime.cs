using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToxicSlime : MonoBehaviour
{
    private bool Stance;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public float restartDelay = .1f;

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
        else if (Stance == false)
        {
            Invoke("RestartLevel", restartDelay);


        }
    }
    void RestartLevel() //Restarts the level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
