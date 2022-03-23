using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    
    public void BeginGame() {
        SceneManager.LoadScene("SampleScene");
    }

}
