using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace FalloutPNP_PipBoy
{
    public class CustomControls
    {
        public class VerticalButton : Button
        {
            private Orientation mOrientation = Orientation.Horizontal;
            private int mTextMargin = 5;
            private int mImageMargin = 5;
            private int mImageScalingPercent = 100;
            private System.Windows.Forms.VisualStyles.PushButtonState mState = System.Windows.Forms.VisualStyles.PushButtonState.Normal;

            #region Props
            [Category("Appearance")]
            [DefaultValue(5)]
            public int TextMargin
            {
                get { return mTextMargin; }
                set { mTextMargin = value; }
            }
            [Category("Appearance")]
            [DefaultValue(5)]
            public int ImageMargin
            {
                get { return mImageMargin; }
                set { mImageMargin = value; }
            }
            [Category("Appearance")]
            [DefaultValue(Orientation.Horizontal)]
            public Orientation Orientation
            {
                get { return mOrientation; }
                set { mOrientation = value; }
            }
            [Category("Appearance")]
            [DefaultValue(100)]
            public int ImageScalingPercent
            {
                get { return mImageScalingPercent; }
                set { mImageScalingPercent = value; }
            }

            #endregion


            #region Mouse Events
            protected override void OnMouseDown(MouseEventArgs mevent)
            {
                base.OnMouseDown(mevent);
                mState = System.Windows.Forms.VisualStyles.PushButtonState.Pressed;
                Invalidate();
            }

            protected override void OnMouseUp(MouseEventArgs mevent)
            {
                base.OnMouseUp(mevent);
                mState = System.Windows.Forms.VisualStyles.PushButtonState.Hot;
                Invalidate();
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                mState = System.Windows.Forms.VisualStyles.PushButtonState.Normal;
                Invalidate();
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                mState = System.Windows.Forms.VisualStyles.PushButtonState.Hot;
                Invalidate();
            }
            #endregion


            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);

                if (mOrientation == Orientation.Horizontal)
                    return;

                // Base Button Draw
                if (mState == System.Windows.Forms.VisualStyles.PushButtonState.Pressed)
                {
                    // Set the background color to the parent if visual styles  
                    // are disabled, because DrawParentBackground will only paint  
                    // over the control background if visual styles are enabled.
                    this.BackColor = Application.RenderWithVisualStyles ?
                        Color.Azure : this.Parent.BackColor;

                    // If you comment out the call to DrawParentBackground, 
                    // the background of the control will still be visible 
                    // outside the pressed button, if visual styles are enabled.
                    ButtonRenderer.DrawParentBackground(pevent.Graphics,
                        ClientRectangle, this);
                    ButtonRenderer.DrawButton(pevent.Graphics, this.ClientRectangle,
                        "", this.Font, true, mState);
                }
                else
                {
                    // Draw the bigger unpressed button image.
                    ButtonRenderer.DrawButton(pevent.Graphics, ClientRectangle,
                        "", this.Font, false, mState);
                }

                // Draw Text
                if (this.Text != "")
                    this.DrawText(pevent.Graphics);

                // Draw Image
                if (this.Image != null)
                    this.DrawImage(pevent.Graphics);
            }

            private void DrawText(System.Drawing.Graphics pGraphics)
            {
                // Calc size of text (la func devuelve el size horizontal)
                SizeF sizeOfText = pGraphics.MeasureString(this.Text, this.Font);
                float temp = sizeOfText.Width;
                sizeOfText.Width = sizeOfText.Height;
                sizeOfText.Height = temp;

                // Calc X coord of Text            
                float x = mTextMargin;
                switch (this.TextAlign)
                {
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.BottomCenter:
                        x = (this.Width / 2) - (sizeOfText.Width / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.TopRight:
                        x = this.Width - mTextMargin - sizeOfText.Width;
                        break;
                }

                // Calc Y coord of Text
                float y = mTextMargin;
                switch (this.TextAlign)
                {
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        y = this.Height - mTextMargin - sizeOfText.Height;
                        break;
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleRight:
                        y = (this.Height / 2) - (sizeOfText.Height / 2);
                        break;
                }

                // Draw text
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(this.ForeColor);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                pGraphics.DrawString(this.Text, this.Font, drawBrush, x, y, drawFormat);
                drawBrush.Dispose();
            }

            private void DrawImage(System.Drawing.Graphics pGraphics)
            {
                float imageScaling = (float)mImageScalingPercent / 100f;
                float finalWidth = (float)this.Image.Width * imageScaling;
                float finalHeight = (float)this.Image.Height * imageScaling;
                float halfFinalWidth = finalWidth / 2f;
                float halfFinalHeight = finalHeight / 2f;

                float x = mImageMargin;
                float y = mImageMargin;
                switch (this.ImageAlign)
                {
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.BottomCenter:
                        x = (this.Width / 2f) - halfFinalWidth;
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.TopRight:
                        x = this.Width - mImageMargin - finalWidth;
                        break;
                }
                switch (this.ImageAlign)
                {
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        y = this.Height - mImageMargin - finalHeight;
                        break;
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleRight:
                        y = (this.Height / 2f) - halfFinalHeight;
                        break;
                }
                System.Drawing.Drawing2D.Matrix rotMat = new System.Drawing.Drawing2D.Matrix();
                PointF rotationCenter = new PointF(x + halfFinalWidth, y + halfFinalHeight);
                rotMat.RotateAt(90, rotationCenter);
                pGraphics.Transform = rotMat;

                System.Drawing.Rectangle destRect = new Rectangle((int)x, (int)y, (int)finalWidth, (int)finalHeight);
                System.Drawing.Rectangle srcRect = new Rectangle(0, 0, this.Image.Width, this.Image.Height);
                pGraphics.DrawImage(this.Image, destRect, srcRect, GraphicsUnit.Pixel);
            }


        }

    }
}
