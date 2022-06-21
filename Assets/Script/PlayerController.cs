using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    public Vector3 movePos;
    private Vector3 moveX = new Vector3(1, 0, 0);
    private Vector3 moveY = new Vector3(0, 1, 0);
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
    }
}
