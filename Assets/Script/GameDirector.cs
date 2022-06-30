using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject[] stage;  //�X�e�[�W
    [SerializeField] Transform[] plyerPos;  //�X�e�[�W���Ƃ̃v���C���[�̊J�n�ʒu
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
    [SerializeField] AudioClip clear;  //�N���ASE
    [SerializeField] AudioClip allClear;  //�S�X�e�[�W�N���ASE
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
        if (i == stage.Length)  //�S�X�e�[�W�N���A
        {
            audioS.PlayOneShot(allClear);
            stageClearText.text = "�S�X�e�[�W�N���A!!";
            panel.SetActive(true);
            nextStageBotton.SetActive(false);
            titleBotton.SetActive(false);
            clearTitleBotton.SetActive(true);
        }
        else  //�X�e�[�W�N���A
        {
            audioS.PlayOneShot(clear);
            stageClearText.text = "�X�e�[�W" + i + "�N���A";
            panel.SetActive(true);
            clearTitleBotton.SetActive(false);
        }
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void NextStage()  //���̃X�e�[�W�Ɉړ�
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
