using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    public void  restartGame()
    {
        //SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene(1);
    }

    public void endGame()
    {
        // 게임 종료
        Application.Quit();
    }
}
