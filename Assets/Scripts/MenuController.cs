using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour {
    [SerializeField] private Text score;

    void Start() {
        if (score != null){
            this.GameOver();
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    private void GameOver() {
        score.text = "Score: " + Score.Instance.points;
    }
}
