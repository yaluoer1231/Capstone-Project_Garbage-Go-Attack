using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl_Choice : MonoBehaviour {

    public static GameControl_Choice Choice;
    public Sprite[] GameChoose = new Sprite[4];
    public GameObject Panel;
    public GameObject LoadScreen;
    public Image LoadImage;

    public int Gamestage = 1;
    public int NowStage;
	// Use this for initialization
	void Start () {
        LoadScreen.SetActive(false);
    }

    void Awake()
    {
        Choice = this;
    }

    // Update is called once per frame
    void Update () {
        try
        {
            Gamestage = GameControl_Game.GameCtrl.Stage;
            if (Gamestage == 1)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[0];
            }
            else if (Gamestage == 2)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[1];
            }
            else if (Gamestage == 3)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[2];
            }
            else if (Gamestage == 4)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[3];
            }
        }
        catch
        {
            if (Gamestage == 1)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[0];
            }
            else if (Gamestage == 2)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[1];
            }
            else if (Gamestage == 3)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[2];
            }
            else if (Gamestage == 4)
            {
                Panel.GetComponent<Image>().sprite = GameChoose[3];
            }
        }
    }

	public void OnetButton(){
        NowStage = 1;
        LoadScreen.SetActive(true);
        StartCoroutine(Loading());
        SceneManager.LoadSceneAsync(2);
    }

	public void TwotButton(){
        if (Gamestage > 1)
        {
            NowStage = 2;
            Gamestage = GameControl_Game.GameCtrl.Stage;
            LoadScreen.SetActive(true);
            StartCoroutine(Loading());
            SceneManager.LoadSceneAsync(3);
        }
    }

	public void ThreetButton(){
        if (Gamestage > 2)
        {
            NowStage = 3;
            Gamestage = GameControl_Game.GameCtrl.Stage;
            LoadScreen.SetActive(true);
            StartCoroutine(Loading());
            SceneManager.LoadSceneAsync(4);
        }
    }

	public void FourtButton(){
        if (Gamestage > 3)
        {
            NowStage = 4;
            Gamestage = GameControl_Game.GameCtrl.Stage;
            LoadScreen.SetActive(true);
            StartCoroutine(Loading());
            SceneManager.LoadSceneAsync(5);
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameNext()
    {
        Gamestage = GameControl_Game.GameCtrl.Stage;
    }

    IEnumerator Loading()
    {
        AsyncOperation async = Application.LoadLevelAsync((NowStage + 1));
        while(!async.isDone)
        {
            LoadImage.transform.localScale = new Vector2(async.progress, LoadImage.transform.localScale.y);
            yield return null;
        }
    }
}
