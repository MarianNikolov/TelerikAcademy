using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Queue<int> sequensceOfNumbers = new Queue<int>();

            sequensceOfNumbers.Enqueue(22);
            sequensceOfNumbers.Enqueue(44);
            sequensceOfNumbers.Enqueue(66);
            sequensceOfNumbers.Enqueue(88);
            sequensceOfNumbers.Enqueue(108);
            this.textBox1.Text += "Показване на пет числа:\r\n";
            this.textBox1.Text += string.Join("\r\n", sequensceOfNumbers); 

            sequensceOfNumbers.Dequeue();
            sequensceOfNumbers.Dequeue();

            sequensceOfNumbers.Enqueue(222);
            sequensceOfNumbers.Enqueue(333);
            sequensceOfNumbers.Enqueue(444);

            this.textBox1.Text += "\r\n\r\nПремахване на две числа\r\nи добавяне на нови три:";
            this.textBox1.Text += string.Join("\r\n", sequensceOfNumbers);

        }
    }
}
