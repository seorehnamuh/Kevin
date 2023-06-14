using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetTask : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> acorns;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool hasTask;
    void Start()
    {
        hasTask = false;    
        textComponent.text = string.Empty;
        acorns.ForEach(x => x.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        getOKeyBoard();
        if (getOKeyBoard() == true && hasTask == true)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Task"))
        {
            if (getOKeyBoard() == true)
            {
                Debug.Log("Log from collision");
            }
            StartDialogue();
            Destroy(collision.gameObject);
            acorns.ForEach(x => x.SetActive(true));
            hasTask = true;
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char word in lines[index].ToCharArray())
        {
            textComponent.text += word;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.gameObject.SetActive(false);
        }
    }

    private bool getOKeyBoard()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            return true;
        }
        return false;
    }
}
