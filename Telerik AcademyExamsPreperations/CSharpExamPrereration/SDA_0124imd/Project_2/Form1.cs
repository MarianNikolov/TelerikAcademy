using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string word = this.textBox1.Text;
            Stack<char> lettersOfWord = new Stack<char>();
            for (int i = 0; i < word.Length; i++)
            {
                lettersOfWord.Push(word[i]);
            }

            string result = "";
            
            while (lettersOfWord.Count > 0)
            {
                result += lettersOfWord.Pop();
    
            }

            this.textBox2.Text = result;

            if (result == word)
            {
                this.textBox2.Text += "\r\n" + "Думата е палиндром!";
            }

            else
            {
                this.textBox2.Text += "\r\n" + "Думата не е палиндром!";

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
