using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHelper : MonoBehaviour
{
    [SerializeField] Transform alter, player;
    float distance = 0;
    [SerializeField] TMP_Text distanceUI;


    private void Update()
    {
        distance = Vector3.Distance(player.position, alter.position);
        distanceUI.text = $"Distance to alter: \n{(int)distance}";
    }
}
