using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canDialogue : MonoBehaviour
{
    private bool playerIn = false;
    public bool pista = false;
    public bool locked = false;

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private GameObject dialog;
    [SerializeField, TextArea(4,6)] private string[] dialogLines;
    GameObject player;
    private string[] dialogLinesBlock = {"mm...","Parecec que esta gabeta esta cerrada","Supongo que necesitare una llave","Tal vez podria intentar abrirla"};
    private string[] tmp_dialogue;
    private bool didDialogueStart;
    private int idx=0;
    public float delayTime = 0.05f;


    void Start()
    {
        if(locked)
        {
            tmp_dialogue = dialogLinesBlock;
        }
        else
        {
            tmp_dialogue = dialogLines;
        }
    }
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
                if(dialogText.text == tmp_dialogue[idx])
                {
                    NextDialogueLine();
                }
            }
        }
        if(playerIn && Input.GetKeyDown(KeyCode.Q))
        {
            locked = false;
            tmp_dialogue = dialogLines;
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
        if(idx<tmp_dialogue.Length)
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
        foreach (char ch in tmp_dialogue[idx])
        {
            dialogText.text+= ch;
            yield return new WaitForSecondsRealtime(delayTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.GetComponent<Collider2D>().CompareTag("Player") && !other.gameObject.GetComponent<CharacterController>().inDialogue)
        {
            playerIn = true;
            //player = GameObject.Find(Collider2D.name);
           // Debug.Log(player.transform);
            dialog.SetActive(true);
            other.gameObject.GetComponent<CharacterController>().inDialogue = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            playerIn = false;
            dialog.SetActive(false);
            other.gameObject.GetComponent<CharacterController>().inDialogue = false;
        }
    }

}
