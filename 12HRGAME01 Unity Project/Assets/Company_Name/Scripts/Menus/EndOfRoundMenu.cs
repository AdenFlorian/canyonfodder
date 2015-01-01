using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndOfRoundMenu : MonoBehaviour
{
    public Text uiText;
    private string startText;

    private void Start()
    {
        startText = uiText.text;
    }

    private void Update()
    {
        uiText.text = startText + Projectile.Instance.distance;
    }
}