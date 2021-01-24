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
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        int nForm, ID_partida,num;
        string[] rivales=new string[MAX];
        int resolver = 0;
        int seleccionado = 0;
        Socket server;
        string nombre = null;
        int personaje_seleccionado = 0;
        int personaje_resolver = 0;
        int duracion;
        string fecha, hora;
        static int MAX=4;
        string nombre_rival;

        string fechayhora;

        int Cerrar = 0;
        string directorio = "C:/Users/mirei/OneDrive/Documents/UNI/2B/SO/Quien es quien/Cliente/QuienEsQuien/QuienEsQuien/bin/Debug/Fotos/";

        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaCerrar();


        public class CLista_Personajes
        {
            public int num = 15;
            public CPersonaje[] personaje;
        }

        public CLista_Personajes lista_personajes = new CLista_Personajes();

        public Form3 (int nForm, int ID_partida,string nombre,  Socket server, int num, string [] rivales)
        {
            InitializeComponent();

            this.nForm = nForm;
            this.ID_partida = ID_partida;
            this.server = server;
            this.nombre = nombre;
            this.num = num;
            this.rival.Text = "";
            this.nombre_lbl.Text = nombre;

            this.rival.Text = "Participantes:";
            this.jugador_personaje_grid.RowCount = num;
            this.jugador_personaje_grid.ColumnCount = 1;

            for (int j = 0; j < num; j++)
            {
                this.rivales[j] = rivales[j];
                this.rival.Text = this.rival.Text +" "+ this.rivales[j];
                this.jugador_personaje_grid.Rows[j].Cells[0].Value = this.rivales[j];
            }


            this.Text = "Partida " + nForm;

            lista_personajes.personaje = new CPersonaje[16];
            int i = 0;
            while (i < 16)
            {
                lista_personajes.personaje[i] = new CPersonaje();
                i = i + 1;
            }
            rellenar_tabla_fotos(lista_personajes);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            duracion = 0;
            timer.Enabled = true;

            fechayhora = DateTime.Now.ToString();
            string[] fyh = fechayhora.Split(' ');
            fecha = fyh[0];
            hora = fyh[1];
        }

        public class CPersonaje
        {
            public string nombre, foto, foto_byn;
            public int byn; // cuando sea 0 la foto estara normal y cuando sea 1 en blanco y negro
        }

        public void rellenar_tabla_fotos(CLista_Personajes lista)
        {

            lista.personaje[1].nombre = "Emma";
            lista.personaje[2].nombre = "Antonia";
            lista.personaje[3].nombre = "Javi";
            lista.personaje[4].nombre = "Cristina_R";
            lista.personaje[5].nombre = "Julen";
            lista.personaje[6].nombre = "Arnau";
            lista.personaje[7].nombre = "Victor";
            lista.personaje[8].nombre = "Mireia";
            lista.personaje[9].nombre = "David";
            lista.personaje[10].nombre = "Gabri";
            lista.personaje[11].nombre = "Andrea";
            lista.personaje[12].nombre = "Enric";
            lista.personaje[13].nombre = "Izan";
            lista.personaje[14].nombre = "Angela";
            lista.personaje[15].nombre = "Cristina_B";

            for (int i = 1; i < 16; i++)
            {
                lista.personaje[i].foto = directorio + lista.personaje[i].nombre + ".jpg";
                lista.personaje[i].foto_byn = directorio + lista.personaje[i].nombre + "_byn.jpg";
            }

            panel_Emma.BackgroundImage = Image.FromFile(@lista.personaje[1].foto);
            panel_Antonia.BackgroundImage = Image.FromFile(@lista.personaje[2].foto);
            panel_Javi.BackgroundImage = Image.FromFile(@lista.personaje[3].foto);
            panel_Cristina_R.BackgroundImage = Image.FromFile(@lista.personaje[4].foto);
            panel_Julen.BackgroundImage = Image.FromFile(@lista.personaje[5].foto);
            panel_Arnau.BackgroundImage = Image.FromFile(@lista.personaje[6].foto);
            panel_Victor.BackgroundImage = Image.FromFile(@lista.personaje[7].foto);
            panel_Mireia.BackgroundImage = Image.FromFile(@lista.personaje[8].foto);
            panel_David.BackgroundImage = Image.FromFile(@lista.personaje[9].foto);
            panel_Gabri.BackgroundImage = Image.FromFile(@lista.personaje[10].foto);
            panel_Andrea.BackgroundImage = Image.FromFile(@lista.personaje[11].foto);
            panel_Enric.BackgroundImage = Image.FromFile(@lista.personaje[12].foto);
            panel_Izan.BackgroundImage = Image.FromFile(@lista.personaje[13].foto);
            panel_Angela.BackgroundImage = Image.FromFile(@lista.personaje[14].foto);
            panel_Cristina_B.BackgroundImage = Image.FromFile(@lista.personaje[15].foto);
        }

        public void Chat(string mensaje)
        {
            this.Chat_listBox.Items.Add(mensaje);
        }

        public void TomaRespuesta(string[] trozos)
        {
            int codigo = Convert.ToInt32(trozos[0]);
            string mensaje = null;
            byte[] msg = null;
            DelegadoParaEscribir delegado = new DelegadoParaEscribir(Chat);
            //DelegadoParaCerrar d = new DelegadoParaCerrar(Cerrar_form);
            
            switch (codigo)
            {
                case 9:
                    mensaje = trozos[2].Split('\0')[0];
                    Chat_listBox.Invoke(delegado, new object[] { mensaje });
                    break;

                case 10:
                    break;

                case 11:
                    break;

                case 12:
                    mensaje=trozos[2].Split('\0')[0];
                    switch (Convert.ToInt32(mensaje))
                    {
                        case 0:
                            MessageBox.Show("Has fallado. Pierdes");
                            Cerrar = 1;
                            //this.Invoke(d);
                            break;
                        case 1:
                            MessageBox.Show("Has acertado, enhorabuena crack");
                            mensaje = "10/" + this.ID_partida + "/" + this.nombre + "/" + this.fecha + "/" + this.hora + "/" + this.duracion+"/"+this.num;
                            msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                            Cerrar = 1;
                            //this.Invoke(d);
                            break;
                        case 2:
                            MessageBox.Show(trozos[3].Split('\0')[0] + " ha acertado un personaje. Lo siento, has perdido");
                            Cerrar = 1;
                            //this.Invoke(d);
                            break;
                        case 3:
                            MessageBox.Show(trozos[3].Split('\0')[0]+" ha intentado adivinar un personaje y ha fallado");
                            break;
                        case 4:
                            MessageBox.Show("Todos los demás han sido eliminados, ¡has ganado!");

                            mensaje = "10/" + this.ID_partida + "/" + this.nombre + "/" + this.fecha + "/" + this.hora + "/" + this.duracion + "/" + this.num;
                            msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                            Cerrar = 1;
                            //this.Invoke(d);
                            break;
                    }
                    break;

                case 15:
                    MessageBox.Show(trozos[2].Split('\0')[0] + " ha abandonado la partida.");
                    break;
            }
        }
        
        private void Cerrar_form()
        {
            this.Close();
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            string msj = "9/" + ID_partida + "/" + nombre + ": " + this.Chat_TextBox.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
            server.Send(msg);
            
            string texto_chat = "Tú: " + this.Chat_TextBox.Text;
            this.Chat_listBox.Items.Add(texto_chat);

            this.Chat_TextBox.Text = null;
        }

        private void Resolver_Click(object sender, EventArgs e)
        {
            this.resolver = 1;
            this.Resolver_groupBox.Visible = true;
        }

        private void Seleccionar_button_Click(object sender, EventArgs e)
        {
            if (this.personaje_seleccionado == 0)
                MessageBox.Show("Debes seleccionar primero tu personaje");
            else
            {
                seleccionado = 1;

                string mensaje = "11/" + ID_partida + "/" + this.personaje_seleccionado;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            if (personaje_resolver == 0)
                MessageBox.Show("Debes seleccionar un personaje antes de resolver");
            else if (personaje_textBox == null)
                MessageBox.Show("Debes indicar de quien crees que es ese personaje");
            else
            {
                int encontrado=0;
                if (nombre_rival == nombre)
                {
                  MessageBox.Show("No te puedes elegir a ti mismo");
                  encontrado = 1;
                }

                else
                {
                   string mensaje = "12/" + ID_partida + "/" + nombre_rival + "/" + personaje_resolver;
                   byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                   server.Send(msg);
                  encontrado = 1;
                }

                if (encontrado == 0)
                    MessageBox.Show("No has escrito bien el nombre de tu rival");
            }
            this.personaje_textBox.Text = null;
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.resolver = 0;
            this.Resolver_groupBox.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            duracion++;
            Duracion_label.Text = duracion.ToString();
        }

        private void jugador_personaje_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            nombre_rival= rivales[fila];
            this.personaje_textBox.Text = nombre_rival ;
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Cerrar == 0)
            {
                string mensaje = "15/" + ID_partida;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }
       
        private void Emma_button_Click_1(object sender, EventArgs e)
        {
            if (seleccionado == 0)
            {
                personaje_seleccionado = 1;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = 1;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[1].byn == 0)
                {
                    this.panel_Emma.BackgroundImage = Image.FromFile(@lista_personajes.personaje[1].foto_byn);
                    lista_personajes.personaje[1].byn = 1;
                }
                else
                {
                    this.panel_Emma.BackgroundImage = Image.FromFile(@lista_personajes.personaje[1].foto);
                    lista_personajes.personaje[1].byn = 0;
                }
            }
        }

        private void Antonia_button_Click_1(object sender, EventArgs e)
        {
            if (seleccionado == 0)
            {
                personaje_seleccionado = 2;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = 2;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[2].byn == 0)
                {
                    this.panel_Antonia.BackgroundImage = Image.FromFile(@lista_personajes.personaje[2].foto_byn);
                    lista_personajes.personaje[2].byn = 1;
                }
                else
                {
                    this.panel_Antonia.BackgroundImage = Image.FromFile(@lista_personajes.personaje[2].foto);
                    lista_personajes.personaje[2].byn = 0;
                }
            }
        }

        private void Javi_button_Click_1(object sender, EventArgs e)
        {
            if (seleccionado == 0)
            {
                personaje_seleccionado = 3;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = 3;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[3].byn == 0)
                {
                    this.panel_Javi.BackgroundImage = Image.FromFile(@lista_personajes.personaje[3].foto_byn);
                    lista_personajes.personaje[3].byn = 1;
                }
                else
                {
                    this.panel_Javi.BackgroundImage = Image.FromFile(@lista_personajes.personaje[3].foto);
                    lista_personajes.personaje[3].byn = 0;
                }
            }
        }

        private void CristinaR_button_Click_1(object sender, EventArgs e)
        {
            if (seleccionado == 0)
            {
                personaje_seleccionado = 4;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = 4;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[4].byn == 0)
                {
                    this.panel_Cristina_R.BackgroundImage = Image.FromFile(@lista_personajes.personaje[4].foto_byn);
                    lista_personajes.personaje[4].byn = 1;
                }
                else
                {
                    this.panel_Cristina_R.BackgroundImage = Image.FromFile(@lista_personajes.personaje[4].foto);
                    lista_personajes.personaje[4].byn = 0;
                }
            }
        }

        private void Julen_button_Click_1(object sender, EventArgs e)
        {
            if (seleccionado == 0)
            {
                personaje_seleccionado = 5;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = 5;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[5].byn == 0)
                {
                    this.panel_Julen.BackgroundImage = Image.FromFile(@lista_personajes.personaje[5].foto_byn);
                    lista_personajes.personaje[5].byn = 1;
                }
                else
                {
                    this.panel_Julen.BackgroundImage = Image.FromFile(@lista_personajes.personaje[5].foto);
                    lista_personajes.personaje[5].byn = 0;
                }
            }
        }

        private void Arnau_button_Click_1(object sender, EventArgs e)
        {
            if (seleccionado == 0)
            {
                personaje_seleccionado = 6;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = 6;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[6].byn == 0)
                {
                    this.panel_Arnau.BackgroundImage = Image.FromFile(@lista_personajes.personaje[6].foto_byn);
                    lista_personajes.personaje[6].byn = 1;
                }
                else
                {
                    this.panel_Arnau.BackgroundImage = Image.FromFile(@lista_personajes.personaje[6].foto);
                    lista_personajes.personaje[6].byn = 0;
                }
            }
        }

        private void Victor_button_Click_1(object sender, EventArgs e)
        {
            if (seleccionado == 0)
            {
                personaje_seleccionado = 7;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = 7;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[7].byn == 0)
                {
                    this.panel_Victor.BackgroundImage = Image.FromFile(@lista_personajes.personaje[7].foto_byn);
                    lista_personajes.personaje[7].byn = 1;
                }
                else
                {
                    this.panel_Victor.BackgroundImage = Image.FromFile(@lista_personajes.personaje[7].foto);
                    lista_personajes.personaje[7].byn = 0;
                }
            }
        }

        private void Mireia_button_Click_1(object sender, EventArgs e)
        {
            int numero = 8;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_Mireia.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_Mireia.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

        private void David_Button_Click_1(object sender, EventArgs e)
        {
            int numero = 9;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_David.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_David.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

        private void Gabri_button_Click_1(object sender, EventArgs e)
        {
            int numero = 10;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }
            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_Gabri.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_Gabri.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

        private void Andrea_button_Click_1(object sender, EventArgs e)
        {
            int numero = 11;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_Andrea.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_Andrea.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

        private void Enric_button_Click_1(object sender, EventArgs e)
        {
            int numero = 12;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_Enric.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_Enric.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

        private void Izan_button_Click_1(object sender, EventArgs e)
        {
            int numero = 13;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_Izan.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_Izan.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

        private void Angela_button_Click_1(object sender, EventArgs e)
        {
            int numero = 14;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_Angela.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_Angela.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

        private void CristinaB_button_Click_1(object sender, EventArgs e)
        {
            int numero = 15;

            if (seleccionado == 0)
            {
                personaje_seleccionado = numero;
                this.panel_Seleccionado.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_seleccionado].foto);
            }

            else if (resolver == 1)
            {
                personaje_resolver = numero;
                this.panel_Resolver.BackgroundImage = Image.FromFile(@lista_personajes.personaje[personaje_resolver].foto);
            }

            else
            {
                if (lista_personajes.personaje[numero].byn == 0)
                {
                    this.panel_Cristina_B.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto_byn);
                    lista_personajes.personaje[numero].byn = 1;
                }
                else
                {
                    this.panel_Cristina_B.BackgroundImage = Image.FromFile(@lista_personajes.personaje[numero].foto);
                    lista_personajes.personaje[numero].byn = 0;
                }
            }
        }

    }
}
