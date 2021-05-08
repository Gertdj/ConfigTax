using System;
using System.Drawing;
using System.Windows.Forms;

public class DateTimePickerEx : DateTimePicker
{
    private const int WM_PAINT = 0x000F;
    private Color m_ErrorBorderColor = Color.Red;
    private bool m_IsValidDateTime = true;

    public DateTimePickerEx() { }

    public Color ErrorBorderColor
    {
        get => m_ErrorBorderColor;
        set
        {
            if (m_ErrorBorderColor != value)
            {
                m_ErrorBorderColor = value;
                this.Invalidate();
            }
        }
    }

    public bool IsValidDateTime
    {
        get => m_IsValidDateTime;
        private set
        {
            m_IsValidDateTime = value;
            this.Invalidate();
        }
    }

    public void ValidateDateTimeValue()
    {
        bool isValid = true;
        // Validate the new Value. e.g.
        if (this.ShowCheckBox && !this.Checked)
        {
            // A placeholder sub-condition: the Text is can only appear empty when 
            // setting a CustomFormat  = " "
            if (this.Text.Trim() == string.Empty)
            {
                isValid = false;
            }
        }
        // Set the results of the validation to the property.
        // This will also set the Border Color
        IsValidDateTime = isValid;
    }

    protected override void OnValueChanged(EventArgs e)
    {
        base.OnValueChanged(e);
        if (!this.IsHandleCreated) return;
        ValidateDateTimeValue();
    }

    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_PAINT:
                base.WndProc(ref m);
                if (!m_IsValidDateTime)
                {
                    using (var g = Graphics.FromHwnd(m.HWnd))
                    {
                        var rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                        g.DrawRectangle(Pens.Red, rect);
                    }
                    m.Result = IntPtr.Zero;
                }
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }
}
