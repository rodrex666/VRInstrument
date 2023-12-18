using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class PoseDetector : MonoBehaviour
{
    public List<ActiveStateSelector> poses;

    public TMPro.TextMeshPro text;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in poses)
        {
            item.WhenSelected += () => SetTextToPoseName(item.gameObject.name);
            item.WhenUnselected += () => SetTextToPoseName("");
        }
    }

    private void SetTextToPoseName(string newText)
    {
        text.text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
