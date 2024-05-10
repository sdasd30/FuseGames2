using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class HealthContainer : MonoBehaviour
{
    Image[] hearts;
    Attackable playerattackable;
    public Sprite fullContainer;
    public Sprite emptyContainer;

    int currentHealth;

    private void Start()
    {
        playerattackable = FindObjectOfType<SpaceshipController>().GetComponent<Attackable>();
        hearts = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerattackable.hitpoints )
            {
                hearts[i].sprite = fullContainer;
            }
            else
            {
                hearts[i].sprite = emptyContainer;
            }
        }
    }

}
