using UnityEngine.Events;

namespace UI.ResultWindow
{
    public interface IUIResultWindow
    {
        UnityEvent RestartPressed { get; }
    }
}