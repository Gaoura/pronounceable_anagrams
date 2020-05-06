using UnityEngine;
using UnityEngine.UI;


public class UIPathUpdater : MonoBehaviour
{
    [SerializeField]
    private StringReference path;

    [SerializeField]
    private Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = path.value;
    }
}
