using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class NumberCollection : BaseCollection
        {
            private List<int> list;

            public NumberCollection()
            {
                this.List = new List<int>();
            }

            public List<int> List
            {
                get
                {
                    return this.list;
                }

                set
                {
                    this.list = value;
                }
            }

            public int this[int index]
            {
                get
                {
                    return (int)this.List[index];
                }
            }

            public int Count
            {
                get
                {
                    return this.list.Count;
                }
            }

            public void Add(int value)
            {
                this.List.Add(value);

            }

            public void Remove(int value)
            {
                this.List.Remove(value);
            }

            public int IndexOf(int index)
            {
                return (int)this.List.IndexOf(index);

            }

            public bool Contains(int value)
            {
                return this.List.Contains(value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberCollection numbers = new NumberCollection();
            numbers.Add(34);
            numbers.Add(-55);
            numbers.Add(3);
            numbers.Add(-77);
            numbers.Add(41);
            numbers.Add(-12);
            numbers.Add(90);

            this.textBox1.Text += string.Join(" / ", numbers.List);

            this.textBox1.Text += "\r\n\r\nСлед премахване на -77:";
            numbers.Remove(-77);

            this.textBox1.Text += "\r\n" + string.Join(" / ", numbers.List);

            this.textBox1.Text += "\r\n\r\nДобавяне на числото 1000:";
            numbers.Add(1000);

            this.textBox1.Text += "\r\n" + string.Join(" / ", numbers.List);

            bool contains = numbers.Contains(1000);

            this.textBox1.Text += "\r\n\r\nСъдържа ли се числото 1000?:";

            this.textBox1.Text += "\r\n" + contains;

            int index = numbers.IndexOf(3);

            this.textBox1.Text += "\r\n\r\nИндексът на числото 3 е:" + index;



 




            this.textBox1.Text += "\r\n\r\n";

        }


    }
}
