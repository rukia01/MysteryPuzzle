using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
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
        //Debug.DrawRay(transform.position, transform.up, Color.red);
        //Debug.DrawRay(transform.position, -transform.up, Color.red);
        //Debug.DrawRay(transform.position, transform.right, Color.red);
        //Debug.DrawRay(transform.position, -transform.right, Color.red);

        Debug.Log((hits[0].collider == null) + ":" + (hits[1].collider == null) + ":" + (hits[2].collider == null) + ":" + (hits[3].collider == null)) ;
        if (hits[0].collider != null || hits[1].collider != null || hits[2].collider != null || hits[3].collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hit = hits[boxMove];
                if (hit.collider != null)
                {
                    target = (hit.collider.transform.position - this.transform.position).normalized;
                    hit.collider.transform.Translate(Mathf.Round(target.x), Mathf.Round(target.y), 0);
                }
            }
        }
        if (moveJudge)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                boxMove = 0;
                if (hits[0].collider == null)
                {
                    Debug.Log("è„");
                    movePos = transform.position + moveY;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                boxMove = 1;
                if (hits[1].collider == null)
                {
                    Debug.Log("â∫");
                    movePos = transform.position + -moveY;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                boxMove = 2;
                transform.localScale = Vector3.one;
                if (hits[2].collider == null)
                {
                    Debug.Log("âE");
                    movePos = transform.position + moveX;
                }
                moveJudge = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                boxMove = 3;
                transform.localScale = new Vector3(-1,1,1);
                if (hits[3].collider == null)
                {
                    Debug.Log("ç∂");
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
