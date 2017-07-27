using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;
    //private Text scoreText;
    public int numLives;
    public Text liveText;
    public Text GameOver;  
  
    float respawnTimer;

    // Use this for initialization
    void Start()
    {
        
        SpawnPlayer();
        numLives = 4;
        setLivesText();
       //scoreText = GameObject.Find("PlayerScore").GetComponent<Text>();
       //scoreText.text = "0";
    }

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        setLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }

        if(playerInstance == null && numLives == 0)
        {
            setGameOverText();

            // Reload _Scene_0 to restart the game

            RestartLevel();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Enemy")
        {
            /*int score = int.Parse(scoreText.text);
            score += 100;
            scoreText.text = "Score" + score.ToString();

           if (score > ScoreCounter.score)
            {
                ScoreCounter.score = score;
            }*/
        }
    }

    void setLivesText()
    {
        liveText.text = "Lives: " + numLives.ToString();
    }
    void setGameOverText()
    {
        GameOver.text = "Game Over";
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Menu");
    }
    //void OnGUI()
    //{
    //    if (numLives > 0 || playerInstance != null)
    //    {
    //        GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
    //    }
    //    else
    //    {
    //        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over, Man!");

    //    }
    //}
}
