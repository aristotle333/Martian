using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager S;
	public GameObject light_source;
	public GameObject light_source_2;
	private int _playerHealthValue;
	const int MAXOXYGEN = 100;
	const float OXYGENCONSUMPTIONINTERVAL = 3.5f;

	[SerializeField]
	private int _oxygenValue;
	[SerializeField]
	private float _timeOfDay;
	private int _dayNum;

	[SerializeField]
	private Text healthText;
	[SerializeField]
	private Text oxygenText;
	[SerializeField]
	private Slider oxygenSlider;
	[SerializeField]
	private Image oxygenFillColor;
	[SerializeField]
	private Text timeText;
//	[SerializeField]
//	private Text dayText;
	[SerializeField]
	private Slider healthSlider;
	[SerializeField]
	private AudioSource audioSource;
	[SerializeField]
	private AudioClip breathingIn;

	public GameObject questPromptPanel;
	public Text questPromptText;

	int promptTTL = 15;

	public Image crosshairImage;

    public List<GameObject>             Rooms;                      // A list of all the rooms of the puzzle
    public int                          activeRoomNumber = 0;       // The current room that the player is currently in
    public Vector3                      puzzleOffset = new Vector3(-10f, 2f, 18.5f);

    public List<GameObject>             QuestLocations;
    public Vector3                      QuestExitOffset = new Vector3(0f, 0f, 50f);                            // Add a vector3 offset once you finish the quest

    public int playerHealthValue {
		get { 
			return _playerHealthValue;
		}
		set { 
			_playerHealthValue = value;
			healthText.text = _playerHealthValue.ToString();
			healthSlider.value = _playerHealthValue;
		}
	}

	public string promptText {
		get{ 
			return questPromptText.text;
		}
		set{ 
			questPromptPanel.SetActive (true);
			questPromptText.text = value;
			Invoke ("closePrompt", promptTTL);
		}
	}
		
	public int oxygenValue {
		get { 
			return _oxygenValue;
		}
		set {
			if (value <= MAXOXYGEN) {
				if (value > _oxygenValue) {
					if (!audioSource.isPlaying) {
						audioSource.PlayOneShot (breathingIn);	
					}
				}

				_oxygenValue = value;
				oxygenText.text = _oxygenValue.ToString ();
				oxygenSlider.value = _oxygenValue;

				if (_oxygenValue <= 0) {
					--Player.S.health;
					_oxygenValue = 0;
					oxygenText.text = _oxygenValue.ToString ();
				}

				if (_oxygenValue < 20) {
					oxygenFillColor.color = Color.red;
				} else {
					oxygenFillColor.color = Color.green;
				}

			} else {
				oxygenValue = MAXOXYGEN;
			}
		}
	}

	public float timeOfDay {
		get{ 
			return _timeOfDay;
		}
		set { 
			_timeOfDay = value;
			int integerForm = (int)_timeOfDay;
			timeText.text = integerForm.ToString();
		}
	}
		
		
	void Awake () {
		S = this;
//		dayNum = 1;

	}

	// Use this for initialization
	void Start () {
//		ironValue = 20;
		oxygenValue = 40;
		timeOfDay = 0.0f;
		InvokeRepeating("DecreaseOxygen", OXYGENCONSUMPTIONINTERVAL, OXYGENCONSUMPTIONINTERVAL);
		questPromptPanel.SetActive (false);
		Invoke ("ShowAwakePrompt", 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTime ();	
	}

	void UpdateTime() {
		timeOfDay += Time.deltaTime;
        if (timeOfDay >= 180) {
            timeOfDay = 0;
        }

		if (timeOfDay / 90f < 1) {
			light_source.GetComponent<Light> ().intensity = Mathf.Lerp (1.22f, 0f, timeOfDay / 90f);
			light_source_2.GetComponent<Light> ().intensity = Mathf.Lerp (0.8f, 0f, timeOfDay / 90f);
		} else 
		{
			light_source.GetComponent<Light> ().intensity = Mathf.Lerp (0f, 1.22f, timeOfDay / 90f-1);
			light_source_2.GetComponent<Light> ().intensity = Mathf.Lerp (0f, 0.8f, timeOfDay / 90f-1);
		}

	}

	void DecreaseOxygen() {
		--oxygenValue;
	}

    public bool isNight() {
        if (_timeOfDay < 120.0f)
            return false;
        else
            return true;
    }

    public void changeMazeLevel() {
        activeRoomNumber++;
        Player.S.isChangingRoom = true;
        print("set isChangingRoom to true");
        StartCoroutine(teleportToNextLevel());
    }

    public IEnumerator teleportToNextLevel() {
        Debug.Log("Calling teleportToNextLevel() function");
        Vector3 nextRoomPos = Rooms[activeRoomNumber].transform.position;
        Vector3 playerPos = nextRoomPos + puzzleOffset;
        float waitTime = FadeInFadeOut.S.BeginFade(1);
        yield return new WaitForSeconds(10 * waitTime);
        Player.S.gameObject.transform.position = playerPos;

        Player.S.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);

        waitTime = FadeInFadeOut.S.BeginFade(-1);
        yield return new WaitForSeconds(10 * waitTime);
        Player.S.playerCollidedWithQuestDoor = false;
        Player.S.isChangingRoom = false;
        TutorialManager.S.DisplayTutorial(activeRoomNumber);
        print("Set is changing room to false");
    }

    public void setPromptText(string s="") {
		if (s == "") {
			if (Terminal.S.questActive) {
				if (Terminal.S.numSteelBeamsMade == Terminal.FIRSTQUESTTRIGGER) {
					promptText = Strings.QUESTONEPROMPT;
				} else if (Terminal.S.numSteelBeamsMade == Terminal.SECONDQUESTTRIGGER) {
					promptText = Strings.QUESTTWOPROMPT;
				} else if (Terminal.S.numSteelBeamsMade == Terminal.THIRDQUESTTRIGGER) {
					promptText = Strings.QUESTTHREEPROMPT;
				}
			} else {
				if (Terminal.S.numSteelBeamsMade == Terminal.FIRSTQUESTTRIGGER) {
					promptText = Strings.QUESTONECOMPLETE;
				} else if (Terminal.S.numSteelBeamsMade == Terminal.SECONDQUESTTRIGGER) {
					promptText = Strings.QUESTTWOCOMPLETE;
				} else if (Terminal.S.numSteelBeamsMade == Terminal.THIRDQUESTTRIGGER) {
					promptText = Strings.QUESTTHREECOMPLETE;
				}
			}
		} else {
			promptText = s;
		}
	}

	public void closePrompt() {
		questPromptPanel.SetActive (false);	

		print ("i'm closing");
	}

	public void ShowAwakePrompt() {
		setPromptText (Strings.PLAYERAWAKEPROMPT);	
	}
}
