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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfHumansAlive == 0 && levelOn != 4 && gameStarted == true)
        {
            
            Destroy(levelActive);
            levelActive = Instantiate(levels[levelOn], levels[levelOn].transform.position, levels[levelOn].transform.rotation);
            levelOn++;
            HumanCalculator();
        }
        if(GameObject.FindGameObjectsWithTag("Zombie").Length == 0 && gameStarted == true)
        {
            EndScreen();
        }
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
        deathScreen.gameObject.SetActive(true);
        stop.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }
}
