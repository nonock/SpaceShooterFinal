using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
    Scene m_Scene;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

    void OnTriggerEnter(Collider other)
    {
        //m_Scene = SceneManager.GetActiveScene();
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        else
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}