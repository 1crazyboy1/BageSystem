using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BageSystem.控件
{
   public class Frame: GroupBox
    {

        private string _text = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frame()
        {
            base.Text = "";
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("GroupBoxText")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get
            {

                return _text;
            }
            set
            {

                _text = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //first let the base class to draw the control 
            base.OnPaint(e);
            //create a brush with fore color
            SolidBrush colorBrush = new SolidBrush(this.ForeColor);
            //create a brush with back color
            var backColor = new SolidBrush(this.BackColor);
            //measure the text size
            var size = TextRenderer.MeasureText(this.Text, this.Font);
            // evaluate the postiong of text from left;
            int left = (this.Width - size.Width) / 2;
            //draw a fill rectangle in order to remove the border
            e.Graphics.FillRectangle(backColor, new Rectangle(left, 0, size.Width, size.Height));
            //draw the text Now
            e.Graphics.DrawString(this.Text, this.Font, colorBrush, new PointF(left, 0));
        }




    }
}
