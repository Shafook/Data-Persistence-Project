using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TextMeshProUGUI highscore;

    // Start is called before the first frame update
    void Start()
    {
        if(MenuManager.Instance != null)
        {
            highscore.text = "Best Score : " + MenuManager.Instance.highScorePlayer + ": " + MenuManager.Instance.points;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (nameInput != null && nameInput.text != "")
        {
            MenuManager.Instance.playerName = nameInput.text;
            SceneManager.LoadScene(1);
        }
    }
}
