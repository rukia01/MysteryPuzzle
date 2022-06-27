using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private Sprite forward;
    [SerializeField] private Sprite back;
    [SerializeField] private Sprite right;
    [SerializeField] private Sprite left;
    public Vector3 movePos;
    private Vector3 moveX = new Vector3(1, 0, 0);
    private Vector3 moveY = new Vector3(0, 1, 0);
    private Vector2 target;
    [SerializeField] private float speed;
    private bool moveJudge = true;
    [SerializeField] LayerMask blockLayer;
    private int boxMove;
    RaycastHit2D hit;
    RaycastHit2D [] hits = new RaycastHit2D [4];
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

        //Debug.Log((hits[0].collider == null) + ":" + (hits[1].collider == null) + ":" + (hits[2].collider == null) + ":" + (hits[3].collider == null)) ;
        if (hits[0].collider != null || hits[1].collider != null || hits[2].collider != null || hits[3].collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hit = hits[boxMove];
                if (hit.collider != null)  //” ‚ð‰Ÿ‚·
                {
                    target = (hit.collider.transform.position - this.transform.position).normalized;
                    hit.collider.transform.Translate(Mathf.Round(target.x), Mathf.Round(target.y), 0);
                }
            }
        }
        if (moveJudge)
        {
            //ˆÚ“®
            if (Input.GetKeyDown(KeyCode.W))
            {
                boxMove = 0;
                playerRenderer.sprite = forward;
                if (hits[0].collider == null)
                {
                    movePos = transform.position + moveY;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                boxMove = 1;
                playerRenderer.sprite = back;
                if (hits[1].collider == null)
                {
                    movePos = transform.position + -moveY;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                boxMove = 2;
                playerRenderer.sprite = right;
                if (hits[2].collider == null)
                {
                    movePos = transform.position + moveX;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                boxMove = 3;
                playerRenderer.sprite = left;
                if (hits[3].collider == null)
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
    }
}
