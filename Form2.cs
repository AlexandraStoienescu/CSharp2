using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace TextEditor
{
    public partial class Form2 : Form
    {
        private RichTextBox richTextBoxRecived;
        private ListBox listBox1FindLine;
        int  index = 0;
        

        public Form2(RichTextBox richTextBox,ListBox listBox1FindLine1)
        {
            this.richTextBoxRecived = richTextBox;
            this.listBox1FindLine = listBox1FindLine1;
            InitializeComponent();
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
            checkBox1.Visible = true;
            richTextBox1Find.Visible = true;
            richTextBox2Replace.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String temp = richTextBoxRecived.Text;
            richTextBoxRecived.SelectionStart = 0;
            richTextBoxRecived.SelectionLength = richTextBoxRecived.TextLength;
            richTextBoxRecived.SelectionBackColor = richTextBoxRecived.BackColor;

            index = richTextBoxRecived.Find(richTextBox1Find.Text, index, richTextBoxRecived.TextLength, RichTextBoxFinds.None);
            if (index != -1)
            {
                richTextBoxRecived.Find(richTextBox1Find.Text, index, richTextBoxRecived.TextLength, RichTextBoxFinds.None);
                richTextBoxRecived.SelectionBackColor = Color.Yellow;
                index = index + richTextBox1Find.Text.Length;
            }
          

        }

        private void button2_Click(object sender, EventArgs e)
        {

            index = 0;
            String temp = richTextBox1Find.Text;
            int i = richTextBoxRecived.Find(temp, index, richTextBoxRecived.TextLength, RichTextBoxFinds.MatchCase);

            while(i!= -1){

                richTextBoxRecived.SelectionStart = i;
                richTextBoxRecived.SelectionLength = temp.Length;
                richTextBoxRecived.SelectionBackColor = Color.Green;
                int line = richTextBoxRecived.GetLineFromCharIndex(i);
                listBox1FindLine.Items.Add("Line" + line + ":" + temp);
                index = i + temp.Length;
                if (index < richTextBoxRecived.TextLength)
                    i = richTextBoxRecived.Find(temp, index, richTextBoxRecived.TextLength, RichTextBoxFinds.MatchCase);
                else i = -1;

            }
           
        }

            private void button3_Click(object sender, EventArgs e)
        {

            String SearchFor = richTextBox1Find.Text;
            String ReplaceWith = richTextBox2Replace.Text;
            String text = richTextBoxRecived.Text;

            int Place = text.IndexOf(SearchFor);
            richTextBoxRecived.Text = text.Remove(Place, SearchFor.Length).Insert(Place, ReplaceWith);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String SearchFor = richTextBox1Find.Text;
            String ReplaceWith = richTextBox2Replace.Text;
            richTextBoxRecived.Text = richTextBoxRecived.Text.Replace(SearchFor, ReplaceWith);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                button3.Visible = true;
                button4.Visible = true;
                label2.Visible = true;
                richTextBox2Replace.Visible = true;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
                label1.Visible = true;
                label2.Visible = false;
                checkBox1.Visible = true;
                richTextBox2Replace.Visible = false;
            }
        }

        internal void button1_Click(object text)
        {
            throw new NotImplementedException();
        }

        private void button6_Click(object sender, EventArgs e)
        {
             
            FontDialog fontDialog1 = new FontDialog();
             
            DialogResult result = fontDialog1.ShowDialog();
             
            if (result == DialogResult.OK)
            {
                
                Font font = fontDialog1.Font;
              
                richTextBoxRecived.SelectionFont = font;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            if (cd.ShowDialog() == DialogResult.OK)
             {
          
            richTextBoxRecived.SelectionBackColor = cd.Color;
             }
        }
    }
 
}
