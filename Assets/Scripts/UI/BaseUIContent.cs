using System;
using System.Collections;
using System.Collections.Generic;

namespace FUI {
    public class BaseUIContent : IFUI {

        protected string title;
        protected string content;

        protected Action closeCallback;


        public virtual void Close()
        {
            if(closeCallback != null)
            {
                closeCallback();
            }
        }

        public virtual void Show(string title, string content, Action cc)
        {
            this.title = title;
            this.content = content;
            closeCallback = cc;
        }
    }
}