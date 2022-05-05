using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public SpriteRenderer[] tiles1;
    public Sprite groundimg;
    public Sprite groundimg1;
    public float speed;
    void Start()

    {
        temp = tiles[0];
    }
    SpriteRenderer temp;


    void Update()
    { 
        for (int i = 0; i < tiles.Length; i++)
        {
            if (-10 >= tiles[i].transform.position.x)
            {
                for(int j = 0; j < tiles.Length; j++)
                {
                    if(temp.transform.position.x < tiles[j].transform.position.x)
                    {
                        temp = tiles[j];
                    }
                }

                tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -3.5f);
                tiles[i].sprite = groundimg;
            }
        }

        for (int i = 0; i < tiles1.Length; i++)
        {
            if (-10 >= tiles1[i].transform.position.x)
            {
                for (int j = 0; j < tiles1.Length; j++)
                {
                    if (temp.transform.position.x < tiles1[j].transform.position.x)
                    {
                        temp = tiles1[j];
                    }
                }

                tiles1[i].transform.position = new Vector2(temp.transform.position.x + 1, -4.5f);
                tiles1[i].sprite = groundimg1;   
            }
        }



        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }
        for (int i = 0; i < tiles1.Length; i++)
        {
            tiles1[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }
    }
}
