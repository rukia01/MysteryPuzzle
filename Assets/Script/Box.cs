using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector3 hitPos;
    public bool xMove = true;  //X�����Ɉړ��\��
    public bool yMove = true;  //Y�����Ɉړ��\��
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "Wall")
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                hitPos = point.point;
                if (this.transform.position.x != hitPos.x)  //X�����Ɉړ��ł��Ȃ�
                {
                    xMove = false;
                }
                if (this.transform.position.y != hitPos.y)  //Y�����Ɉړ��ł��Ȃ�
                {
                    yMove = false;
                }
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
