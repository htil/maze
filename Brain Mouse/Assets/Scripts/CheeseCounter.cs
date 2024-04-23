using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheeseCounter : MonoBehaviour
{
    public static CheeseCounter Instance;
    public TMP_Text cheeseText;
    public int currentCheese = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCheeseText();
    }

    public void IncreaseCheese(int v)
    {
        currentCheese += v;
        UpdateCheeseText();
    }

    void UpdateCheeseText()
    {
        cheeseText.text = "Points: " + currentCheese.ToString();
    }
}
