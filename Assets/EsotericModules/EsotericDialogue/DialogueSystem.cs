using UnityEngine;

namespace EsotericUtilities.Dialogue
{
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField] TextAsset DialogueFile;
        private void Start()
        {
           string content = DialogueFile.ToString();
        }
    }
}
