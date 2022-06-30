using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonController : MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Rule()
    {
        SceneManager.LoadScene("Rule");
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

}
