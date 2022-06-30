using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject[] stage;  //ステージ
    [SerializeField] Transform[] plyerPos;  //ステージごとのプレイヤーの開始位置
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
    [SerializeField] AudioSource bgm;  //BGM
    [SerializeField] AudioClip clear;  //クリアSE
    [SerializeField] AudioClip allClear;  //全ステージクリアSE
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        bgm.Play();
    }

    // Update is called once per frame
    public void StageClear()
    {
        bgm.Stop();
        playerController.enabled = false;
        i++;
        if (i == stage.Length)  //全ステージクリア
        {
            audioS.PlayOneShot(allClear);
            stageClearText.text = "全ステージクリア!!";
            panel.SetActive(true);
            nextStageBotton.SetActive(false);
            titleBotton.SetActive(false);
            clearTitleBotton.SetActive(true);
        }
        else  //ステージクリア
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
    public void NextStage()  //次のステージに移動
    {
        if (i < stage.Length)
        {
            mainCamera.transform.position = new Vector3(0, stage[i].transform.position.y, mainCamera.transform.position.z);
            player.position = plyerPos[i].position;
            playerController.enabled = true;
            playerController.movePos = plyerPos[i].position;
        }
        panel.SetActive(false);
        bgm.Play();
    }
}
