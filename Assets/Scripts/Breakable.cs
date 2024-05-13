using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    [SerializeField] private List<GameObject> breakablePieces;

    [SerializeField] private float timeToBreak = 2;
    private float timer = 0;

    public UnityEvent OnBreak;

    private void Start()
    {
        foreach (var piece in breakablePieces)
        {
            piece.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if (timer > timeToBreak)
        {
            foreach (var piece in breakablePieces)
            {
                piece.SetActive(true);
                piece.transform.SetParent(null);
            }

            OnBreak.Invoke();
            gameObject.SetActive(false);
        }
    }
}
