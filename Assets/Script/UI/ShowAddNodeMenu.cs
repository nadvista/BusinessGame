using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAddNodeMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] SwipeMove[] movers;
    private void Start()
    {
        movers = GameObject.FindObjectsOfType<SwipeMove>();
    }
    private void OnMouseDown()
    {
        menu.SetActive(!menu.activeSelf);
        foreach (var a in movers)
            a.isLocked = menu.activeSelf;
    }
}
