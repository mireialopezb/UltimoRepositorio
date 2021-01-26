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
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        int conectado = 0;
        int ID_jugador,ID_partida;
        string nombre;
        static int MAX_jugadores=4;
        string id_invitacion;

        string [] rivales=new string [MAX_jugadores];
        
        int cont=0;

        delegate void DelegadoParaPasarMensaje(string mensaje);
        delegate void DelegadoParaActualizarLista(string[] trozos);
        delegate void DelegadoParaActualizarInvitaciones();

        int port = 9090;
        string ip = "192.168.1.50";
        List<string> jugadores_dosCdos = new List<string>();
        string[] conectados;

        public class CPartida
        {
            public int ID, nForm,num,tiempo;
            public string nombre,id_invitacion;
            public string [] rivales=new string[MAX_jugadores];
            
        }

        public class CInvitacion
        {
            public string estado, rival, id, aceptadas;
            public int remitente,tiempo;
        }

        List<CPartida> listaPartidas = new List<CPartida>();
        List<CInvitacion> listaInvitaciones = new List<CInvitacion>();
        List<Form2> f2 = new List<Form2>();
        List<Form3> f3 = new List<Form3>();

        delegate void DelegadoParaCrearFormulario();

        public Form1()
        {
            InitializeComponent();
        }

        private void Iniciar_sesion_Click(object sender, EventArgs e)
        {
            groupBox_inciar.Visible = true;
            groupBox_inciar.Text = "Iniciar sesión";
            Registrarse_Button.Visible = false;
            Iniciar_Button.Visible = true;
            Baja_button.Visible = false;
        }

        private void Registrarse_Click(object sender, EventArgs e)
        {
            groupBox_inciar.Visible = true;
            groupBox_inciar.Text = "¿No tienes cuenta? Regístrate";
            Registrarse_Button.Visible = true;
            Iniciar_Button.Visible = false;
            Baja_button.Visible = false;
        }

        private void Iniciar_Button_Click(object sender, EventArgs e)
            //coge el el nombre y contraseña introducidos por el cliente
            // y lo envia al servidor para iniciar sesión
        {
            if (conectado == 0)
            {
                IPAddress direc = IPAddress.Parse(ip);
                IPEndPoint ipep = new IPEndPoint(direc, port);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);
                    conectado = 1;
                }
                catch (SocketException)
                {
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }

            if ((this.Nombre.Text == null) || (this.Contraseña.Text == null))
                MessageBox.Show("No se han rellenado correctamente todos los campos");
            else
            {
                nombre = this.Nombre.Text;

                string msj = "1/" + this.Nombre.Text + "/" + this.Contraseña.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }

            this.Nombre.Text = null;
            this.Contraseña.Text = null;

        }

        private void Registrarse_Button_Click(object sender, EventArgs e)
            //coge el el nombre y contraseña introducidos por el cliente
            // y lo envia al servidor para registrarse
        {
            if (conectado == 0)
            {
                IPAddress direc = IPAddress.Parse(ip);
                IPEndPoint ipep = new IPEndPoint(direc, port);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);
                    conectado = 1;
                }
                catch (SocketException)
                {
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }

            if ((this.Nombre.Text == null) || (this.Contraseña.Text == null))
                MessageBox.Show("No se han rellenado correctamente todos los campos");
            else
            {
                nombre = this.Nombre.Text;
                string msj = "2/" + this.Nombre.Text + "/" + this.Contraseña.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }

            this.Nombre.Text = null;
            this.Contraseña.Text = null;
        }

        private void PonerEnMarchaFormulario2()
            //creamos un nuevo form2 (formulario para hacer consultas)
        {
            int cont = f2.Count;
            Form2 f = new Form2(cont, server,ID_jugador);
            f2.Add(f);
            f.ShowDialog();
        }

        private void PonerEnMarchaFormulario3()
            //creamos un nuevo form3 (nueva partida)
            //añadimos la lista de la lista de partidas y eliminamos 
            // la invitación de la lista de invitaciones
        {
            int j = 0;

            if (Invitados_textBox.Text == null)
            {
                MessageBox.Show("Tienes que seleccionar la partida que quieres iniciar");
                
            }
            else
            {
                int encontrado = -1;
                while (j < listaPartidas.Count)
                {
                    if (listaPartidas[j].id_invitacion == id_invitacion)
                    {
                        encontrado = j;
                    }
                    
                    j++;
                }

                if (encontrado != -1)
                {
                    for (j = 0; j < listaInvitaciones.Count; j++)
                        if (listaInvitaciones[j].id == id_invitacion)
                            listaInvitaciones.RemoveAt(j);

                    int cont = f3.Count;

                    Form3 f = new Form3(cont, listaPartidas[encontrado].ID, this.nombre, server, listaPartidas[encontrado].num, listaPartidas[encontrado].rivales);

                    listaPartidas[encontrado].nForm = cont;

                    f3.Add(f);
                    f.ShowDialog(); 
                }
            }

            DelegadoParaActualizarInvitaciones delegado = new DelegadoParaActualizarInvitaciones(ActualizaInvitaciones);
            Invitacion_Grid.Invoke(delegado);

        }

       delegate void DelegadoParaPonerUsuario();

       private void ActualizaInvitaciones()
       {
           this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
           this.Invitacion_Grid.ColumnCount = 3;

           for (int j = 0; j < listaInvitaciones.Count; j++)
           {
               this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].id;
               this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].rival;
               this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
           }
       }

        private void PonUsuario()
            //actualizamos el label del usuario (indicamos su numbre y su id)
            //si se ha iniciado sesión correctamente
            //ponemos visibles e invisibles los elementos del form1 necesarios
        {
            this.Usuario_lbl.Text = "Usuario: " + nombre + "\n ID: " + ID_jugador;
            this.groupBox_inciar.Visible = false;
            this.Usuario_lbl.Visible = true;
            this.Iniciar_sesion.Visible = false;
            this.Registrarse.Visible = false;
            this.Dar_baja.Visible = false;
            this.Conectados_groupBox.Visible = true;
            this.Invitaciones_groupBox.Visible = true;
            this.QuererConsulta.Visible = true;
            this.Ayuda.Visible = true;
            this.Desconectar.Visible = true;
        }

        private void AtenderServidor()
            //el cliente recibe los mensajes del servidor y los procesa según el código
        {
            while (true)
            {
                byte[] msg2 = new byte[1000];
                server.Receive(msg2);

                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');

                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje;
                int nform;

                switch (codigo)
                {
                    case 1: //Iniciar sesion
                        //La respuesta sera 0 si no se ha encontrado el usuario en labase de datos, sinó enviara su ID
                        mensaje = trozos[1].Split('\0')[0];
                        if (mensaje == "0")
                            MessageBox.Show("Este usuario no existe, comprueba que lo has escrito bien.");
                        else
                        {
                            ID_jugador = Convert.ToInt32(mensaje);
                            DelegadoParaPonerUsuario d = new DelegadoParaPonerUsuario(PonUsuario);
                            Usuario_lbl.Invoke(d);
                        }
                        break;

                    case 2: // Registrarse
                        //La respuesta será 0 si se ha encontrado el usuario en labase de datos, sinó enviara su ID
                        mensaje = trozos[1].Split('\0')[0];
                        if (mensaje == "0")
                            MessageBox.Show("Este usuario ya existe");
                        else
                        {
                            ID_jugador = Convert.ToInt32(mensaje);
                           // MessageBox.Show("Te has registrado correctamente, tu ID de jugador es: " + mensaje);
                            DelegadoParaPonerUsuario d = new DelegadoParaPonerUsuario(PonUsuario);
                            Usuario_lbl.Invoke(d);
                        }
                        break;

                    case 3: // quien tiene el record
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;

                    case 4: //qué personajes se han escogido
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;

                    case 5: //cuantas partidas ha jugado un jugador
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;

                    case 6: //notificación para actualizar la lista de conectados
                        DelegadoParaActualizarLista delegado_conectados = new DelegadoParaActualizarLista(Actualiza_Grid_Conectados);
                        Conectados_Grid.Invoke(delegado_conectados, new object[] { trozos });
                        break;
                    case 7: //al cliente le llega una nueva invitación
                        DelegadoParaActualizarLista delegado_invitaciones = new DelegadoParaActualizarLista(NuevaInvitacion);
                        Invoke(delegado_invitaciones, new object[] { trozos });
                        break;
                    case 8: // al cliente le llega información sobre una invitación 
                        DelegadoParaActualizarLista delegado_invitaciones_respuesta = new DelegadoParaActualizarLista(RespuestaInvitacion);
                        Invoke(delegado_invitaciones_respuesta, new object[] { trozos });
                        break;
                    case 9: //mensaje por el chat
                            //9/id de la partida/mensaje
                        ID_partida = Convert.ToInt32(trozos[1]);
                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        if (nform != -1)
                            f3[nform].TomaRespuesta(trozos);
                        break;
                    case 11:
                        ID_partida = Convert.ToInt32(trozos[1]);

                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        if (nform != -1)
                            f3[nform].TomaRespuesta(trozos);
                        break;
                    case 12: //alguien intenta adivinar un personaje
                        ID_partida = Convert.ToInt32(trozos[1]);
                        
                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;
                        if(nform!=-1)
                            f3[nform].TomaRespuesta(trozos);
                        break;
                    case 13: //consulta los resultados del usuario con otro jugador
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;
                    case 14: //lista de partidas en un tiempo determinado
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;
                    case 15: //un jugador se ha desconectado de la partida
                        ID_partida = Convert.ToInt32(trozos[1]);
                        
                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        if (nform != -1)
                            f3[nform].TomaRespuesta(trozos);
                        break;
                    case 16: //darse de baja
                        int respuesta = Convert.ToInt32(trozos[1]);
                        if (respuesta == 1)
                            MessageBox.Show("Tu usuario se ha eliminado correctamente");
                        else
                            MessageBox.Show("Este usuario no existe, comprueba que lo has escrito bien.");
                        break;
                }
            }
        }

        private void QuererConsulta_Click(object sender, EventArgs e)
            //creamos el thread para poder hacer consultas
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario2(); };
            Thread T = new Thread(ts);
            T.Start();
        }

        public void Actualiza_Grid_Conectados(string[] trozos)
            //actualiza la lista de conectados cada vez que se conecte un usuario
        {
            int num_conectados = Convert.ToInt32(trozos[1]);
            string mensaje = trozos[2].Split('\0')[0];

            this.Conectados_Grid.ColumnCount = 1;
            this.Conectados_Grid.RowCount = num_conectados;

            conectados = mensaje.Split(',');

            for (int i = 0; i < num_conectados; i++)
                this.Conectados_Grid.Rows[i].Cells[0].Value = conectados[i];
        }

        private void Invitar_Click(object sender, EventArgs e)
            //enviamos el mensaje al servidor indicando que queremos hacer una nueva invitación
        {
            string msj=null;
            string rival = null;
            string estado;

            this.Invitaciones_groupBox.Visible = true;

            if (listaInvitaciones.Count == 0)
            {
                CInvitacion i = new CInvitacion();

                estado = "Estado";
                string id = "ID";
                rival = "Rivales";

                i.rival = rival;
                i.id = id;
                i.estado = estado;
                i.tiempo = 61;

                listaInvitaciones.Add(i);
            }
            
            if(cont==0)
                MessageBox.Show("Selecciona a quien quieras invitar");
            else
            {
                msj="7/"+cont;
                for(int j=0; j<cont;j++)
                {
                    msj=msj+"/"+rivales[j];
                    rival=rival+", "+rivales[j];
                }

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }

            for (int n = 0; n < cont; n++)
                rivales[n] = null;
            cont = 0;
            this.Invitados_textBox.Text = null;
            
        }

        private void Conectados_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            if(cont>MAX_jugadores)
            {
            rivales[cont] = conectados[fila];

            this.Invitados_textBox.Text = this.Invitados_textBox.Text+", "+rivales[cont];
            cont++;
            }
            else
                MessageBox.Show("Ya no puedes invitar a más jugadores");
        }

        private void Desconectar_Click(object sender, EventArgs e)
            //enviamos un mensaje al servidor para que cierre la conexión
            //y nos desconectamos
        {
            string msj = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
            server.Send(msg);
            conectado = 0;

            atender.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            conectado = 0;

            this.groupBox_inciar.Visible = false;
            this.Usuario_lbl.Visible = false;
            this.Iniciar_sesion.Visible = true;
            this.Registrarse.Visible = true;
            this.Dar_baja.Visible = true;
            this.Conectados_groupBox.Visible = false;
            this.Invitaciones_groupBox.Visible = false;
            this.QuererConsulta.Visible = false;
            this.Ayuda.Visible = false;
            this.Desconectar.Visible = false;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Invitados_textBox.Text = null;
            for (int n = 0; n < cont; n++)
                rivales[n] = null;
            cont = 0;
        }

        private void aceptar_button_Click(object sender, EventArgs e)
            //enviamos un mensaje al servidor indicando que aceptamos la invitación
        {
            string msj=null;
            string id=null;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                if (listaInvitaciones[j].id == this.Invitacion_textBox.Text)
                    if (listaInvitaciones[j].remitente == 1)
                    {
                        id = this.Invitacion_textBox.Text;
                        listaInvitaciones[j].remitente = 2;
                    }
                    else if (listaInvitaciones[j].remitente == 0)
                        MessageBox.Show("No puedes aceptar tu propia invitación");
                    else
                        MessageBox.Show("Ya has aceptado esta invitación");
            }

            if (id != null)
            {
                msj = "8/" + id + "/1";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }
            this.Iniciar_Button.Visible = true;
        }

        private void rechazar_button_Click(object sender, EventArgs e)
            //enviamos un mensaje al servidor indicando que rechazamos la invitación
            //y la eliminamos de la lista de invitaciones
        {
            string msj = null;
            string id = null;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                if (listaInvitaciones[j].id == this.Invitacion_textBox.Text)
                    id = this.Invitacion_textBox.Text;
            }

            if (id != null)
            {
                msj = "8/" + id + "/0";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }
            
            this.Iniciar_Button.Visible = true;
            this.Invitacion_textBox.Text = null;
            /*
            for (int j = 0; j < listaInvitaciones.Count; j++)
                if (listaInvitaciones[j].id == id)
                    listaInvitaciones.RemoveAt(j);*/


            this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
            this.Invitacion_Grid.ColumnCount = 3;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].id;
                this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].rival;
                this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
            }
        }

        private void NuevaInvitacion(string [] trozos)
            //Añade una nueva invitación a la lista de invitaciones cuando te invitan a una partida
        {
            int codigo = Convert.ToInt16(trozos[0]);
            string rival;
            string estado;
            this.timer_invitar.Enabled = true;
            this.Invitaciones_groupBox.Visible = true;

            if (listaInvitaciones.Count == 0)
            {
                CInvitacion i = new CInvitacion();
               
                estado = "Estado";
                string id = "ID";
                rival = "Rivales";
                     
                i.rival = rival;
                i.id = id;
                i.estado = estado;
                i.tiempo = 61;

                listaInvitaciones.Add(i);
            }

            CInvitacion a = new CInvitacion();

            estado = "Esperando tu respuesta";
            a.rival = trozos[2].Split('\0')[0];
            a.estado = estado;
            a.id = trozos[1];
            a.tiempo = 0;
            a.remitente = 1; //te han invitado

            listaInvitaciones.Add(a);

            this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
            this.Invitacion_Grid.ColumnCount = 3;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].id;
                this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].rival;
                this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
            }

        }

        private void RespuestaInvitacion(string[] trozos)
            //Actualiza el estado de una invitación cuando responde un jugador
        {
            ID_partida = Convert.ToInt32(trozos[1]);
            int id_invitacion = Convert.ToInt32(trozos[2].Split('\0')[0]);

            if (ID_partida == 0)//han rechazado la invitacion
            {
                MessageBox.Show("Se ha cancelado la partida "+id_invitacion.ToString());
                for (int j = 0; j < listaInvitaciones.Count; j++)
                    if (listaInvitaciones[j].id == id_invitacion.ToString())
                        listaInvitaciones.RemoveAt(j);
            }
            else if (ID_partida==-1)
            {
                int encontrado = 0;
                for (int j = 0; j < listaInvitaciones.Count; j++)
                {
                    if (listaInvitaciones[j].id == trozos[2])
                    {
                        if (listaInvitaciones[j].remitente == 1)
                            encontrado = 1;
                        else
                        {
                            encontrado = 1;
                            listaInvitaciones[j].estado = "Pendiente de respuesta";
                        }
                    }
                }
                if (encontrado == 0)
                {
                    CInvitacion a = new CInvitacion();

                    string estado = "Pendiente de respuesta";
                    a.rival = trozos[5].Split('\0')[0];
                    a.estado = estado;
                    a.id = trozos[2];
                    a.tiempo = 61;
                    a.remitente = 0; //tu invitas

                    listaInvitaciones.Add(a);
                }
            }
            else
            {
                CPartida partida = new CPartida();
                partida.ID = ID_partida;
                partida.num = Convert.ToInt32(trozos[3]);
                partida.nombre = nombre;
                partida.id_invitacion = trozos[2];

                for (int j = 0; j < partida.num; j++)
                    partida.rivales[j] = trozos[4 + j].Split('\0')[0];
                
                listaPartidas.Add(partida);

                string estado = "Invitación aceptada";
                for (int j = 0; j < listaInvitaciones.Count; j++)
                    if (listaInvitaciones[j].id == trozos[2].Split('\0')[0])
                            listaInvitaciones[j].estado = estado;
                MessageBox.Show("Ya puedes iniciar la partida " + id_invitacion);
            }
            
            this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
            this.Invitacion_Grid.ColumnCount = 3;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].id;
                this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].rival;
                this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
            }

            if (listaInvitaciones.Count == 1)
                this.timer_invitar.Enabled = false;
        }

        private void IniciarPartida_Click(object sender, EventArgs e)
            //Creamos el thread para poner en marcha una nueva partida
        {
                ThreadStart ts = delegate { PonerEnMarchaFormulario3(); };
                Thread T = new Thread(ts);
                T.Start();
                this.Invitacion_textBox.Text = null;
            
        }

        private void Conectados_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
            //Se añade el jugador seleccionado a la lista de jugadores a los que se quiere invitar a una partida
        {
            int fila = e.RowIndex;

            int encontrado = 0;
            for (int j = 0; j < MAX_jugadores; j++)
                if (rivales[j] == conectados[fila])
                {
                    encontrado = 1;
                    MessageBox.Show("Ya has seleccionado a este jugador");
                }
            if (encontrado == 0)
            {
                if (nombre == conectados[fila])
                    MessageBox.Show("No te puedes invitar a ti mismo");
                else
                {
                    if (cont < MAX_jugadores)
                    {
                        rivales[cont] = conectados[fila];
                        this.Invitados_textBox.Text = this.Invitados_textBox.Text + conectados[fila] + " ";
                        cont++;
                    }
                    else
                        MessageBox.Show("Ya no puedes invitar a más jugadores");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            //Cuando el cliente cierra la ventana envía al servidor un mensaje para indicar que cierre la conexión
            //y nos desconectamos
        {
            if (conectado == 1)
            {
                string mensaje = "0/";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                server.Close();

                conectado = 0;
            }
        }

        private void Dar_baja_Click(object sender, EventArgs e)
        {
            groupBox_inciar.Visible = true;
            groupBox_inciar.Text = "¿Quieres eliminar tu cuenta?";
            Registrarse_Button.Visible = false;
            Iniciar_Button.Visible = false;
            Baja_button.Visible = true;
        }

        private void Baja_button_Click(object sender, EventArgs e)
            //coge el el nombre y contraseña introducidos por el cliente
            // y lo envia al servidor para dar de baja
        {
            if (conectado == 0)
            {
                IPAddress direc = IPAddress.Parse(ip);
                IPEndPoint ipep = new IPEndPoint(direc, port);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);
                    conectado = 1;
                }
                catch (SocketException)
                {
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }

            if ((this.Nombre.Text == null) || (this.Contraseña.Text == null))
                MessageBox.Show("No se han rellenado correctamente todos los campos");
            else
            {
                string msj = "16/" + this.Nombre.Text + "/" + this.Contraseña.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }

            this.Nombre.Text = null;
            this.Contraseña.Text = null;
        }

        private void Invitacion_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
            //Selecciona la invitación que se quiere aceptar, rechazar o iniciar partida
        {
            int fila = e.RowIndex;
            this.Invitacion_textBox.Text = listaInvitaciones[fila].id;
            id_invitacion = listaInvitaciones[fila].id;
        }

        private void Ayuda_Click(object sender, EventArgs e)
            //Se abre el form4
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void timer_invitar_Tick_1(object sender, EventArgs e)
            //Cuenta los segundos que pasan desde que te llega una invitación
            //si pasan mas de 60, se rechaza la invitación automáticamente
        {
            for (int i = 0; i < listaInvitaciones.Count; i++)
            {
               //listaInvitaciones[i].tiempo++;

                if ( listaInvitaciones[i].tiempo == 10)
                {
                    string msj = "8/" + listaInvitaciones[i].id + "/0";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                    server.Send(msg);
                    MessageBox.Show("Se ha cancelado la invitacion " + listaInvitaciones[i].id);
                    listaInvitaciones.RemoveAt(i);
                }
            }

            this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
            this.Invitacion_Grid.ColumnCount = 3;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].id;
                this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].rival;
                this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
            }
        }
    }
}
