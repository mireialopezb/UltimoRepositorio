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

        delegate void DelegadoParaPasarMensaje(string mensaje);
        delegate void DelegadoParaActualizarLista(string[] trozos);
        
        int port = 9091;
        string ip = "192.168.1.50";
        string jugador2;
        List<string> jugadores_dosCdos = new List<string>();
        string[] conectados;

        public class CPartida
        {
            public int ID, nForm,modo;
            public string nombre;
            public string [] rivales;
        }

        public class CInvitacion
        {
            public string modo, jugador, estado;
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
            groupBox_registro.Visible = false;
            Baja_groupBox.Visible = false;
        }

        private void Registrarse_Click(object sender, EventArgs e)
        {
            groupBox_registro.Visible = true;
            groupBox_inciar.Visible = false;
            Baja_groupBox.Visible = false;
        }

        private void Iniciar_Button_Click(object sender, EventArgs e)
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

            if ((this.Nombre_Registro.Text == null) || (this.Contraseña_Registro.Text == null))
                MessageBox.Show("No se han rellenado correctamente todos los campos");
            else
            {
                nombre = this.Nombre.Text;

                string msj = "1/" + this.Nombre.Text + "/" + this.Contraseña.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }

        }

        private void Registrarse_Button_Click(object sender, EventArgs e)
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

            if ((this.Nombre_Registro.Text == null) || (this.Contraseña_Registro.Text == null))
                MessageBox.Show("No se han rellenado correctamente todos los campos");
            else
            {
                nombre = this.Nombre_Registro.Text;
                string msj = "2/" + this.Nombre_Registro.Text + "/" + this.Contraseña_Registro.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }
        }

        private void PonerEnMarchaFormulario2()
        {
            int cont = f2.Count;
            Form2 f = new Form2(cont, server,ID_jugador);
            f2.Add(f);
            f.ShowDialog();
        }

        private void PonerEnMarchaFormulario3()
        {
            int j = 0;
            
            if (Invitados_textBox.Text == null)
                MessageBox.Show("Tienes que seleccionar con quien quieres iniciar la partida");
            else
            {
                
                int encontrado = 0;
                while((encontrado==0)&&(j<listaPartidas.Count))
                {
                    if (listaPartidas[j].nombre == jugador2)
                    {
                        encontrado = 1;
                    }
                    else
                        j++;
                }

                int cont = f3.Count;
                int modo=0;
                string[] rivales=null;
                Form3 f = new Form3(cont, listaPartidas[j].ID, nombre, listaPartidas[j].nombre, server,modo,rivales);
                
                listaPartidas[j].nForm = cont;

                f3.Add(f);
                f.ShowDialog();
            }
        }

        private void AtenderServidor()
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
                            MessageBox.Show("Se ha iniciado sesión correctamente, tu ID de jugador es: " + mensaje);
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
                            MessageBox.Show("Te has registrado correctamente, tu ID de jugador es: " + mensaje);
                        }
                        break;

                    case 3: // quien tiene el record
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;

                    case 4:
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;

                    case 5:
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;

                    case 6:
                        DelegadoParaActualizarLista delegado_conectados = new DelegadoParaActualizarLista(Actualiza_Grid_Conectados);
                        Conectados_Grid.Invoke(delegado_conectados, new object[] { trozos });
                        break;
                    case 7:
                        jugador2 = trozos[1];
                        DelegadoParaActualizarLista delegado_invitaciones = new DelegadoParaActualizarLista(NuevaInvitacion);

                        Invoke(delegado_invitaciones, new object[] { trozos });
                        break;
                    case 8:
                        DelegadoParaActualizarLista delegado_invitaciones_respuesta = new DelegadoParaActualizarLista(RespuestaInvitacion);
                        Invoke(delegado_invitaciones_respuesta, new object[] { trozos });
                        break;
                    case 9:
                        ID_partida = Convert.ToInt32(trozos[1]);
                        
                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        f3[nform].TomaRespuesta(trozos);
                        break;
                    case 10:
                        ID_partida = Convert.ToInt32(trozos[1]);
                        
                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        f3[nform].TomaRespuesta(trozos);
                        break;
                    case 11:
                        ID_partida = Convert.ToInt32(trozos[1]);

                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        f3[nform].TomaRespuesta(trozos);
                        break;
                    case 12:
                        ID_partida = Convert.ToInt32(trozos[1]);
                        
                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        f3[nform].TomaRespuesta(trozos);
                        break;
                    case 13:
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;
                    case 14:
                        nform = Convert.ToInt32(trozos[1]);
                        f2[nform].TomaRespuesta(trozos);
                        break;
                    case 15:
                        ID_partida = Convert.ToInt32(trozos[1]);
                        
                        nform=-1;
                        for (int i = 0; i < listaPartidas.Count; i++)
                            if (listaPartidas[i].ID == ID_partida)
                                nform = listaPartidas[i].nForm;

                        f3[nform].TomaRespuesta(trozos);
                        break;
                    case 16:
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
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario2(); };
            Thread T = new Thread(ts);
            T.Start();
        }

        public void Actualiza_Grid_Conectados(string[] trozos)
        // actualiza la lista de conectados cada vez que se conecte un usuario
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
        {
            string msj=null;
            string modo, estado;
            if (listaInvitaciones.Count == 0)
            {
                CInvitacion i = new CInvitacion();
                modo = "Modo";
                string jugador_2 = "Jugador";
                estado = "Estado";

                i.modo = modo;
                i.jugador = jugador_2;
                i.estado = estado;

                listaInvitaciones.Add(i);
            }
            if (unoCuno.Checked)
            {
                msj = "7/"+ jugador2;

                CInvitacion i = new CInvitacion();
                modo = "1 contra 1";
                estado = "Esperando respuesta";

                i.modo = modo;
                i.jugador = jugador2;
                i.estado = estado;

                listaInvitaciones.Add(i);
            }
            else if (dosCdos.Checked)
            {
                msj = "17/";
                if (jugadores_dosCdos.Count == 3)
                    for (int j = 0; j < 3; j++)
                    {
                        CInvitacion i = new CInvitacion();
                        modo = "2 contra 2";
                        estado = "Esperando respuesta";

                        i.modo = modo;
                        i.estado = estado;
                        i.jugador = jugadores_dosCdos[j];
                        listaInvitaciones.Add(i);

                        msj = msj + jugadores_dosCdos[j] + "/";
                    }
                else
                    MessageBox.Show("Debes invitar a 3 personas para jugar 2 contra 2");
            }
            if (msj != null)
            {
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);

                this.groupBox1.Visible = true;

                this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
                this.Invitacion_Grid.ColumnCount = 3;

                for (int j = 0; j < listaInvitaciones.Count; j++)
                {
                    this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].modo;
                    this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].jugador;
                    this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
                }
            }
        }

        private void Conectados_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            if (unoCuno.Checked)
            {
                jugador2 = conectados[fila];
                this.Invitados_textBox.Text = jugador2;
            }
            else if (dosCdos.Checked)
            {
                if (jugadores_dosCdos.Count < 3)
                {
                    jugadores_dosCdos.Add(conectados[fila]);
                    this.Invitados_textBox.Text = this.Invitados_textBox.Text + ", " + conectados[fila];
                }
                else
                    MessageBox.Show("Ya no puedes invitar a más jugadores");
            }
            else
                MessageBox.Show("Tienes que seleccionar el modo de juego");

        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            string msj = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
            server.Send(msg);
            conectado = 0;

            atender.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            conectado = 0;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Invitados_textBox.Text = null;
            jugador2 = null;
            for (int i = 0; i < jugadores_dosCdos.Count; i++)
                jugadores_dosCdos.RemoveAt(i);
        }

        private void aceptar_button_Click(object sender, EventArgs e)
        {
            string modo=null;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                if (listaInvitaciones[j].jugador == this.Invitacion_textBox.Text)
                    modo = listaInvitaciones[j].modo;
            }
            string msj=null;

            if (modo == "1 contra 1")
            {
                msj = "8/" + this.Invitacion_textBox.Text + "/1";
                MessageBox.Show("Para que tu partida con " + jugador2 + " empize debes darle al boton de iniciar partida");
            }

            else if (modo == "2 contra 2") 
                msj = "18/" + this.Invitacion_textBox.Text + "/1";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
            server.Send(msg);

            this.Iniciar_Button.Visible = true;
            this.Invitacion_groupBox.Visible = false;
        }

        private void rechazar_button_Click(object sender, EventArgs e)
        {
            string modo = null;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                if (listaInvitaciones[j].jugador == this.Invitacion_textBox.Text)
                    modo = listaInvitaciones[j].modo;
            }
            string msj = null;

            if (modo == "1 contra 1")
            {
                msj = "8/" + jugador2 + "/0";
            }

            else if (modo == "2 contra 2")
                msj = "18/" + jugador2 + "/0";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
            server.Send(msg);

            this.Iniciar_Button.Visible = true;
            this.Invitacion_groupBox.Visible = false;

            for (int j = 0; j < listaInvitaciones.Count; j++)
                if (listaInvitaciones[j].jugador == jugador2)
                    listaInvitaciones.RemoveAt(j);

            this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
            this.Invitacion_Grid.ColumnCount = 3;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].modo;
                this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].jugador;
                this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
            }
        }

        private void NuevaInvitacion(string [] trozos)
        //Cuando te invitan a una partida
        {
            int codigo = Convert.ToInt16(trozos[0]);
            string jugador2;
            string modo, estado;

            this.Invitaciones_groupBox.Visible = true;

            if (listaInvitaciones.Count == 0)
            {
                CInvitacion i = new CInvitacion();
                modo = "Modo";
                jugador2 = "Jugador";
                estado = "Estado";
                     
                i.modo = modo;
                i.jugador = jugador2;
                i.estado = estado;

                listaInvitaciones.Add(i);
            }

            jugador2=  trozos[1];

            if (codigo == 7)
            {
                CInvitacion i = new CInvitacion();
                modo = "1 contra 1";
                estado = "Esperando tu respuesta";

                i.modo = modo;
                i.jugador = jugador2;
                i.estado = estado;

                listaInvitaciones.Add(i);

               
            }
            else
            {
                CInvitacion i = new CInvitacion();
                modo = "2 contra 2";
                estado = "Esperando tu respuesta";

                i.modo = modo;
                i.jugador = jugador2;
                i.estado = estado;

                listaInvitaciones.Add(i);

            }

            this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
            this.Invitacion_Grid.ColumnCount = 3;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].modo;
                this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].jugador;
                this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
            }

        }

        private void RespuestaInvitacion(string[] trozos)
        {
            ID_partida = Convert.ToInt32(trozos[1]);
            int codigo=Convert.ToInt32(trozos[0]);

            if (codigo == 8)
            {
                if (ID_partida == 0)//han rechazado la invitacion
                {
                    MessageBox.Show(jugador2 + " ha rechazado tu invitación");
                    for (int j = 0; j < listaInvitaciones.Count; j++)
                        if (listaInvitaciones[j].jugador == trozos[2].Split('\0')[0])
                            listaInvitaciones.RemoveAt(j);
                }
                else
                {
                    CPartida partida = new CPartida();
                    partida.ID = ID_partida;
                    partida.nombre = trozos[2].Split('\0')[0];
                    listaPartidas.Add(partida);
                    string estado = "Invitación aceptada";
                    for (int j = 0; j < listaInvitaciones.Count; j++)
                        if (listaInvitaciones[j].jugador == trozos[2].Split('\0')[0])
                            listaInvitaciones[j].estado = estado;
                }
            }
            else
            {
            }

            this.Invitacion_Grid.RowCount = listaInvitaciones.Count;
            this.Invitacion_Grid.ColumnCount = 3;

            for (int j = 0; j < listaInvitaciones.Count; j++)
            {
                this.Invitacion_Grid.Rows[j].Cells[0].Value = listaInvitaciones[j].modo;
                this.Invitacion_Grid.Rows[j].Cells[1].Value = listaInvitaciones[j].jugador;
                this.Invitacion_Grid.Rows[j].Cells[2].Value = listaInvitaciones[j].estado;
            }
        }

        private void IniciarPartida_Click(object sender, EventArgs e)
        {
                ThreadStart ts = delegate { PonerEnMarchaFormulario3(); };
                Thread T = new Thread(ts);
                T.Start();
            
        }

        private void Conectados_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            if (unoCuno.Checked)
            {
                jugador2 = conectados[fila];
                this.Invitados_textBox.Text = jugador2;
            }
            else if (dosCdos.Checked)
            {
                if (jugadores_dosCdos.Count < 3)
                {
                    jugadores_dosCdos.Add(conectados[fila]);
                    this.Invitados_textBox.Text = this.Invitados_textBox.Text + ", " + conectados[fila];
                }
                else
                    MessageBox.Show("Ya no puedes invitar a más jugadores");
            }
            else
                MessageBox.Show("Tienes que seleccionar el modo de juego");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
            groupBox_registro.Visible = false;
            groupBox_inciar.Visible = false;
            Baja_groupBox.Visible = true;
        }

        private void Baja_button_Click(object sender, EventArgs e)
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

            if ((this.baja_nombre.Text == null) || (this.contrasena_baja.Text == null))
                MessageBox.Show("No se han rellenado correctamente todos los campos");
            else
            {
                string msj = "16/" + this.baja_nombre.Text + "/" + this.contrasena_baja.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msj);
                server.Send(msg);
            }
        }

        private void Invitacion_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            if (this.Invitacion_textBox.Text != null)
                this.Invitacion_textBox.Text = listaInvitaciones[fila].jugador;
            else
                MessageBox.Show("Ya tienes seleccionada una invitación");
        }

       /* private void Form1_Load(object sender, EventArgs e)
        {

            string fechayhora = DateTime.Now.ToString();
            MessageBox.Show(fechayhora);
        }
        */
    }
}
