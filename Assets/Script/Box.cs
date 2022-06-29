using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector3 hitPos;
    public bool xMove = true;
    public bool yMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "Wall")
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                hitPos = point.point;
                if (this.transform.position.x != hitPos.x)
                {
                    xMove = false;
                }
                if (this.transform.position.y != hitPos.y)
                {
                    yMove = false;
                }
                Debug.Log(hitPos);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "Wall")
        {
            xMove = true;
            yMove = true;
        }
    }
}
