using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
       int nForm,ID;
       Socket server;

       delegate void DelegadoParaEscribir(string mensaje);
       delegate void DelegadoParaActualizarLista(string[] trozos);
       

        public Form2(int nForm, Socket server,int ID)
        {
            InitializeComponent();
            this.nForm = nForm;
            this.server = server;
            this.ID = ID;
        }

        private void Consulta_Button_Click_1(object sender, EventArgs e)
            //Se envía al servidor la petición de hacer una consulta con sus códigos correspondientes
            //y toda la información necesaria
        {
            if (Record.Checked) 
            {
                string mensaje = "3/" + nForm;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            else if (Personajes.Checked)
            {
                if (this.ID_Partida.Text == null)
                    MessageBox.Show("Debes indicar la partida que quieres consultar");
                else
                {
                    string mensaje = "4/" + nForm + "/" + this.ID_Partida.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                this.ID_Partida.Text = null;
            }

            else if (Partidas.Checked)
            {
                if (this.ID_Jugador.Text == null)
                    MessageBox.Show("Debes indicar el jugador sobre el que quieres hacer la consulta)");
                else
                {
                    string mensaje = "5/" + nForm + "/" + this.ID_Jugador.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                this.ID_Jugador.Text = null;
            }

            else if (Resultados.Checked)
            {
                if (this.ID_jugador_2.Text == null)
                    MessageBox.Show("Debes indicar el jugador sobre el que quieres hacer la consulta");
                else
                {
                    if (this.ID == Convert.ToInt32(this.ID_jugador_2.Text))
                        MessageBox.Show("No puedas buscar los resultados contra ti mismo");
                    else
                    {
                        string mensaje = "13/" + nForm + "/" + this.ID + "/" + this.ID_jugador_2.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                }
                this.ID_jugador_2.Text = null;
            }

            else if (Tiempo.Checked)
            {
                if ((this.Fecha_Inicio.Text == null) || (this.Fecha_Final.Text == null))
                    MessageBox.Show("Asegurate de rellenar bien todos los campos");
                else
                {
                    string mensaje = "14/" + nForm + "/" + this.Fecha_Inicio.Text + "/" + this.Fecha_Final.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                this.Fecha_Inicio.Text = null;
                this.Fecha_Final.Text = null;
                
            }

            else
                MessageBox.Show("Selecciona una opcion para hacer tu consulta");
        }

        public void TomaRespuesta(string [] trozos)
            //Procesamos las respuestas del servidor a las consultas según su código
        {
            int codigo = Convert.ToInt32(trozos[0]);
            string mensaje=null;
            
            DelegadoParaEscribir delegado = new DelegadoParaEscribir(ActualizaMensaje);
            DelegadoParaActualizarLista delegado_consultas_caso5 = new DelegadoParaActualizarLista(PonLista1);
            DelegadoParaActualizarLista delegado_consultas_caso14 = new DelegadoParaActualizarLista(PonLista2);
            DelegadoParaActualizarLista delegado_consultas_caso13 = new DelegadoParaActualizarLista(PonLista3);
            DelegadoParaActualizarLista delegado_consultas_caso4 = new DelegadoParaActualizarLista(PonLista4);

            switch (codigo)
            {
                case 3: 
                    //codigo/nform/mensaje
                    mensaje = trozos[2].Split('\0')[0]; 
                    Mensaje_label.Invoke(delegado, new object[] { mensaje });
                    break;
                case 4:
                    //codigo/nform/num de personajes/personaje1/personaje2
                    Consulta_Grid.Invoke(delegado_consultas_caso4, new object[] { trozos });
                    break;
                case 5:
                    //codigo/nform/num partidas/id partida-nombre del rival-resultado
                    Consulta_Grid.Invoke(delegado_consultas_caso5, new object[] { trozos });
                    break;
                case 13:
                    //codigo/nform/num partidas/id partida-jugadores-ganador/id partida-...
                    Consulta_Grid.Invoke(delegado_consultas_caso13, new object[] { trozos });
                    break;
                case 14:
                    //codigo/nform/num partidas/id partida-resultado/id partida-...
                    Consulta_Grid.Invoke(delegado_consultas_caso14, new object[] { trozos });
                    break;
            }
        }

        private void ActualizaMensaje(string mensaje)
        {
            this.Mensaje_label.Text=mensaje;
            this.Consulta_Grid.Visible = false;
        }

        private void PonLista1(string[] trozos)
        //codigo/nform/num partidas/id partida-nombre del rival-resultado
        {
            // El numero de partidas está en el trozo 1
            int n = Convert.ToInt32(trozos[2]);
            if (n == 0)
                this.Mensaje_label.Text = "Este jugador no ha jugado ninguna partida";
            else if (n == -1)
                this.Mensaje_label.Text = "Este jugador no existe";
            else
            {
                this.Consulta_Grid.ColumnCount = 3;
                this.Consulta_Grid.RowCount = n + 1;

                this.Consulta_Grid.Rows[0].Cells[0].Value = "ID partida";
                this.Consulta_Grid.Rows[0].Cells[1].Value = "Rivales";
                this.Consulta_Grid.Rows[0].Cells[2].Value = "Resultado";

                for (int i = 0; i < n; i++)
                {
                    string[] mensaje = trozos[i + 3].Split('-');
                    this.Consulta_Grid.Rows[i + 1].Cells[0].Value = mensaje[0];
                    this.Consulta_Grid.Rows[i + 1].Cells[1].Value = mensaje[1];
                    this.Consulta_Grid.Rows[i + 1].Cells[2].Value = mensaje[2];
                }

                this.Mensaje_label.Text = "Ha jugado " + n + " partidas";
                this.Consulta_Grid.Visible = true;
            }
        }

        private void PonLista2(string[] trozos)
        //codigo/nform/num partidas/id partida-jugadores-ganador/id partida...
        {
            // El numero de partidas está en el trozo 1
            int n = Convert.ToInt32(trozos[2]);
            if (n == 0)
                this.Mensaje_label.Text = "No hay ninguna partida que coincida con tu consulta.";
            else
            {
                this.Consulta_Grid.ColumnCount = 3;
                this.Consulta_Grid.RowCount = n + 1;
                Consulta_Grid.Rows[0].Cells[0].Value = "ID partida";
                Consulta_Grid.Rows[0].Cells[1].Value = "Jugadores";
                Consulta_Grid.Rows[0].Cells[2].Value = "Ganador";
                for (int i = 0; i < n; i++)
                {
                    string[] mensaje = trozos[i + 3].Split('-');
                    Consulta_Grid.Rows[i + 1].Cells[0].Value = mensaje[0];
                    Consulta_Grid.Rows[i + 1].Cells[1].Value = mensaje[1];
                    Consulta_Grid.Rows[i + 1].Cells[2].Value = mensaje[2];
                }
                this.Consulta_Grid.Visible = true;
            }
        }

        private void PonLista4(string[] trozos)
        //codigo/nform/num personajes/lista
        {
            int n = Convert.ToInt32(trozos[2]);
            if (n == 0)
                this.Mensaje_label.Text = "No se han encontrado datos de esta partida";
            else
            {
                this.Consulta_Grid.ColumnCount = 2;
                this.Consulta_Grid.RowCount = n;

                for (int i = 0; i < n; i++)
                {
                    Consulta_Grid.Rows[i].Cells[0].Value = "Personaje " + (i + 1).ToString();

                    if (trozos[3 + i] != "0")
                        Consulta_Grid.Rows[i].Cells[1].Value = trozos[3 + i];
                    else
                        Consulta_Grid.Rows[i].Cells[1].Value = "No escogió personaje";
                }

                this.Mensaje_label.Text = "Se escogieron los siguientes personaje:";
            }
            this.Consulta_Grid.Visible = true;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Mensaje_label.Text = null;
        }

        private void PonLista3(string[] trozos)
        //codigo/num form/num partidas/ID partida-resultado
        {

            int n = Convert.ToInt32(trozos[2]);
            this.Consulta_Grid.ColumnCount = 2;
            this.Consulta_Grid.RowCount = n + 1;

            this.Consulta_Grid.Rows[0].Cells[0].Value = "ID partida";
            this.Consulta_Grid.Rows[0].Cells[1].Value = "Resultado";

            if (n == 0)
                this.Mensaje_label.Text = "No has jugado ninguna partida con este usuario";
            else
            {
                for (int i = 0; i < n; i++)
                {
                    string[] mensaje = trozos[i + 3].Split('-');
                    this.Mensaje_label.Text = mensaje[0] + " " + mensaje[1];
                    this.Consulta_Grid.Rows[i + 1].Cells[0].Value = mensaje[0];
                    this.Consulta_Grid.Rows[i + 1].Cells[1].Value = mensaje[1];
                }

                this.Mensaje_label.Text = "Estos son tus resultados:";
                this.Consulta_Grid.Visible = true;
            }

           
        }
    }
}
