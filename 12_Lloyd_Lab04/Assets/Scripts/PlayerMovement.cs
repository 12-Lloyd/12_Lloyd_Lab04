using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody PlayerRigidbody;
    public int coin;
    public GameObject coinText;

    // Update is called once per frame
    void Update()
    {
        if (coin >= 4)
        {
            SceneManager.LoadScene("GamePlay_Level2");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coin++;
            coinText.GetComponent<Text>().text = "Score: " + coin;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);
    }
}
