using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canDialogue : MonoBehaviour
{
    private bool playerIn = false;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private GameObject dialog;
    [SerializeField, TextArea(4,6)] private string[] dialogLines;

    private bool didDialogueStart;
    private int idx=0;
    public float delayTime = 0.05f;

    void Update()
    {
        if(playerIn && Input.GetKeyDown(KeyCode.E))
        {
            if(!didDialogueStart)
            {
                dialogueInit();
            }
            else
            {
                if(dialogText.text == dialogLines[idx])
                {
                    NextDialogueLine();
                }
            }
        }
    }

    private void dialogueInit()
    {
        Time.timeScale = 0f;
        didDialogueStart = true;
        dialogPanel.SetActive(true);
        dialog.SetActive(false);
        idx = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {

        idx++;
        if(idx<dialogLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialogPanel.SetActive(false);
            dialog.SetActive(true);
            Time.timeScale = 1f;

        }
    }
    private IEnumerator ShowLine()
    {
        dialogText.text = string.Empty;
        foreach (char ch in dialogLines[idx])
        {
            dialogText.text+= ch;
            yield return new WaitForSecondsRealtime(delayTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            playerIn = true;
            dialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            playerIn = false;
            dialog.SetActive(false);
        }
    }

}
