using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] GameObject box;
    public Vector3 movePos;
    private Vector3 moveX = new Vector3(1, 0, 0);
    private Vector3 moveY = new Vector3(0, 1, 0);
    private Vector2 target;
    [SerializeField] private float speed;
    private bool moveJudge = true;
    [SerializeField] LayerMask blockLayer;
    [SerializeField] private Vector3 previousPos;
    // Start is called before the first frame update
    void Start()
    {
        movePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        previousPos = transform.position;
        Ray2D ray = new Ray2D(transform.position, transform.up);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1f, blockLayer);
        if (hit)
        {
            Debug.DrawRay(transform.position, transform.up, Color.red);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                target = (hit.collider.transform.position - this.transform.position).normalized;
                hit.collider.transform.Translate(target.x, target.y, 0);
            }
        }
        if (moveJudge)
        {
            if (Input.GetKeyDown(KeyCode.W)) 
            { 
                transform.eulerAngles = Vector3.zero;
                movePos = transform.position + moveY;
                moveJudge = false;
            }
            if (Input.GetKeyDown(KeyCode.S)) 
            { 
                transform.eulerAngles = new Vector3(0, 0, 180);
                movePos = transform.position + -moveY;
                moveJudge = false;
            }
            if (Input.GetKeyDown(KeyCode.D)) 
            { 
                transform.eulerAngles = new Vector3(0, 0, 270);
                movePos = transform.position + moveX;
                moveJudge = false;
            }
            if (Input.GetKeyDown(KeyCode.A)) 
            { 
                transform.eulerAngles = new Vector3(0, 0, 90);
                movePos = transform.position + -moveX;
                moveJudge = false;
            }
        }
        playerPos.position = Vector3.MoveTowards(playerPos.position, movePos, speed * Time.deltaTime);
        if (playerPos.position == movePos) { moveJudge = true; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = previousPos;
    }
}
