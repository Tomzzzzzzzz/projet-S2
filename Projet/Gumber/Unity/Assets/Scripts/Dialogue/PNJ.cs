using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PNJ : MonoBehaviour
{
    [SerializeField]
    string[] sentences;
    [SerializeField]
    string characterName;
    int index;
    bool isOndial, canDial;

    HUDManager manager => HUDManager.instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDial)
        {
            StartDialogue();
            manager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
            manager.continueButton.GetComponent<Button>().onClick.AddListener( delegate {NextLine(); });
            Time.timeScale = 0f;
        }
        if (!(isOndial) && PauseMenu.GameIsPaused == false)
        {
            Time.timeScale = 1f;
        }
    }

    public void StartDialogue()
    {
        manager.dialogueHolder.SetActive(true);
        isOndial = true;
        TypingText(sentences);
    }

    void TypingText(string[] sentence)
    {
        manager.nameDisplay.text = "";
        manager.textDisplay.text = "";

        manager.nameDisplay.text = characterName;
        manager.textDisplay.text = sentence[index];

        if (manager.textDisplay.text == sentence[index])
        {
            manager.continueButton.SetActive(true);
        }
    }

    public void NextLine()
    {
        manager.continueButton.SetActive(false);

        if (isOndial && index < sentences.Length - 1)
        {
            index++;
            manager.textDisplay.text = "";
            TypingText(sentences);
        }
        else
        {
            if (isOndial && index == sentences.Length -1)
            {
                isOndial = false;
                index = 0;
                manager.textDisplay.text = "";
                manager.nameDisplay.text = "";
                manager.dialogueHolder.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canDial = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canDial = false;
        }
    }
}
