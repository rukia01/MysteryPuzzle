using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject[] stage;
    [SerializeField] Transform[] plyerPos;
    [SerializeField] Transform player;
    [SerializeField] BoxCollider2D playerCol;
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject panel;
    [SerializeField] Text stageClearText;
    [SerializeField] GameObject nextStageBotton;
    [SerializeField] GameObject titleBotton;
    [SerializeField] GameObject clearTitleBotton;
    [SerializeField] AudioSource audioS;
    [SerializeField] AudioClip clear;
    [SerializeField] AudioClip allClear;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    public void StageClear()
    {
        playerController.enabled = false;
        i++;
        if (i == stage.Length)
        {
            audioS.PlayOneShot(allClear);
            stageClearText.text = "全ステージクリア!!";
            panel.SetActive(true);
            nextStageBotton.SetActive(false);
            titleBotton.SetActive(false);
            clearTitleBotton.SetActive(true);
        }
        else
        {
            audioS.PlayOneShot(clear);
            stageClearText.text = "ステージ" + i + "クリア";
            panel.SetActive(true);
            clearTitleBotton.SetActive(false);
        }
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void NextStage()
    {
        if (i < stage.Length)
        {
            mainCamera.transform.position = new Vector3(0, stage[i].transform.position.y, mainCamera.transform.position.z);
            player.position = plyerPos[i].position;
            playerController.enabled = true;
            playerController.movePos = plyerPos[i].position;
        }
        panel.SetActive(false);
    }
}
