using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_de_pro;
using You_Win;
using Perdedor;
using System.Media;
using System.Windows.Forms;

namespace Windowsentregar
{
    public partial class planilla : Form
    {
        ClaseProyecto tab;
        int dimensiones;
        public planilla() 
        {
            InitializeComponent();
            fondo.Focus();
            dimensiones = int.Parse(size.Text);
            tab = new ClaseProyecto(dimensiones);
        }
        #region pintando 
        private void fondo_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brocha1 = new SolidBrush(Color.FromArgb(10, Color.Black));
            Graphics artista = e.Graphics;
            Pen lapiz = new Pen(Color.Azure,2);
            float tamaño = fondo.Width / dimensiones;
            for (int i = 0; i < dimensiones; i++)//recorre para pintar dependiendo de la posicion
            {
                for (int j = 0; j < dimensiones; j++)
                {
                    artista.FillRectangle(brocha1, i * tamaño, j * tamaño, tamaño, tamaño);
                    artista.DrawRectangle(lapiz, i * tamaño, j * tamaño, tamaño, tamaño);
                    
                     if (tab.Tablero[i, j] == 2)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\2.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 4)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\4.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 8)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\8.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 16)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\16.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 32)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\32.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 64)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\64.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 128)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\128.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 256)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\256.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 512)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\512.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 1024)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\1024.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 2048)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\2048.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 4096)
                        artista.DrawImage(Image.FromFile(@"..\..\Imagenes\4096.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 8192)
                         artista.DrawImage(Image.FromFile(@"..\..\Imagenes\8192.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                     if (tab.Tablero[i, j] == 16384)
                         artista.DrawImage(Image.FromFile(@"..\..\Imagenes\16384.PNG"), j * tamaño, i * tamaño, tamaño, tamaño);
                    
                         if ( tab.Tablero[i, j] == 2048 && tab.count == 0)
                         {
                             Form Victoria = new Ganador();//muestra un form
                             Victoria.ShowDialog();
                             tab.count++;
                         }
                     
                     
                     
                }
            }
        }
#endregion
        #region MOViendose

        private void planilla_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var x = e.KeyCode;
            switch (x)
            {
                case Keys.Down: tab.Abajo(); fondo.Invalidate(); break;
                case Keys.Left: tab.Izquierda(); fondo.Invalidate(); break;
                case Keys.Right: tab.Derecha(); fondo.Invalidate(); break;
                case Keys.Up: tab.Arriba(); fondo.Invalidate(); break;
                case Keys.Back: undoToolStripMenuItem_Click(sender, null); break;
                default: break;
            }
            puntos.Text = Convert.ToString(tab.score);
            if (tab.BestScore < tab.score)
            {
                tab.BestScore = tab.score;
                mejorpunto.Text = Convert.ToString(tab.BestScore);
            }

            if (tab.Perdiste())
            {
                Form Badluck = new Lose();
                Badluck.ShowDialog();
                tab.Iniciar(dimensiones);
                fondo.Invalidate();
            }
                
        }

        #endregion
        #region EMpezar
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab.Iniciar(dimensiones);//inicia el tablero
            mejorpunto.Text = Convert.ToString(tab.BestScore);
            puntos.Text = Convert.ToString(tab.score);
            fondo.Invalidate();
        }
        #endregion
        #region REcomenzar
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab.SaveBestScore();
            tab.Iniciar(dimensiones);
            fondo.Invalidate();
        }
       #endregion
        #region UNdo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tab.salvatab.Count > 0)
            {
                tab.Tablero = (int[,])tab.salvatab.Pop().Clone();
                tab.score = tab.salvascore.Pop();
                puntos.Text = Convert.ToString(tab.score);
                fondo.Invalidate();
            }
            else
                MessageBox.Show("No es posible seguir hacia atras");
                 


        }
        #endregion
        #region CArgar
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tab.CargarGame();
                tab.LoadStacks();
                fondo.Invalidate();
            }
            catch 
            {
                MessageBox.Show("No hay partidas guardadas intenta salvar primero");
            }
            
        }
        
        #endregion
        #region SAlvar
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab.SaveStacks();
            tab.GuardarGame();
            fondo.Invalidate();
        }
#endregion
        #region HElp
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizado por Manuel Inc con el apoyo especial del Team Silver y weboo");
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mueva convenientemente los controles de Arriba,Abajo,Derecha,Izquierda ");
        }
        #endregion
        #region Tamaño
        private void size_TextChanged(object sender, EventArgs e)
        {
            dimensiones = int.Parse(size.Text);
        }
        #endregion
     
        
        #region bestScore
        private void mejorpunto_TextChanged(object sender, EventArgs e)
        {
            mejorpunto.Text = Convert.ToString(tab.BestScore);
        }
        #endregion
        #region sCORE
        private void puntos_TextChanged(object sender, EventArgs e)
        {
            puntos.Text = Convert.ToString(tab.score);
        }
        #endregion
        #region Cerrar
        private void planilla_FormClosed(object sender, FormClosedEventArgs e)
        {
            tab.SaveBestScore();
        }
        #endregion


    }
}
