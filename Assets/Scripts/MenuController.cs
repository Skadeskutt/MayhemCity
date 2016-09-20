using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject[] Buttons;
    /*
     * 0 = PlayButton
     * 1 = TutorialButton
     * 2 = MainMenuButton
     * 3 = NextButton1
     * 4 = BackButton */

    public Sprite[] tutSprites;
    //public GameObject tutSprite;
    int nextClick = 0;
    public Image tutImage;
    bool tutActive = false;

    // Use this for initialization
    void Start () {
        Buttons[2].SetActive(false);
        Buttons[3].SetActive(false);
        Buttons[4].SetActive(false);
        //tutSprite.SetActive(false);
        tutImage.GetComponent<Image>().sprite = tutSprites[0];          
    }
	
    void Update()
    {
        Debug.Log(nextClick);
        if (tutActive)
        {
            if (nextClick == -1)
            {
                nextClick++;
                tutImage.GetComponent<Image>().sprite = tutSprites[1];
            }

            if (nextClick == 0)
            {
                tutImage.GetComponent<Image>().sprite = tutSprites[1];
            }

            if (nextClick == 1)
            {
                tutImage.GetComponent<Image>().sprite = tutSprites[2];
            }

            if (nextClick == 2)
            {
                //tutSprite.GetComponent<SpriteRenderer>().sprite = tutSprites[2];
                tutImage.GetComponent<Image>().sprite = tutSprites[3];
            }

            if (nextClick == 3)
            {
                nextClick--;
                tutImage.GetComponent<Image>().sprite = tutSprites[3];
            }
        }
    }

    public void PlayGame()
    {
        Application.LoadLevel(0);
    }

    public void Tutorial()
    {      
        Buttons[0].SetActive(false);
        Buttons[1].SetActive(false);
        Buttons[2].SetActive(true);
        Buttons[3].SetActive(true);
        Buttons[4].SetActive(true);
        //tutSprite.SetActive(true);
        tutImage.GetComponent<Image>().sprite = tutSprites[1];
        tutActive = true;

    }

    public void Next()
    {   
        Buttons[0].SetActive(false);
        Buttons[1].SetActive(false);
        Buttons[2].SetActive(true);
        Buttons[3].SetActive(true);
        //tutSprite.GetComponent<SpriteRenderer>().sprite = tutSprites[1];
        tutImage.GetComponent<Image>().sprite = tutSprites[2];
        nextClick++;

      


    }

    public void MainMenu()
    {
        Buttons[0].SetActive(true);
        Buttons[1].SetActive(true);
        Buttons[2].SetActive(false);
        Buttons[3].SetActive(false);
        Buttons[4].SetActive(false);
        //tutSprite.SetActive(false);
        tutActive = false;
        tutImage.GetComponent<Image>().sprite = tutSprites[0];
        nextClick = 0;
    }

    public void Back()
    {
        nextClick--;
    }

}
