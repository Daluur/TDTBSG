using System;

namespace FUI
{
    public class DoubleButtonUI : BaseUIContent
    {
        Action acceptCallback;
        string accept;
        string decline;

        public void Show(string title, string content, string accept, string decline, Action cc, Action ac)
        {
            this.title = title;
            this.content = content;
            this.accept = accept;
            this.decline = decline;
            closeCallback = cc;
            acceptCallback = ac;
        }

        public void Accept()
        {
            if(acceptCallback != null)
            {
                acceptCallback();
            }
        }

    }
}