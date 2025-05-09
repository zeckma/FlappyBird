using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rb;
    public GameObject loseScreenUI;
    public int score;
    public int hiscore;
    public Text scoreUI;
    public Text highScoreUI;
    string HISCORE = "HISCORE";
    // Start is called before the first frame update
    
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Start()
    {
        hiscore = PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * jumpForce;

        }
    }
	void playerLose()
	{
        AudioManager.singleton.PlaySound(1);
        if(score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetInt(HISCORE, hiscore);
        }
        highScoreUI.text = "HiScore: " + hiscore.ToString();
        loseScreenUI.SetActive(true);
		Time.timeScale = 0;
	}

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("obstacle"))
		{
			playerLose();
		}
	}

    void AddScore()
    {
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("score"))
        {
            AddScore();
        }
	}
}
