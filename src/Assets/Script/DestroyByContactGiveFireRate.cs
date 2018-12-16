using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContactGiveFireRate : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private PlayerController playerController;
    Scene m_Scene;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        m_Scene = SceneManager.GetActiveScene();

        if(m_Scene.name == "niv2")
        {
            GameObject playerControllerObject = GameObject.Find("spaceship_2");
            if (playerControllerObject != null)
            {
                playerController = playerControllerObject.GetComponent<PlayerController>();
            }
            if (playerController == null)
            {
                Debug.Log("Cannot find 'PlayerController' script");
            }
        }
        else if(m_Scene.name == "niv3")
        {
            GameObject playerControllerObject = GameObject.Find("spaceship_3");
            if (playerControllerObject != null)
            {
                playerController = playerControllerObject.GetComponent<PlayerController>();
            }
            if (playerController == null)
            {
                Debug.Log("Cannot find 'PlayerController' script");
            }
        }
        else if(m_Scene.name == "niv4")
        {
            GameObject playerControllerObject = GameObject.Find("spaceship_4");
            if (playerControllerObject != null)
            {
                playerController = playerControllerObject.GetComponent<PlayerController>();
            }
            if (playerController == null)
            {
                Debug.Log("Cannot find 'PlayerController' script");
            }
        }
        else if(m_Scene.name == "niv5")
        {
            GameObject playerControllerObject = GameObject.Find("spaceship_5");
            if (playerControllerObject != null)
            {
                playerController = playerControllerObject.GetComponent<PlayerController>();
            }
            if (playerController == null)
            {
                Debug.Log("Cannot find 'PlayerController' script");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //m_Scene = SceneManager.GetActiveScene();
        if (other.CompareTag("Player") && gameObject.CompareTag("Bonus"))
        {
            Destroy(gameObject);
            playerController.UpRate();
            return;
        }
    }
}
