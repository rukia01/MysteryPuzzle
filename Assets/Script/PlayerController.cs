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
    // Start is called before the first frame update
    void Start()
    {
        movePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveJudge)
        {
            if (Input.GetKeyDown(KeyCode.W)) 
            { 
                movePos = transform.position + moveY;
                moveJudge = false;
            }
            if (Input.GetKeyDown(KeyCode.S)) 
            { 
                movePos = transform.position + -moveY;
                moveJudge = false;
            }
            if (Input.GetKeyDown(KeyCode.D)) 
            { 
                movePos = transform.position + moveX;
                moveJudge = false;
            }
            if (Input.GetKeyDown(KeyCode.A)) 
            { 
                movePos = transform.position + -moveX;
                moveJudge = false;
            }
        }
        playerPos.position = Vector3.MoveTowards(playerPos.position, movePos, speed * Time.deltaTime);
        if (playerPos.position == movePos) { moveJudge = true; }
        Ray2D ray = new Ray2D(transform.position, transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5f);
        if (hit.collider)
        {
            Debug.Log("“–‚½‚Á‚½");
        }
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.green);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         target = (box.transform.position - this.transform.position).normalized;
         collision.transform.Translate(target.x * 2, target.y * 2, 0);
    }
}
