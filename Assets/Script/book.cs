using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;

    [SerializeField] TextMeshProUGUI frontTextPage1;
    [SerializeField] TextMeshProUGUI backTextPage1;
    [SerializeField] TextMeshProUGUI frontTextPage2;
    [SerializeField] TextMeshProUGUI backTextPage2;


    private void Start()
    {
        backButton.SetActive(false);
    }

    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 180;
        ForwardButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));

        ShowTextOnPage(pages[index], frontTextPage1, backTextPage1);
        ShowTextOnPage(pages[index + 1], frontTextPage2, backTextPage2);
    }

    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true);
        }
        if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false);
        }
    }

    public void RotateBack()
    {
        if (rotate == true) { return; }
        float angle = 0;
        pages[index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));

        ShowTextOnPage(pages[index], frontTextPage1, backTextPage1);
        ShowTextOnPage(pages[index + 1], frontTextPage2, backTextPage2);
    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true);
        }
        if (index - 1 == -1)
        {
            backButton.SetActive(false);
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while(true) 
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angel1 = Quaternion.Angle(pages[index].rotation, targetRotation);
            if(angel1 < 0.1f)
            { 
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }
    void ShowTextOnPage(Transform page, TextMeshProUGUI frontText, TextMeshProUGUI backText)
    {
        // Set the visibility of the text based on the rotation of the page
        if (page.rotation.eulerAngles.y < 90 || page.rotation.eulerAngles.y > 270)
        {
            frontText.gameObject.SetActive(false);
            backText.gameObject.SetActive(true);
        }
        else
        {
            frontText.gameObject.SetActive(true);
            backText.gameObject.SetActive(false);
        }
    }
}
