using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace SharpGram
{
    public partial class FrmLogin : Form
    {
        #region Graphics
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
         );
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, 
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public FrmLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            lblUser.ForeColor = ColorTranslator.FromHtml("#5E646A");
            lblPass.ForeColor = ColorTranslator.FromHtml("#5E646A");
            lblLogin.BackColor = ColorTranslator.FromHtml("#66BD2B");
            lblLogin.ForeColor = Color.White;
            lblClose.BackColor = ColorTranslator.FromHtml("#66BD2B");
            lblClose.ForeColor = Color.White;
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Pen Pen = new Pen(ColorTranslator.FromHtml("#66BD2B"));
            DrawRoundRect(v, Pen, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 1);
            base.OnPaint(e);
        }

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            Brush Brush = new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#66BD2B"));
            g.FillPath(Brush, gp);
            gp.Dispose();
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com/");
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin(txtUser.Text, txtPass.Text);
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            DoLogin(txtUser.Text, txtPass.Text);
        }

        public void DoLogin(string Username, string Password)
        {
            Bot.MainFunction();
            if (Bot.Login(Username, Password))
            {
                FrmMain newMain = new FrmMain();
                newMain.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Wrong Username or Password!");
        }
    }
}