using System.Drawing;

namespace ControlExs
{ 
    //按钮事件委托
    public delegate void MouseDownEventHandler();

    internal class SystemButton
    {
        public SystemButtonState State { get; set; }
        public Rectangle LocationRect { get; set; }
        public Image NormalImg { get; set; }
        public Image HighLightImg { get; set; }
        public Image DownImg { get; set; }
        public string ToolTip { get; set; }

        public event MouseDownEventHandler OnMouseDownEvent;
        public void OnMouseDown()
        {
            if (OnMouseDownEvent != null)
            {
                OnMouseDownEvent();
            }
        }
    }
}
