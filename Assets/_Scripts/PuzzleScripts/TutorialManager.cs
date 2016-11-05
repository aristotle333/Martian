using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

    public static TutorialManager S;

    const string Room0Text0 = "Some puzzle rooms will have oxygen tanks allowing you to refill. \nBlue tanks are full, Green tanks are empty";
    const string Room1Text0 = "Black boxes when shot are destroyed together \nwith their counterpart box in the opposite room";
    const string Room2Text0 = "Red boxes in a blue room are transparent and vice versa. \nWalk through them!";
    const string Room3Text0 = "Green boxes when shot will dissapear from one room and appear in the other room.";
    const string Room7Text0 = "Purple boxes rotate when shot!";
    const string Room8Text0 = "Good Luck! \nMind your oxygen levels!";

    const string BringPartBack = "You need to bring back the part to the signal tower next to your base.";


    void Awake() {
        S = this;
    }

    public void DisplayTutorial(int room_number) {
        if (room_number == 0) {
            GameManager.S.setPromptText(Room0Text0);
        }
        else if (room_number == 1) {
            GameManager.S.setPromptText(Room1Text0);
        }
        else if (room_number == 2) {
            GameManager.S.setPromptText(Room2Text0);
        }
        else if (room_number == 2) {
            GameManager.S.setPromptText(Room3Text0);
        }
        else if (room_number == 7) {
            GameManager.S.setPromptText(Room7Text0);
        }
        else if (room_number == 8) {
            GameManager.S.setPromptText(Room8Text0);
        }
    }

    public void CallQuestBack() {
        GameManager.S.setPromptText(BringPartBack);
    }

}
