using System;

namespace FUI
{
    public interface IFUI
    {
        void Close();
        void Show(string title, string content, Action cc);
    }
}