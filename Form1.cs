using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool There_IS_Winner = false;
        int lineNumber = 0;

        bool turn = true;
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                turn_count++;
                Button b = (Button)sender;
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
                turn = !turn;
                b.Enabled = false;
                checkIsWin();
                if (turn_count == 9 && There_IS_Winner == false)
                {
                    MessageBox.Show("NO ONE WINS!!!");
                }
            }
            catch (Exception)
            {
                ClearButtons();
            }

            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Naji Salloum");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public bool CompareTwoButtonsTexts(Button b1, Button b2)
        {
            if (b1.Text == b2.Text)
                return true;
            else
                return false;
        }
        public bool CompareLineEnabled(Button a, Button b, Button c)
        {
            if (a.Enabled && b.Enabled && c.Enabled)
                return true;
            else
                return false;
        }
        public bool CompareLineTexts(Button a, Button b, Button c)
        {
            if ((a.Text == b.Text) && (b.Text == c.Text))
                return true;
            else
                return false;
        }
        public void checkIsWin()
        {
            bool isWin = false;
            if (CompareLineTexts(A1 , A2, A3) && !CompareLineEnabled(A1, A2, A3))
            {
                isWin = true;
                lineNumber = 1;
            }

            if (CompareLineTexts(B1, B2, B3) && !CompareLineEnabled(B1, B2, B3))
            {
                isWin = true;
                lineNumber = 2;
            }
            if (CompareLineTexts(C1, C2, C3) && !CompareLineEnabled(C1, C2, C3))
            {
                isWin = true;
                lineNumber = 3;
            };
            if (CompareLineTexts(A1, B1, C1) && !CompareLineEnabled(A1, B1, C1))
            {
                isWin = true;
                lineNumber = 4;
            }
            if (CompareLineTexts(A2, B2, C2) && !CompareLineEnabled(A2, B2, C2))
            {
                isWin = true;
                lineNumber = 5;
            }
            if (CompareLineTexts(A3, B3, C3) && !CompareLineEnabled(A3, B3, C3))
            {
                isWin = true;
                lineNumber = 6;
            }
            if (CompareLineTexts(A1, B2, C3) && !CompareLineEnabled(A1, B2, C3))
            {
                isWin = true;
                lineNumber = 7;
            }
            if (CompareLineTexts(A3, B2, C1) && !CompareLineEnabled(A3, B2, C1))
            {
                isWin = true;
                lineNumber = 8;
            }

            if (isWin)
            {
                SetLineColorAccordingNumber(lineNumber);
                There_IS_Winner = true;
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " wins !!" );
                SetAllButtonsEnabled(false);
            }


        }
        public void SetLineColor(Button a1, Button a2, Button a3, Color color)
        {
            SetButtonColor(a1, color);
            SetButtonColor(a2, color);
            SetButtonColor(a3, color);
        }
        public void SetLineColorAccordingNumber(int linenumber)
        {
            if (linenumber == 1)
            {
                SetLineColor(A1, A2, A3 , Color.Red);
            }

            if (linenumber == 2)
            {
                SetLineColor(B1, B2, B3, Color.Red);
            }
            if (linenumber == 3)
            {
                SetLineColor(C1, C2, C3, Color.Red);
            }

            if (linenumber == 4)
            {
                SetLineColor(A1, B1, C1, Color.Red);
            }

            if (linenumber == 5)
            {
                SetLineColor(A2, B2, C2, Color.Red);
            }

            if (linenumber == 6)
            {
                SetLineColor(A3, B3, C3, Color.Red);
            }
            if (linenumber == 7)
            {
                SetLineColor(A1, B2, C3, Color.Red);
            }
            if (linenumber == 8)
            {
                SetLineColor(A3, B2, C1, Color.Red);
            }


        }
        public void SetButtonColor(Button button, Color c)
        {
            button.BackColor = c;
        }
        public void SetAllButtonsColor(Color c)
        {
            SetButtonColor(A1, c); SetButtonColor(A2, c); SetButtonColor(A3, c);
            SetButtonColor(B1, c); SetButtonColor(B2, c); SetButtonColor(B3, c);
            SetButtonColor(C1, c); SetButtonColor(C2, c); SetButtonColor(C3, c);
        }
        public void SetButtonEnabled(Button button, bool enabled)
        {
            button.Enabled = enabled;
        }
        public void SetAllButtonsEnabled(bool enabled)
        {
            SetButtonEnabled(A1, enabled); SetButtonEnabled(A2, enabled); SetButtonEnabled(A3, enabled);
            SetButtonEnabled(B1, enabled); SetButtonEnabled(B2, enabled); SetButtonEnabled(B3, enabled);
            SetButtonEnabled(C1, enabled); SetButtonEnabled(C2, enabled); SetButtonEnabled(C3, enabled);
        }
        public void SetButtonText(Button button, string text)
        {
            button.Text = text;
        }
        public void SetAllButtonsText(string text)
        {
            SetButtonText(A1, text); SetButtonText(A2, text); SetButtonText(A3, text);
            SetButtonText(B1, text); SetButtonText(B2, text); SetButtonText(B3, text);
            SetButtonText(C1, text); SetButtonText(C2, text); SetButtonText(C3, text);
        }
        public void ClearButtons()
        {
            turn = true;
            turn_count = 0;
            There_IS_Winner = false;
            SetAllButtonsText("");
            SetAllButtonsEnabled(true);
            SetAllButtonsColor(Color.Gray);

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearButtons();
        }
    }
}
