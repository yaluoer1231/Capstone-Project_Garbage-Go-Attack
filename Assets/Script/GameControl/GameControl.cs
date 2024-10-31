using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public GameObject PlotMaskUI;
    public GameObject PlayMaskUI;
    public GameObject PlotNextpageButton;
    public GameObject PlayNextpageButton;

    public Sprite Next, Up;
    public Sprite Plot1, Plot2;
    public Sprite Play1, Play2;

    public bool Plot = false;
    public bool Play = false;


    // Use this for initialization
    void Start () {
        PlotMaskUI.SetActive(false);
        PlayMaskUI.SetActive(false);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartButton(){
        SceneManager.LoadSceneAsync(1);
    }

	public void ExitButton(){
        Application.Quit();
	}

    public void PlotMask()
    {
        if (Plot == false)
        {
            PlotMaskUI.SetActive(true);
            Plot = true;
        }
        else if (Plot == true)
        {
            PlotMaskUI.SetActive(false);
            Plot = false;
        }
    }

    public void PlotNextPage()
    {
        if (PlotMaskUI.GetComponent<Image>().sprite.name == "Plot1")
        {
            PlotNextpageButton.GetComponent<Image>().sprite = Up;
            PlotMaskUI.GetComponent<Image>().sprite = Plot2;
        }
        else
        {
            PlotNextpageButton.GetComponent<Image>().sprite = Next;
            PlotMaskUI.GetComponent<Image>().sprite = Plot1;
        }
    }

    public void PlayMask()
    {
        if (Play == false)
        {
            PlayMaskUI.SetActive(true);
            Play = true;
        }
        else if (Play == true)
        {
            PlayMaskUI.SetActive(false);
            Play = false;
        }
    }

    public void PlayNextPage()
    {
        if (PlayMaskUI.GetComponent<Image>().sprite.name == "Play1")
        {
            PlayNextpageButton.GetComponent<Image>().sprite = Up;
            PlayMaskUI.GetComponent<Image>().sprite = Play2;
        }
        else
        {
            PlayNextpageButton.GetComponent<Image>().sprite = Next;
            PlayMaskUI.GetComponent<Image>().sprite = Play1;
        }
    }
}
