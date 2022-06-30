using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private Sprite forward;
    [SerializeField] private Sprite back;
    [SerializeField] private Sprite right;
    [SerializeField] private Sprite left;
    [SerializeField] GameDirector gameDirector;
    [SerializeField] AudioClip kick;  //��������������SE
    [SerializeField] AudioSource audioS;
    public Vector3 movePos;
    private Vector3 moveX = new Vector3(1, 0, 0);  //X�����̈ړ���
    private Vector3 moveY = new Vector3(0, 1, 0);  //Y�����̈ړ���
    private Vector2 target;
    [SerializeField] private float speed;  //�ړ����x
    private bool moveJudge = true;
    [SerializeField] LayerMask blockLayer;
    private int boxMove;
    RaycastHit2D hit;
    RaycastHit2D [] hits = new RaycastHit2D [4];
    private GameObject box;
    private Box boxScr;
    // Start is called before the first frame update
    void Start()
    {
        movePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hits[0] = Physics2D.Raycast(transform.position, transform.up, 1f, blockLayer);
        hits[1] = Physics2D.Raycast(transform.position, -transform.up, 1f, blockLayer);
        hits[2] = Physics2D.Raycast(transform.position, transform.right, 1f, blockLayer);
        hits[3] = Physics2D.Raycast(transform.position, -transform.right, 1f, blockLayer);

        if (hits[0].collider != null || hits[1].collider != null || hits[2].collider != null || hits[3].collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hit = hits[boxMove];
                if (hit.collider != null && hit.collider.gameObject.tag == "box")  //��������
                {
                    audioS.PlayOneShot(kick);
                    box = hit.collider.gameObject;
                    boxScr = box.GetComponent<Box>();
                    target = (hit.collider.transform.position - this.transform.position).normalized;
                    if (!boxScr.xMove)
                    {
                        target.x = 0;
                    }
                    if (!boxScr.yMove)
                    {
                        target.y = 0;
                    }
                    hit.collider.transform.Translate(Mathf.Round(target.x), Mathf.Round(target.y), 0);
                }
            }
        }
        if (moveJudge)
        {
            //�ړ�
            if (Input.GetKeyDown(KeyCode.W))
            {
                boxMove = 0;
                playerRenderer.sprite = forward;
                if (hits[0].collider == null)  //�ړ��\���ǂ���
                {
                    movePos = transform.position + moveY;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                boxMove = 1;
                playerRenderer.sprite = back;
                if (hits[1].collider == null)  //�ړ��\���ǂ���
                {
                    movePos = transform.position + -moveY;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                boxMove = 2;
                playerRenderer.sprite = right;
                if (hits[2].collider == null)  //�ړ��\���ǂ���
                {
                    movePos = transform.position + moveX;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                boxMove = 3;
                playerRenderer.sprite = left;
                if (hits[3].collider == null)  //�ړ��\���ǂ���
                {
                    movePos = transform.position + -moveX;
                }
                moveJudge = false;
            }
        }
        playerPos.position = Vector3.MoveTowards(playerPos.position, movePos, speed * Time.deltaTime);
        if (playerPos.position == movePos)
        {
            moveJudge = true;
        }
        if (Input.GetKeyDown(KeyCode.R))  //�V�[���̃����[�h�B�X�e�[�W�����߂���ɂȂ�
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�X�e�[�W�N���A����
        gameDirector.StageClear();
    }
}
