using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class Questionnaire : MonoBehaviour
{
    public TextMeshProUGUI creatureText;

    public TextMeshProUGUI locationText;

    public GameObject[] creatureToSpawn;
    public GameObject[] locationToSpawn;

    public List<string> creatureChosen = new List<string>();

    public List<string> locationChosen = new List<string>();

    public string answerScene = "Answer";


    private void Start()
    {
        
    }

    private void Update()
    {
        DontDestroyOnLoad(gameObject);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveAnswers();

            SwitchScene();

            SpawnAnswers();
        }
    }

    public void SaveAnswers()
    {
        creatureChosen.Add(creatureText.text);

        locationChosen.Add(locationText.text);

    }

    public void SwitchScene()
    {
        if (SceneManager.GetActiveScene().name == "Questionnaire")
        {
            SceneManager.LoadScene(answerScene);  
        }
    }

    public void SpawnAnswers()
    {
        if (SceneManager.GetActiveScene().name == answerScene)
        {
            if (creatureChosen.Contains("Shark"))
            {
                Instantiate(creatureToSpawn[0]);
            }
            else if (creatureChosen.Contains("Lion"))
            {
                Instantiate(creatureToSpawn[1]);
            }
            else if (creatureChosen.Contains("Military AI Robot"))
            {
                Instantiate(creatureToSpawn[2]);
            }

            if (locationChosen.Contains("500m Above Ground"))
            {
                Instantiate(locationToSpawn[0]);
            }
            else if (locationChosen.Contains("500m Below Ground"))
            {
                Instantiate(locationToSpawn[1]);
            }
            else if (locationChosen.Contains("Open Ocean"))
            {
                Instantiate(locationToSpawn[2]);
            }

        }
    }
}
