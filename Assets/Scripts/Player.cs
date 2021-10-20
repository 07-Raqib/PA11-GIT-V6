using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public int score = 0;
    public Text txt_score;

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        if(transform.position.y >=-4 && transform.position.y <= 4)
            transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);
        else if(transform.position.y > 4)
            transform.position = new Vector3(transform.position.x,4,transform.position.z);
        else if (transform.position.y < -4)
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        txt_score.text = "Score: "+ score;
    }
}
