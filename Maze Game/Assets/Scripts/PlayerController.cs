using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int time = 10;
    private Rigidbody2D rb;
    private Vector2 moveSpeed;

    public AudioSource backgroundMusic;
    public AudioSource winMusic;
    public AudioSource loseMusic;

    public Text winText;
    public Text loseText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winText.text = "";
        loseText.text = "";
        InvokeRepeating("Count", 0.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveSpeed = moveInput * speed;

        if(time == 0)
        {
            moveSpeed = moveInput * 0;
        }
        if (Input.GetKey("r")) 
        {
            Restart();
        }
    }
 
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive (false);
            backgroundMusic.Stop();
            winMusic.Play();
            winText.text = "You Win! Thanks For Playing! Press R to Play again.";
            CancelInvoke("Count");
        }
    }

    void Count()
    {
        if(time == 0)
        {
            loseText.text = "You lose... Press R to Try again.";
            backgroundMusic.Stop();
            loseMusic.Play();
            CancelInvoke("Count");
        }
        else
        {
            time--;
        }
    }

}
