using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Multiplier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int SIZE = 3;
        int Count = 0;
        int[,,] Matrix = new int[100, SIZE, SIZE];

        //Matrix Multiplication
        private int[,] Multiply(int a,int b)
        {
            int[,] temp = new int[SIZE, SIZE];

            for(int k = 0; k < SIZE; k++)
            {
                for(int i = 0; i < SIZE; i++)
                {
                    for(int j = 0; j < SIZE; j++)
                    {
                        temp[i, j] += Matrix[a, k, j] * Matrix[b, j, k];
                    }
                }
            }
            return temp;
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            int n = 0;
            for(int i = 0; i < SIZE; i++)
            {
                for(int j = 0; j < SIZE; j++)
                {
                    string val = (tlpTxt.Controls[n] as TextBox).Text;
                    int.TryParse(val, out Matrix[Count, i, j]);
                    (tlpTxt.Controls[n++] as TextBox).Clear();
                }
            }
            Count++;
            txt1.Focus();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int p = 0;
            btnMul_Click(null, null);

            //matrix multiplication
            for(int n = 1; n < Count; n++)
            {
                int[,] temp = Multiply(0, n);

                for(int i = 0; i < SIZE; i++)
                {
                    for(int j = 0; j < SIZE; j++)
                    {
                        Matrix[0, i, j] = temp[i, j];
                    }
                }
            }

            //answer matrix send to the textboxses
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    (tlpTxt.Controls[p++] as TextBox).Text = Matrix[0, i, j].ToString();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int p = 0;

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    (tlpTxt.Controls[p++] as TextBox).Clear();
                }
            }
        }
    }
}
