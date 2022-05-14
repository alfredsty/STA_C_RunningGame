using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public GameObject[] maps; 

    int idx;
    Vector2 startPos = new Vector2(25.0f, -5.0f);

    public void NewMap()
    {
        Instantiate(maps[++idx % maps.Length], startPos, Quaternion.identity);
    }
}
