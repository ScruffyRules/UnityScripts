#if UNITY_EDITOR
using UnityEngine;

public class Notepad : MonoBehaviour {

    [TextArea(3, 25)]
    public string Notes;
}
#endif