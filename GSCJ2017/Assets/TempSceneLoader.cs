using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TempSceneLoader : MonoBehaviour {

    float timer = 3;
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer<= 0)
            {
                newGame();
            }
        }
	}

    void newGame()
    {
        SceneManager.LoadScene("levelSetUpTest");
    }
}
