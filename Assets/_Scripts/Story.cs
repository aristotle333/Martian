using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Story : MonoBehaviour {

    public Text         story_text_1;
    public Button       next_button;
    public string       text_string_full;           // The full text of the whole story
    public string       text_string_current;        // The current string of text displayed on the screen
    public int          letter_pos = 0;             // The letter position we are reading from story_text_1

    private int          framesPerLetter = 5;
    public bool         waitingToPressButton = false;
    public bool         startGame = false;

	AudioSource audio;
	public AudioClip typingSound;

    private int         frameCounter = 0;
    private int         text_size = 0;
    void Awake() {
        letter_pos = 0;
        story_text_1 = this.GetComponent<Text>();
        next_button = GameObject.Find("NextButton").GetComponent<Button>();
        next_button.interactable = false;
		text_string_full = Strings.STORY;

		audio = GetComponent<AudioSource> ();

        text_string_current = "";                         // Setting a dummy to set the text to nothing initially
        story_text_1.text = text_string_current;
        text_size = text_string_full.Length;
    }

    void Update() {
        ++frameCounter;
        if (frameCounter >= framesPerLetter && !waitingToPressButton) {
            frameCounter = 0;
            text_string_current += text_string_full[letter_pos];
            story_text_1.text = text_string_current;
			audio.Stop ();

			if (text_string_full[letter_pos] == '\n') {
                waitingToPressButton = true;
                next_button.interactable = true;
            }
			else if (text_string_full[letter_pos] != ' ') {
				audio.PlayOneShot (typingSound);
			}

            ++letter_pos;
        }
        if (letter_pos == text_size) {
            startGame = true;
            waitingToPressButton = true;
            next_button.interactable = true;
			audio.Stop ();
        }
    }

    public void ClickedNext() {
        if (!waitingToPressButton) {
            Debug.Log("Button not ready to press yet!");
            return;
        }
        if (startGame) {
            Debug.Log("Launch the game");
            startGame = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Merged");
            return;
        }
        waitingToPressButton = false;

        // Reset the current text string
        text_string_current = "";
        next_button.interactable = false;
    }
}
