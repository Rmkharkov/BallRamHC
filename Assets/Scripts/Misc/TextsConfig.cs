using System.Collections.Generic;
using UnityEngine;

namespace Misc
{
    [CreateAssetMenu(fileName = "TextsConfig", menuName = "Configs/TextsConfig", order = 0)]
    public class TextsConfig : ScriptableObject
    {
        private static TextsConfig _instance;

        public static TextsConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<TextsConfig>("TextsConfig");
                }

                return _instance;
            }
        }

        [SerializeField] private List<TextItem> texts = new List<TextItem>();

        public string GetText(EText textType)
        {
            var toReturn = texts.Find(c => c.textId == textType);

            return toReturn.textValue;
        }
    }
}