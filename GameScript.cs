using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{
    private int numberToGuess;
    private bool wasFocused;
    private bool isAnswerShowed = false;
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] private TMP_Text attemptsUI;
    [SerializeField] private TMP_Text hintUI;
    [SerializeField] private Canvas loseCanvas;
    [SerializeField] private GameObject[] buttonsToDisable;

    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Slider loadingSlider;

    [Header("Game settings")]
    [SerializeField] private int attemptsLeft = 15;
    private int maxNumber;

    void Start()
    {
        winCanvas.enabled = false;
        loseCanvas.enabled = false;

        maxNumber = Random.Range(800, 5000);
        AttemtsBalancer();
        attemptsUI.text = attemptsLeft.ToString();
        numberToGuess = Random.Range(1, maxNumber);
        hintUI.text = "<" + maxNumber;
        Debug.Log(numberToGuess);
    }

    private void Update()
    {
        if (attemptsLeft < 1)
        {
            GameOver();
        }
        else
        {
            _inputField.ActivateInputField();
        }
        
        wasFocused = _inputField.isFocused;
        if (wasFocused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                CheckGuess();
            }
        }
    }

    void AttemtsBalancer()
    {
        if (maxNumber <= 1000)
        {
            attemptsLeft = 9;
        }
        else if (maxNumber > 1000 && maxNumber <= 3000)
        {
            attemptsLeft = 10;
        }
        else if (maxNumber > 3000 && maxNumber <= 4000)
        {
            attemptsLeft = 11;
        }
        else if (maxNumber > 4000 && maxNumber <= 5000)
        {
            attemptsLeft = 12;
        }
    }

    public void CheckGuess()
    {
        if (_inputField.text != "")
        {
            var guessedNumber = int.Parse(_inputField.text);
            if (numberToGuess == guessedNumber)
            {
                Win();
            }
            else
            {
                attemptsLeft--;
                attemptsUI.text = attemptsLeft.ToString();
                Hint(guessedNumber);
            }
        }
    }

    private void Hint(int guessedNum)
    {
        if (numberToGuess < guessedNum)
        {
            hintUI.text += "\n" + "<" + _inputField.text;
            _inputField.text = "";
        }
        else if (numberToGuess > guessedNum)
        {
            hintUI.text += "\n" + ">" + _inputField.text;
            _inputField.text = "";
        }
    }

    private void GameOver()
    {
        foreach (var button in buttonsToDisable)
        {
            button.SetActive(false);
        }
        loseCanvas.enabled = true;
        if (!isAnswerShowed)
        {
            hintUI.text += "\n" + "The password was: " + numberToGuess;
            isAnswerShowed = true;
        }
    }

    private void Win()
    {
        _inputField.text = "";
        loadingSlider.value = 0f;
        winCanvas.enabled = true;
        StartCoroutine(fakeLoadingRoutine());
    }

    IEnumerator fakeLoadingRoutine()
    {
        while (loadingSlider.value < .99)
        {
            loadingSlider.value += .003f;
            yield return null;
        }
        FindObjectOfType<SceneLoader>().GetComponent<SceneLoader>().LoadWinScene();
    }
}
