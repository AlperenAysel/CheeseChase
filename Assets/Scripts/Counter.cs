using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int moveCounter = 0;

    private void Update()
    {
        counterText.text = "Adım Sayısı:" + (moveCounter / 20).ToString();
    }

    private void FixedUpdate()
    {
        if (transform.hasChanged)
        {
            moveCounter++;
            transform.hasChanged = false;
        }
    }
}
