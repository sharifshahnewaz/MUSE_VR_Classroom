using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorWalls : MonoBehaviour
{
    public Material m_Material;
    public int colorCounter;

    // Start is called before the first frame update
    void Start()
    {
        colorCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            colorCounter++;
            if (colorCounter > 4)
                colorCounter = 1;

            if (colorCounter == 1)
            {
                m_Material.color = Color.white;
            }
            if (colorCounter == 2)
            {
                m_Material.color = Color.grey;
            }
            if (colorCounter == 3)
            {
                m_Material.color = Color.yellow;
            }
            if (colorCounter == 4)
            {
                m_Material.color = Color.cyan;
            }
        }
    }
}