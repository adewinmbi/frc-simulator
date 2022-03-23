using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelect : MonoBehaviour {

    [SerializeField] private List<Button> buttons;

    private void Start() {
        foreach (Button b in buttons) {
            b.onClick.AddListener(delegate { LevelSelected(b.gameObject.name); });
        }
    }

    private void LevelSelected(string level) {
        SceneManager.LoadScene(level);
    }

}
