using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject star;
    public Vector3 spawnValues;
    private int hazardCount;
    private float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text victoryText;

    //Ici
    public string level2load;

    private bool gameOver;
    private bool restart;
    private int score;
    private int wave;
    private bool victory;

    private int waves;
    private int maxScore;
    private int waveUpdate;
    Scene m_Scene;

    //Ici
    public Texture2D fadeTexture;
    private float alpha = 1;
    bool tr = false;


    void Start()
    {
        gameOver = false;
        restart = false;
        victory = false;
        restartText.text = "";
        gameOverText.text = "";
        victoryText.text = "";
        scoreText.text = "";
        score = 0;
        waves = 0;
        wave = 0;
        waveUpdate = 0;
        maxScore = 1000;
        hazardCount = 10;
        spawnWait = 0.5f;

        m_Scene = SceneManager.GetActiveScene();

        if (m_Scene.name == "niv5")
        {
            SpawnBoss();
        }
        else if(m_Scene.name == "explicationMonde")
        {
            StartCoroutine(Prez());
        }
        else if(m_Scene.name == "planet1toespace")
        {
            StartCoroutine(LaserPerdu());
        }
        else if (m_Scene.name == "planet2toespace")
        {
            StartCoroutine(MitrailleusePerdu());
        }
        else if (m_Scene.name == "planet3toespace")
        {
            StartCoroutine(GrenadePerdu());
        }
        else if (m_Scene.name == "planet4toespace")
        {
            StartCoroutine(LanceFlammePerdu());
        }
        else
        {
            StartCoroutine(SpawnWaves());
            //SpawnSpecialWave1();
            //SpawnSpecialWave2();
            //SpawnSpecialWave3();
        }
    }

    void Update()
    {
        //Ici
        if (tr)
        {
            alpha += 0.07F;
        }
        else
        {
            if (alpha > 0)
                alpha -= 0.07F;
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }

        if (gameOver)
        {
            restartText.text = "Press 'R' for Restart";
            restart = true;
        }
    }

    void SpawnBoss()
    {
        GameObject Boss = hazards[0];

        Vector3 spawnPosition = new Vector3(0, spawnValues.y, 12);

        Vector3 rotationVector = new Vector3(90, 180, 0);

        Quaternion spawnRotation = Quaternion.Euler(rotationVector);

        Instantiate(Boss, spawnPosition, spawnRotation);
    }

    void SpawnSpecialWave1()
    {
        GameObject hazard = hazards[0];
        for (float i = -spawnValues.x; i < spawnValues.x + 1; i = i+2)
        {
            Vector3 spawnPosition = new Vector3(i, spawnValues.y, spawnValues.z);

            Vector3 rotationVector = new Vector3(90, 0, 0);

            Quaternion spawnRotation = Quaternion.Euler(rotationVector);

            Instantiate(hazard, spawnPosition, spawnRotation);
        }
    }

    void SpawnSpecialWave2()
    {
        GameObject hazard = hazards[0];

        Vector3 rotationVector = new Vector3(90, 0, 0);

        Quaternion spawnRotation = Quaternion.Euler(rotationVector);

        for (float a = 0; a < spawnValues.x + 1; a = a + 2)
        {
            Vector3 spawnPosition2 = new Vector3(0 + a, spawnValues.y, spawnValues.z + a);
            Vector3 spawnPosition3 = new Vector3(0 - a, spawnValues.y, spawnValues.z + a);

            Instantiate(hazard, spawnPosition2, spawnRotation);
            Instantiate(hazard, spawnPosition3, spawnRotation);
        }
    }

    void SpawnSpecialWave3()
    {
        GameObject hazard = hazards[0];

        Vector3 rotationVector = new Vector3(90, 0, 0);

        Quaternion spawnRotation = Quaternion.Euler(rotationVector);

        for (float a = 0; a < (spawnValues.x / 2) + 1; a = a + 2)
        {
            Vector3 spawnPosition2 = new Vector3(0 + a, spawnValues.y, spawnValues.z + a);
            Vector3 spawnPosition3 = new Vector3(0 - a, spawnValues.y, spawnValues.z + a);

            Instantiate(hazard, spawnPosition2, spawnRotation);
            Instantiate(hazard, spawnPosition3, spawnRotation);
        }
        for (float a = (spawnValues.x / 2) + 1; a > 0; a--)
        {
            Vector3 spawnPosition2 = new Vector3(a, spawnValues.y, spawnValues.z - a);
            Vector3 spawnPosition3 = new Vector3(-a, spawnValues.y, spawnValues.z - a);

            Instantiate(hazard, spawnPosition2, spawnRotation);
            Instantiate(hazard, spawnPosition3, spawnRotation);
        }
    }

    IEnumerator LaserPerdu()
    {
        level2load = "niv2";

        yield return new WaitForSeconds(2);

        victoryText.text = "Vous venez de perdre votre laser";

        yield return new WaitForSeconds(2);

        victoryText.text = "En échange votre vaisseau peut tirer des lasers";

        yield return new WaitForSeconds(3);

        StartCoroutine(transition());
    }

    IEnumerator MitrailleusePerdu()
    {
        level2load = "niv3";

        yield return new WaitForSeconds(2);

        victoryText.text = "Vous venez de perdre votre mitrailleuse";

        yield return new WaitForSeconds(2);

        victoryText.text = "En échange votre vaisseau peut tirer plus de lasers";

        yield return new WaitForSeconds(3);

        StartCoroutine(transition());
    }

    IEnumerator GrenadePerdu()
    {
        level2load = "niv4";

        yield return new WaitForSeconds(2);

        victoryText.text = "Vous venez de perdre votre lance grenade";

        yield return new WaitForSeconds(2);

        victoryText.text = "En échange votre vaisseau peut tirer plus de lasers";

        yield return new WaitForSeconds(3);

        StartCoroutine(transition());
    }

    IEnumerator LanceFlammePerdu()
    {
        level2load = "niv5";

        yield return new WaitForSeconds(2);

        victoryText.text = "Vous venez de perdre votre lance-flamme";

        yield return new WaitForSeconds(2);

        victoryText.text = "En échange votre vaisseau peut tirer plus de lasers";

        yield return new WaitForSeconds(3);

        StartCoroutine(transition());
    }

    IEnumerator Prez()
    {
        yield return new WaitForSeconds(2);

        victoryText.text = "Vous êtes un pilote perdu dans l'espace";

        yield return new WaitForSeconds(3);

        victoryText.text = "Votre vaisseau est endommagé";

        yield return new WaitForSeconds(3);

        victoryText.text = "Vous devez rejoindre la planète la plus prohe";

        yield return new WaitForSeconds(3);

        victoryText.text = "Pour réparer votre vaisseau et explorer d'autres";

        yield return new WaitForSeconds(3);

        victoryText.text = "Planètes pour pouvoir rentrer chez vous";

        yield return new WaitForSeconds(3);

        StartCoroutine(transition());


    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            m_Scene = SceneManager.GetActiveScene();
            if (m_Scene.name == "niv1")
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    int rng2 = Random.Range(0, 20);

                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                    Vector3 rotationVector = new Vector3(90, 180, 0);

                    Quaternion spawnRotation = Quaternion.Euler(rotationVector);

                    Instantiate(hazard, spawnPosition, spawnRotation);

                    if (gameOver)
                    {
                        restartText.text = "Press 'R' for Restart";
                        restart = true;
                        break;
                    }

                    if (victory)
                    {
                        break;
                    }

                    yield return new WaitForSeconds(spawnWait);
                }
            }
            else
            {
                for (int i = 0; i < hazardCount; i++)
                {

                    int rng = Random.Range(0, 10);
                    if (rng == 1)
                    {
                        SpawnSpecialWave1();
                    }
                    else if (rng == 3)
                    {
                        SpawnSpecialWave2();
                    }
                    else if (rng == 6)
                    {
                        SpawnSpecialWave3();
                    }
                    else
                    {
                        int rng2 = Random.Range(0, 20);

                        if (rng2 == 3)
                        {
                            Vector3 spawnPosition1 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                            Vector3 rotationVector1 = new Vector3(90, 180, 0);

                            Quaternion spawnRotation1 = Quaternion.Euler(rotationVector1);

                            Instantiate(star, spawnPosition1, spawnRotation1);
                        }

                        GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                        Vector3 rotationVector = new Vector3(90, 180, 0);

                        Quaternion spawnRotation = Quaternion.Euler(rotationVector);

                        Instantiate(hazard, spawnPosition, spawnRotation);
                    }

                    if (gameOver)
                    {
                        restartText.text = "Press 'R' for Restart";
                        restart = true;
                        break;
                    }

                    if (victory)
                    {
                        break;
                    }

                    yield return new WaitForSeconds(spawnWait);
                }
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }

            if (victory)
            {
                break;
            }

            waves = waves + 1;
            if (waves > waveUpdate)
            {
                waves = 0;
                hazardCount = hazardCount + 3;
            }
            UpdateWave();
        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void Victory()
    {
        victoryText.text = "Victory !!!";
        victory = true;
        //Ici
        StartCoroutine(transition());

    }
    //Ici
    IEnumerator transition()
    {
        yield return new WaitForSeconds(2);
        tr = true;
        StartCoroutine(loadLevel());

    }
    //Ici
    IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level2load);

    }


    public void UpdateWave()
    {
        wave = wave + 1;

        UpdateScoreWave();

        if (wave == 5)
        {
            Victory();
        }
    }

    void UpdateScoreWave()
    {
        scoreText.text = "Wave: " + wave;
    }

    //Ici
    void OnGUI()
    {
        GUI.color = new Color(1, 1, 1, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}