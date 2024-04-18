using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerDoor : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject Player;
    public GameObject Health;
    public GameObject CoinManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            SceneManager.LoadSceneAsync(2);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
