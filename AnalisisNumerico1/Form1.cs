﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Logica;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisisNumerico1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void TxtFuncion_TextChanged(object sender, EventArgs e)
        {

        }

       
        // ----------------------------------------------------------------------------------------------------//

        private void BtnObtener_1_Click(object sender, EventArgs e)
        {
            if ((txt_Iter.Text.Trim() == string.Empty) || (txt_Tole.Text.Trim() == string.Empty) || 
                (txt_LI.Text.Trim() == string.Empty) || (txt_LD.Text.Trim() == string.Empty) || (txt_Funcion.Text.Trim() == string.Empty))
            {
                if ((txt_Iter.Text.Trim() == string.Empty))
                    txt_Iter.BackColor = Color.Red;
                if ((txt_Tole.Text.Trim() == string.Empty))
                    txt_Tole.BackColor = Color.Red;
                if ((txt_LI.Text.Trim() == string.Empty))
                    txt_LI.BackColor = Color.Red;
                if ((txt_LD.Text.Trim() == string.Empty))
                    txt_LD.BackColor = Color.Red;
                if ((txt_Funcion.Text.Trim() == string.Empty))
                    txt_Funcion.BackColor = Color.Red;
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                Resultado nuevo = Logica.Unidad1.Actividad1.Biseccion(txt_Funcion.Text,int.Parse(txt_Iter.Text), 
                        double.Parse(txt_Tole.Text),float.Parse(txt_LI.Text), float.Parse(txt_LD.Text));
                if (!nuevo.SePudo)
                {
                    MessageBox.Show(nuevo.Mensaje);
                }
                else
                {
                    lbl_Iter_1.Text = nuevo.Iter.ToString();
                    lbl_Tole_1.Text = nuevo.Tole.ToString();
                    lbl_Solucion_1.Text = nuevo.Solucion.ToString();
                }
            }
        }// OBTENER CON EL METODO DE BISECCION

        private void BtnObtener_2_Click(object sender, EventArgs e)
        {
            if ((txt_Iter.Text.Trim() == string.Empty) || (txt_Tole.Text.Trim() == string.Empty) ||
                (txt_LI.Text.Trim() == string.Empty) || (txt_LD.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Campos Vacios");
                if ((txt_Iter.Text.Trim() == string.Empty))
                    txt_Iter.BackColor = Color.Red;
                if ((txt_Tole.Text.Trim() == string.Empty))
                    txt_Tole.BackColor = Color.Red;
                if ((txt_LI.Text.Trim() == string.Empty))
                    txt_LI.BackColor = Color.Red;
                if ((txt_LD.Text.Trim() == string.Empty))
                    txt_LD.BackColor = Color.Red;
            }
            else
            {
                Resultado nuevo = Logica.Unidad1.Actividad1.ReglaFalsa(txt_Funcion.Text, int.Parse(txt_Iter.Text), double.Parse(txt_Tole.Text),
                    float.Parse(txt_LI.Text), float.Parse(txt_LD.Text));
                if (!nuevo.SePudo)
                {
                    MessageBox.Show(nuevo.Mensaje);
                }
                else
                {
                    lbl_Ite_2.Text = nuevo.Iter.ToString();
                    lbl_Tole_2.Text = nuevo.Tole.ToString();
                    lbl_Solu_2.Text = nuevo.Solucion.ToString();
                }
            }      
        } //OBTENER CON EL METODO DE LA REGLA FALSA.
        
        private void BtnObtener_3_Click(object sender, EventArgs e)
        {
            if ((txt_Iter.Text.Trim() == string.Empty) || (txt_Tole.Text.Trim() == string.Empty) ||
                (txt_LI.Text.Trim() == string.Empty) || (txt_Funcion.Text.Trim() == string.Empty))
            {
                if ((txt_Iter.Text.Trim() == string.Empty))
                    txt_Iter.BackColor = Color.Red;
                if ((txt_Tole.Text.Trim() == string.Empty))
                    txt_Tole.BackColor = Color.Red;
                if ((txt_LI.Text.Trim() == string.Empty))
                    txt_LI.BackColor = Color.Red;
                if ((txt_LD.Text.Trim() == string.Empty))
                    txt_LD.BackColor = Color.Red;
                if ((txt_Funcion.Text.Trim() == string.Empty))
                    txt_Funcion.BackColor = Color.Red;
                MessageBox.Show("Campos Vacios");
            }
            else
            {
                Resultado nuevo = Logica.Unidad1.Actividad1.Tangente(txt_Funcion.Text, int.Parse(txt_Iter.Text),
                        double.Parse(txt_Tole.Text), float.Parse(txt_LI.Text));
                if (!nuevo.SePudo)
                {
                    MessageBox.Show(nuevo.Mensaje);
                }
                else
                {
                    lbl_Ite_3.Text = nuevo.Iter.ToString();
                    lbl_Tole_3.Text = nuevo.Tole.ToString();
                    lbl_Solu_3.Text = nuevo.Solucion.ToString();
                }
            }
        }//OBTENER CON EL METODO DE LA TANGENTE

        private void Txt_LI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 && chr != 44 && chr != 45)
            {
                e.Handled = true;
                //MessageBox.Show("Solo Numeros");
            }
        } //CON ESTO CONTROLO QUE SOLO SE INGRESEN NUMEROS
        private void Txt_LD_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 && chr != 44 && chr != 45)
            {
                e.Handled = true;
            }
        } //SOLO NUMEROS
        private void Txt_Tole_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 && chr != 46)
            {
                e.Handled = true;
            }
        }//SOLO NUMEROS
        private void Txt_Iter_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }//SOLO NUMEROS



        private void Txt_Tole_Click(object sender, EventArgs e)
        {
            txt_Tole.BackColor = Color.White;
        } //PONE EL TEXTBOX EN BLANCO
        private void Txt_Iter_Click(object sender, EventArgs e)
        {
            txt_Iter.BackColor = Color.White;
        } //PONE EL TEXTBOX EN BLANCO
        private void Txt_LI_Click(object sender, EventArgs e)
        {
            txt_LI.BackColor = Color.White;
        }  //PONE EL TEXTBOX EN BLANCO
        private void Txt_LD_Click(object sender, EventArgs e)
        {
            txt_LD.BackColor = Color.White;
        }  //PONE EL TEXTBOX EN BLANCO
        private void Txt_Funcion_Click(object sender, EventArgs e)
        {
            txt_Funcion.BackColor = Color.White;
        }  // PONE EL TEXTBOX EN BLANCO
    }
}