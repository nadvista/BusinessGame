using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NodeCreator : MonoBehaviour
{
    //[SerializeField] Node node;
    [SerializeField] Transform spawner;
    [SerializeField] GameObject Node;
    [SerializeField] string nodeDescription;

    private GameObject aboutPanel;
    private TextMeshProUGUI aboutText;
    private void Start()
    {
        var m = Camera.main.GetComponent<Game>();
        aboutPanel = m.aboutPanel;
        aboutText = m.aboutText;
    }
    public void DoubleClick ()
    {

    }

    public void ShowAbout()
    {
        aboutPanel.SetActive(true);
        aboutText.SetText(nodeDescription);
    }
    public void HideAbout()
    {
        aboutPanel.SetActive(false);
    }
}
