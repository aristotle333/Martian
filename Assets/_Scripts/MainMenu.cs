using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public float waitingTime = 8f;
    public GameObject Image;
    public GameObject StartButton;
    public GameObject QuitButton;
    public GameObject Title;
    public GameObject Controls;
    public GameObject controlImage;

    void Start() {
        controlImage.SetActive(false);
    }

    public void StartGame() {
        Debug.Log("Starting a new Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Story");
    }

    public void QuitGame() {
        Debug.Log("Quite Game Called");
        Application.Quit();
    }

    public void Credits() {
        StartCoroutine(CreditsCoroutine());
    }

    public IEnumerator CreditsCoroutine() {
        GameObject.Find("Image").SetActive(false);
        GameObject.Find("StartButton").SetActive(false);
        GameObject.Find("QuitButton").SetActive(false);
        GameObject.Find("Controls").SetActive(false);
        GameObject.Find("Title").SetActive(false);
        float waitTime = FadeInFadeOut.S.BeginFade(1);
        yield return new WaitForSeconds(50 * waitTime);
        Text textRef = GameObject.Find("Credits").GetComponent<Text>();
        textRef.enabled = true;
        waitTime = FadeInFadeOut.S.BeginFade(-1);
        yield return new WaitForSeconds(200 * waitTime);
        StartGame();
    }

    public void ShowControls() {

        if (Title.active) {
            Image.SetActive(false);
            StartButton.SetActive(false);
            QuitButton.SetActive(false);
            Title.SetActive(false);
            //GameObject.Find("Credits").SetActive(false);

            controlImage.SetActive(true);
        }
        else {
            controlImage.SetActive(false);

            Image.SetActive(true);
            StartButton.SetActive(true);
            QuitButton.SetActive(true);
            Title.SetActive(true);
        }
    }


}
