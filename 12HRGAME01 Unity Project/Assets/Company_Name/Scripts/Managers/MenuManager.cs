using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
    }
}