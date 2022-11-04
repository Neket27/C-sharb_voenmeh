using System.Drawing.Printing;

namespace WinFormsAppPrintCat;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    Graphics g;
    private  void Form1_Paint(object sender, PaintEventArgs e)
    {
        //const string HELLO_WORLD = "Привет Мир!!!";
        //SizeF messageSize = e.Graphics.MeasureString(HELLO_WORLD, Font);
        //PointF p = new PointF((ClientSize.Width-messageSize.Width)/2, (ClientSize.Height-messageSize.Height)/2);
        //e.Graphics.DrawString(HELLO_WORLD, Font, SystemBrushes.WindowText, p);

        g= CreateGraphics();
        g.Clear(Color.Aqua);
        g.DrawEllipse(Pens.Blue, 100,100,300,300);

    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";
     }

    #endregion
}