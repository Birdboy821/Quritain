using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float numberOfHumans = 0;
    public GameObject[] humans;
    public float numberOfHumansAlive;
    public GameObject[] levels;
    private GameObject levelActive;
    private int levelOn = 0;
    public bool gameStarted = false;

    public GameObject back;
    public TextMeshProUGUI nameOfGame;
    public TextMeshProUGUI deathScreen;
    public Button start;
    public Button stop;
    public Button quit;
    public TextMeshProUGUI objectives;
    public TextMeshProUGUI victoryScreen;
    public Button playAgain;
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfHumansAlive == 0 && levelOn != 5 && gameStarted == true)
        {
            objectives.gameObject.SetActive(true);
            Destroy(levelActive);
            levelActive = Instantiate(levels[levelOn], levels[levelOn].transform.position, levels[levelOn].transform.rotation);
            levelOn++;
            HumanCalculator();
            objectives.text = "Number of Humans Alive: " + numberOfHumansAlive + " out of " + numberOfHumans;
        }
        if(GameObject.FindGameObjectsWithTag("Zombie").Length == 0 && gameStarted == true)
        {
            EndScreen();
        }
        if (numberOfHumansAlive == 0 && levelOn == 5 && gameStarted == true)
        {
            VictoryScreen();
        }
        objectives.text = "Number of Humans Alive: " + numberOfHumansAlive + " out of " + numberOfHumans;
    }

    private void HumanCalculator()
    {
        humans = GameObject.FindGameObjectsWithTag("Human");
        numberOfHumans = humans.Length;
        numberOfHumansAlive = numberOfHumans;
    }
    public void StartButton()
    {
        gameStarted = true;
        back.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        nameOfGame.gameObject.SetActive(false);
    }
    public void EndButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void EndScreen()
    {
        objectives.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(true);
        stop.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }
    private void VictoryScreen()
    {
        objectives.gameObject.SetActive(false);
        victoryScreen.gameObject.SetActive(true);
        playAgain.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }
}
