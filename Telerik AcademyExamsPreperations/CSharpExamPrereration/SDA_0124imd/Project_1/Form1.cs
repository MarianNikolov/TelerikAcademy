using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] CreateArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i + 1;
            }

            return array;

        }

        public void Swap<T>(T[] arr, int index1, int index2)
        {
            T temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] numbers = this.CreateArray(6);
            for (int i = 0; i < numbers.Length; i++)
            {
                this.textBox1.Text += "number at index " + i + " - " + numbers[i].ToString() + "\r\n";
            }
            this.Swap(numbers, 0, 5);
            this.Swap(numbers, 1, 4);
            this.Swap(numbers, 2, 3);

            this.textBox1.Text += "-------------\r\n";
            for (int i = 0; i < numbers.Length; i++)
            {
                this.textBox1.Text += "number at index " + i + " - " + numbers[i].ToString() + "\r\n";
            }
            //this is array with strings 
            string[] texts = new string[] { "This is String", "This is another String" };
            this.Swap(texts, 0, 1);
            this.textBox1.Text += "----------------\r\n";

            texts.ToList().ForEach(c => this.textBox1.Text += c + "\r\n");
            this.textBox1.Text += "-------------\r\n";




        }

        private void colectionBTN_Click(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>();
            numbers.Add(33);
            numbers.Add(12);
            numbers.Add(3);
            numbers.Add(123);
            numbers.Add(4653);
            numbers.Add(22);
            numbers.Add(7);
            numbers.Add(541);
            numbers.Add(-55);
            numbers.Add(68);
             
            for (int i = 0; i < numbers.Count; i++)
            {
                this.textBox1.Text += "number at index " + i + " - " + numbers[i].ToString() + "\r\n";
                
            }
            this.textBox1.Text += "----------------\r\n";
        }

    }

}
