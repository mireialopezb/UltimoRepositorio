#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <ctype.h>
#include <pthread.h>
#include <string.h>
#define port 9091
#define MAX 100
//preferencias -std=c99 `mysql_config --cflags --libs`
//ejecucion gcc -o prop prog.c `mysql_config --cflags --libs`

int num_sockets;
int j;
int sockets[MAX];
//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct {
	char nombre [20];
	int Socket;
} Conectado;

typedef struct {
	Conectado conectados [MAX];
	int num;
} ListaConectados;

typedef struct { 
	int partida;
	char jugador1 [20];	
	char jugador2 [20];	
	int personaje[2];
	int Socket[2];
} Partida; 
//esturctura necesaria para poder jugar mas de una partida a la vez
typedef struct {
	Partida partida[MAX];
	int num;
}ListaPartidas;

ListaConectados listaConectados;
ListaPartidas listaPartidas;

int PonConectados (ListaConectados *lista, char nombre [20], int Socket) 
	//funcion para anadir un cliente conectado a la lista
{
	if (lista->num == MAX)
		return -1; //devuelve -1 si la lista est\uffe1 llena
	else{
		
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].Socket=Socket;
		lista->num++;
		//printf("%s,%d",lista->conectados[lista->num].nombre,lista->conectados[lista->num].Socket);
		return 0;
	}
}

void Dameconectados (ListaConectados *lista, char conectados [512])
// pone en conectados todos los nombres separados por , primero pone el numero de conectados
{
	strcpy(conectados,"");
	
	//indicamos cuantos usuarios estan conectados
	sprintf(conectados,"%d/", lista->num);
	
	for (int i=0;  i<lista->num; i++)
	{	
		// añadimos los usuarios conectados uno por uno
		sprintf(conectados, "%s%s,", conectados, lista->conectados[i].nombre);
	}
	
	if (lista->num==0)
		strcpy(conectados,"0");
}

int Damesocket (ListaConectados *lista, char nombre [20])
{ //Devuelve el socket o -1 si no esta en la lista
	int i = 0;
	int encontrado =0;
	while ((i<lista->num)&&(encontrado == 0))
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
		{
			encontrado = 1;
			return lista->conectados[i].Socket;
		}
		i++;
	}
	if (!encontrado)
		return -1;
}



int Dameposicion (ListaConectados *lista, char nombre [20])
{ //Devuelve el socket o -1 si no esta en la lista
	int i = 0;
	int encontrado =0;
	while ((i<lista->num)&&(encontrado == 0))
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
		{			
			//printf("%s, %s\n",nombre,lista->conectados[2].nombre);
			encontrado = 1;
			
			//printf("%d\n",i);
			return i;
		}
		i++;
	}
	if (!encontrado)
		return -1;
}


int EliminarConectados (ListaConectados *lista, char nombre[20])
	//Devuelve 0 si se ha eliminado correctamente, -1 si no esta en la lista
{
	int pos = Dameposicion (lista, nombre);
	printf("Posición %d nombre %s\n",pos,nombre);
	if (pos == -1)
		return -1;
	else
	{
		for (int i=pos; i < lista->num-1; i++)
		{//lista->conectados[i] = lista->conectados[i+1];
			strcpy(lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			lista->conectados[i].Socket = lista->conectados[i+1].Socket;
		}
		lista->num --;
		return 0;
	}
}
void EliminarSocket (int sockets[MAX],int sock_conn)
	//Cuando el usuario se desconecta del servidor elimina 
	// su socket de la lista de sockets	
{
	int encontrado=0;
	
	for (int i=0; i < num_sockets-1; i++)
	{//lista->conectados[i] = lista->conectados[i+1];
		if(sockets[i]==sock_conn)
			encontrado=1;
		if (encontrado==1)
			sockets[i]=sockets[i+1];
	}
	num_sockets --;
	printf("Se ha eliminado el socket de la lista\n");
}
void EliminarPartida(ListaPartidas *lista,int id)
	//Cuando se acaba una partida se elimina de la lista de partidas
{
	int encontrado=0;
	for (int i=0;i<lista->num-1;i++)
	{
		if(lista->partida[i].partida==id)
			encontrado=1;
		if(encontrado==1)
		{
			strcpy(lista->partida[i].jugador1,lista->partida[i+1].jugador1);
			strcpy(lista->partida[i].jugador2,lista->partida[i+1].jugador2);
			lista->partida[i].Socket[0]=lista->partida[i+1].Socket[0];
			lista->partida[i].Socket[1]=lista->partida[i+1].Socket[1];
			lista->partida[i].partida=lista->partida[i+1].partida;
			lista->partida[i].personaje[0]=lista->partida[i+1].personaje[0];
			lista->partida[i].personaje[1]=lista->partida[i+1].personaje[1];
		}
	}
	lista->num--;
	printf("Se ha eliminado la partida %d de la lista de partidas\n",id);
}
void IniciarSesion (char nombre [20], char contrasena [20], MYSQL *conn, ListaConectados *lista, char buff2[512], int sock_conn)
	// Busca en la base de datos si existe un usuario con el mismo nombre y contrasena
	// Si hay un error al hacer la consulta en la base de datos envia el mensaje 1/-1
	// Si no encuentra el usuario envía el mensaje 1/0
	// Si encuentra el usuario envia el mensaje 1/ID del usuario
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
		
	// construimos la consulta SQL
	int err=mysql_query(conn,"SELECT * from jugador");
	if (err!=0)
	{
		printf("Error al consultar datos de la base %u %s\n",
			   mysql_errno(conn),mysql_error(conn));
		sprintf(buff2,"1/-1");
		exit(1);
	}
	
	//recogemos el resultado de la consulta 
	resultado=mysql_store_result(conn);
	//Estructura matricial en memoria
	//cada fila contiene los datos de una partida
	
	//obtenemos los datos de una fila
	row=mysql_fetch_row(resultado);
	int encontrado=0;
	if (row==NULL)
	{
		printf("No se han obtenido datos en la consulta\n");
		sprintf(buff2,"1/-2");
	}
	else
	{
		int encontrado=0;
		while ((row !=NULL)&&(encontrado==0))
		{
			//recorre la base de datos para ver si el usuario existe
			if((strcmp(nombre,row[1])==0)&&(strcmp(contrasena,row[2])==0))
			{
				sprintf(buff2,"1/%s",row[0]);
				encontrado=1;
				pthread_mutex_lock(&mutex); //no me interrumpas ahora
				//Añadimos el usuario a la lista de conectados
				PonConectados(lista,nombre,sock_conn);
				
				pthread_mutex_unlock(&mutex); //ya puedes interrumpirme
				
				//Envia la lista de conectados actualizada a todos los usuarios
				char conectados [512];
				strcpy(conectados, "");
				char notificacion [512];
				Dameconectados (lista, conectados);
				strcpy(notificacion, "");
				sprintf(notificacion,"6/%s",conectados);
				
				for(int j =0; j<lista->num;j++)
				{
					write(lista->conectados[j].Socket,notificacion,strlen(notificacion));
					printf("%s\n",notificacion);
				}
				strcpy(notificacion,"");
			}
			row=mysql_fetch_row(resultado);
		}
		if (encontrado==0) //si no ha encontrado al usuario en la base de datos, envia un 0
			sprintf(buff2,"1/0");
	}
}

void Registrar (char nombre [20], char contrasena [20], MYSQL_ROW row, MYSQL_RES *resultado, MYSQL *conn, ListaConectados *lista, char buff2[512], int sock_conn, char ID_jugador[10])
	// Busca en la base de datos si ya existe un usuario con el mismo nombre y constrasena
	// Si hay un error al hacer la consulta en la base de datos envia el mensaje 1/-1
	// Si no encuentra el usuario lo crea añadiendolo en la base de datos (se registra)
	// Si se registra correctamente envia el mensaje 2/ID que se le ha assignado
	// Si encuentra el usuario en a base de datos significa que ya hay alguien que usa ese mismo nombre y contraseña 
	// envia el mensaje 2/0
{
	// construimos la consulta SQL
	int err=mysql_query(conn,"SELECT * from jugador");
	if (err!=0)
	{
		printf("Error al consultar datos de la base %u %s\n",
			   mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	
	//recogemos el resultado de la consulta 
	resultado=mysql_store_result(conn);
	//Estructura matricial en memoria
	//cada fila contiene los datos de una partida
	
	//obtenemos los datos de una fila
	row=mysql_fetch_row(resultado);
	int encontrado=0;
	if (row==NULL)
		printf("No se han obtenido datos en la consulta\n");
	else
	{
		while ((row !=NULL)&&(encontrado==0))
		{
			//miramos si ya existe un jugador en la base de datos con el mismo nombre y contraseña
			if(strcmp(nombre,row[1])==0)
				//el jugador ya existe
				//envia un 0 al cliente para informar de que este jugador ya existe
			{
				strcpy(buff2,"2/0");
				encontrado=1;
			}
			row=mysql_fetch_row(resultado); //recorre toda la tabla
		}
		if (encontrado==0)//&&(strlen(nombre)!=0)&&(strlen(contrasena)!=0)) 
			//el jugador no existe, asi que lo añade a la base de datos
		{
			//como los ID van en orden (ej: 1,2,3,4...)
			//contamos cuantos jugadores hay registrados
			//el último id usado será igual al número de jugadores
			char consulta [200];
			strcpy (consulta,"SELECT COUNT(*) FROM jugador");
			
			err=mysql_query (conn, consulta);
			if (err!=0) 
			{
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta\n");
			else
				// la columna 0 contiene el ulitimo ID de jugador usado
				sprintf(ID_jugador,"%d",atoi(row[0])+1);
			
			//creamos la consulta
			pthread_mutex_lock(&mutex); //no me interrumpas ahora
			
			strcpy(consulta,"");
			strcpy (consulta, "INSERT INTO jugador VALUES (");
			//concatenamos el ID_jugador 
			strcat (consulta, ID_jugador); 
			strcat (consulta, ",'");
			//concatenamos el nombre 
			strcat (consulta, nombre); 
			strcat (consulta, "','");
			//concatenamos la contraseña
			strcat (consulta, contrasena); 
			strcat (consulta, "');");
			printf("%s",consulta);
			
			// Añadimos el usuario a la lista de conectados
			PonConectados(lista,nombre,sock_conn);
			
			err = mysql_query(conn, consulta);
			if (err!=0) 
				printf ("Error al introducir datos la base %u %s\n", 
						mysql_errno(conn), mysql_error(conn));
			else
				//la inserción se ha realizado con exito
				//informamos al cliente enviando el ID_jugador asignado
				sprintf(buff2,"2/%s",ID_jugador);
			
			char conectados [512];
			//Envia la lista de conectados actualizada a todos los usuarios
			Dameconectados (lista, conectados);
			
			pthread_mutex_unlock(&mutex); //ya puedes interrumpirme
			
			char notificacion [512];
			sprintf(notificacion,"6/%s",conectados);
			
			for(int j =0; j<lista->num;j++)
			{
				write(lista->conectados[j].Socket,notificacion,strlen(notificacion));
				printf("%s\n",notificacion);
			}
			strcpy(notificacion,"");
		}
	}
}

int IniciarPartida(MYSQL *conn, ListaPartidas *lista)
	// Assigna un ID a la partida
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	int ID_partida;
	
	if(lista->num==0)
	{
		char consulta [200];
		strcpy (consulta,"SELECT COUNT(*) FROM partida");
		
		int err=mysql_query (conn, consulta);
		if (err!=0) 
		{
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			printf ("No se han obtenido datos en la consulta\n");
		else
			// la columna 0 contiene el ulitimo ID de partida usado
			// que es el mismo numero que el total de partidas que hay
			ID_partida=atoi(row[0])+1;
		printf("Partidas en la base de datos: %s\n ID partida: %d\n",row[0],ID_partida);
	}
	else
	{
		ID_partida=lista->partida[lista->num-1].partida+1;
	}
	
	return ID_partida;
	
}

void DameRecord(MYSQL *conn, char buff2[512],int nform)
	// consulta quien tiene el record 
	// y se envia el mensaje con formato 3/mensaje
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char nombrerecord[20];
	
	int err=mysql_query(conn,"SELECT jugador.nombre FROM jugador,partida WHERE jugador.ID_jugador = (SELECT partida.ID_ganador FROM partida WHERE partida.duracion=(SELECT MIN(partida.duracion) FROM partida)) AND partida.ID_ganador=jugador.ID_jugador ;");
	if (err!=0)
	{
		printf("Error al consultar datos de la base %u %s\n",
			   mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	
	//recogemos el resultado de la consulta 
	resultado=mysql_store_result(conn);
	//Estructura matricial en memoria
	//cada fila contiene los datos de una partida
	
	//obtenemos los datos de una fila
	row=mysql_fetch_row(resultado);
	
	if (row==NULL)
		printf("No se han obtenido datos en la consulta\n");
	else
		if (row !=NULL)
	{
		strcpy(nombrerecord,row[0]);
	}
		
	sprintf(buff2,"3/%d/%s tiene el record.",nform,row[0]);
	printf("%s\n",buff2);
}

void DamePersonajes (MYSQL *conn, char buff2[512], char ID_partida [10],int nform)
	// consulta en la base de datos que personajes se escogieron en la partida indicada
	// crea un mensaje de formato: 4/nform/personaje 1/personaje 2
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta [200];
	sprintf(consulta,"SELECT personaje.nombre_personaje FROM (partida, personaje, registro) WHERE partida.ID_partida = %s AND partida.ID_partida = registro.ID_partida AND registro.ID_personaje = personaje.ID_personaje",ID_partida);
	
	int err=mysql_query (conn, consulta);
	
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		sprintf(buff2, "4/%d/0",nform);
	}
	else 
	{
		sprintf(buff2,"4/%d/%s/", nform,row[0]);
		row = mysql_fetch_row (resultado);
		char frase[100];
		sprintf (frase, "%s", row[0]);
		strcat(buff2, frase);
	}
}
void DamePartidasJugadas( MYSQL *conn, char buff2[512], int ID_jugador,int nform)
	// Realiza varias consultas en la base de datos y crea mensaje de la forma:
	// 5/numero de partidas jugadas/nombre oponente 1-victoria o derrota/nombre oponente 2-victoria o derrota/...
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta [400];
	
	sprintf (consulta,"SELECT COUNT(*) FROM registro WHERE ID_jugador = %d",ID_jugador);
	
	int err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
		if (row !=NULL) 
			sprintf(buff2,"5/%d/%s/",nform,row[0]);
	
	
	
	sprintf (consulta, "SELECT registro.ID_jugador, partida.ID_ganador FROM (registro, partida) WHERE partida.ID_partida IN (SELECT registro.ID_partida FROM registro WHERE registro.ID_jugador = %d) AND partida.ID_partida = registro.ID_partida",ID_jugador);
	
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
		while (row !=NULL) 
	{
			char ID [10];
			strcpy(ID,row[0]);
			int ganador = atoi (row[1]);
			
			if (atoi(ID) != ID_jugador)
			{
				strcpy (consulta, "SELECT jugador.nombre FROM jugador WHERE jugador.ID_jugador = '");
				strcat (consulta, ID);
				strcat (consulta,"'");
				
				int err1=mysql_query (conn, consulta);
				
				if (err1!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				MYSQL_RES *resultado2 = mysql_store_result (conn);
				MYSQL_ROW row2 = mysql_fetch_row (resultado2);
				
				char nombre[20];
				strcpy (nombre, row2[0]);
				
				if (atoi(ID) == ganador)
				{
					char frase [80];
					sprintf(frase,"%s-Derrota/",nombre);
					strcat(buff2,frase);
				}
				else
				{
					char frase [80];
					sprintf(frase,"%s-Victoria/",nombre);
					strcat(buff2,frase);
				}	
			}
			
			row=mysql_fetch_row(resultado);
	}
}
int PonPartida (ListaPartidas *listaPartidas, ListaConectados *listaConectados, MYSQL *conn, char nombre [20],char jugador2 [20], int sock_conn) 
	//añade la partida que se acaba de iniciar a la lista de partidas
{
	int sock2 = Damesocket(listaConectados,jugador2);
	
	int ID=IniciarPartida(conn,listaPartidas);
	printf("ID partida 1: %d\n",ID);
	
	strcpy(listaPartidas->partida[listaPartidas->num].jugador1,nombre);
	strcpy(listaPartidas->partida[listaPartidas->num].jugador2,jugador2);
	listaPartidas->partida[listaPartidas->num].Socket[0]=sock_conn;
	listaPartidas->partida[listaPartidas->num].Socket[1]=sock2;
	listaPartidas->partida[listaPartidas->num].partida=ID;
	listaPartidas->partida[listaPartidas->num].personaje[0]=0;
	listaPartidas->partida[listaPartidas->num].personaje[1]=0;
	listaPartidas->num++;
	
	return ID;
}



int GuardarPersonaje (ListaPartidas *lista, char nombre[20],int id, int id_personaje,int socket)
	//Guardamos el personaje escogido por el jugador en la lista de partidas
{
	for(int j=0;j<lista->num;j++)
	{
		if (lista->partida[j].partida==id)
		{
			if(id_personaje>0)
			{
				if(strcmp(lista->partida[j].jugador1,nombre)==0)
				{
					socket=lista->partida[j].Socket[1];
					lista->partida[j].personaje[0]=id_personaje;
					return 1;
				}
				else
				{
					socket=lista->partida[j].Socket[0];
					lista->partida[j].personaje[1]=id_personaje;
					return 1;			
				}
			}
		}
	}
	
	return 0;
}

void AdivinarPersonaje (ListaPartidas *lista, char nombre[20], int id, int id_personaje, char buff2 [512],char buff3 [512])
	//Compara el personaje con el personaje correspondiente, si coincide envia un 0 al clinete y un 1 al rival
	//si no coincide envia un 2 al cliente y un 3 al rival
{
	int socket=0;
	
	for(int j=0;j<lista->num;j++)
	{
		if (lista->partida[j].partida==id)
		{
			if(strcmp(lista->partida[j].jugador1,nombre)==0)
			{
				if(lista->partida[j].personaje[1]==id_personaje)
				{
					sprintf(buff2,"12/%d/1",id);
					sprintf(buff3,"12/%d/2",id);
				}
				else
				{
					sprintf(buff2,"12/%d/0",id);
					sprintf(buff3,"12/%d/3",id);
				}
				socket=lista->partida[j].Socket[1];
			}
			else
			{
				if(lista->partida[j].personaje[0]==id_personaje)
				{
					sprintf(buff2,"12/%d/1",id);
					sprintf(buff3,"12/%d/2",id);
				}
				else
				{
					sprintf(buff2,"12/%d/0",id);
					sprintf(buff3,"12/%d/3",id);
				}
				socket=lista->partida[j].Socket[0];
			}
			
		}
	}
	
}
void GuardarPartida (ListaPartidas *lista, MYSQL *conn, char nombre [20], int id,int dia,int mes,int ano,int duracion,char hora[11])
	//se guardan todos los datos de la partida en la base de datos en las tablas de partida y registro
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta [200];
	int id_ganador;
	sprintf (consulta,"SELECT ID_jugador FROM jugador WHERE nombre = '%s';",nombre);
	
	int err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta ****\n");
	else
		id_ganador=atoi(row[0]);
	
	if((dia<10)&&(mes<10))
		sprintf(consulta,"INSERT INTO partida VALUES (%d,'0%d/0%d/%d','%s',%d,%d);",id,dia,mes,ano,hora,duracion,id_ganador);
	else if((dia<10)&&(mes>=10))
		sprintf(consulta,"INSERT INTO partida VALUES (%d,'0%d/%d/%d','%s',%d,%d);",id,dia,mes,ano,hora,duracion,id_ganador);
	else if((dia>=10)&&(mes<10))
		sprintf(consulta,"INSERT INTO partida VALUES (%d,'%d/0%d/%d','%s',%d,%d);",id,dia,mes,ano,hora,duracion,id_ganador);
	else 
		sprintf(consulta,"INSERT INTO partida VALUES (%d,'%d/%d/%d','%s',%d,%d);",id,dia,mes,ano,hora,duracion,id_ganador);
	
	err = mysql_query(conn, consulta);
	if (err!=0) 
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
	
	for(int j=0;j<lista->num;j++)
	{
		if (lista->partida[j].partida==id)
		{
			sprintf (consulta,"SELECT ID_jugador FROM jugador WHERE nombre = '%s';",lista->partida[j].jugador1);
			
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			int id_jugador=0;
			
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta\n");
			else
				id_jugador=atoi(row[0]);
			
			sprintf(consulta, "INSERT INTO registro VALUES (%d,%d,%d);",id,id_jugador,lista->partida[j].personaje[0]);
			err = mysql_query(conn, consulta);
			if (err!=0) 
				printf ("Error al introducir datos la base %u %s\n", 
						mysql_errno(conn), mysql_error(conn));
			
			sprintf (consulta,"SELECT ID_jugador FROM jugador WHERE nombre = '%s';",lista->partida[j].jugador2);
			
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			if (row == NULL)
				printf ("No se han obtenido datos en la consulta\n");
			else
				id_jugador=atoi(row[0]);
			
			sprintf(consulta, "INSERT INTO registro VALUES (%d,%d,%d);",id,id_jugador,lista->partida[j].personaje[1]);
			
			err = mysql_query(conn, consulta);
			if (err!=0) 
				printf ("Error al introducir datos la base %u %s\n", 
						mysql_errno(conn), mysql_error(conn));
			printf("Se ha guardado la partida %d en la base de datos \n",id);
		}
	}
}

void DameMisResultadosCon(MYSQL *conn, int ID, int nform, char buff2 [512],char nombre [20])
	//devuelve la lista de las partidas del cliente con el jugador indicado y con sus resultados correspondientes
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta [400];
	
	sprintf(consulta,"SELECT jugador.ID_jugador FROM jugador WHERE jugador.nombre='%s';",nombre);
	
	int err=mysql_query (conn, consulta);
	
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row!=NULL)
	{
		sprintf(consulta,"SELECT registro.ID_partida, partida.ID_ganador FROM (registro, partida) WHERE partida.ID_partida IN (SELECT registro.ID_partida FROM registro WHERE registro.ID_jugador = %d) AND partida.ID_partida = registro.ID_partida AND registro.ID_jugador =%s;",ID,row[0]);
		
		int err=mysql_query (conn, consulta);
		
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//recogemos el resultado de la consulta
		
		MYSQL_RES *resultado2 = mysql_store_result (conn);
		MYSQL_ROW row2 = mysql_fetch_row (resultado2);
		
		char lista [400];
		strcpy(lista,"");
		int cont=0;
		
		if (row2 == NULL)
		{
			printf ("No se han obtenido datos en la consulta\n");
			sprintf(buff2, "13/%d/0",nform);
		}
		else 
		{	
			while(row2!=NULL)
			{
				if(atoi(row2[1])==ID)
					sprintf(lista,"%s%s-Derrota/",lista,row2[0]);
				else
					sprintf(lista,"%s%s-Victoria/",lista,row2[0]);
				
				cont++;
				row2 = mysql_fetch_row (resultado);
				printf("%s\n",lista);
			}
		}
		
		sprintf(buff2,"13/%d/%d/%s",nform,cont,lista);
	}
	else 
		sprintf(buff2,"13/%d/0",nform);
	
	printf("%s\n",buff2);
}

void DamePartidasFecha (MYSQL *conn,char fechamin [11], char fechamax [11], int nform, char buff2[512])
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta [400];
	
	sprintf(consulta,"SELECT registro.ID_partida, jugador.nombre, registro.ID_jugador, partida.ID_ganador FROM (registro,jugador,partida) WHERE partida.ID_partida BETWEEN (SELECT partida.ID_partida FROM partida WHERE partida.fecha = '%s') AND (SELECT partida.ID_partida FROM partida WHERE partida.fecha = '%s') AND partida.ID_partida = registro.ID_partida AND registro.ID_jugador=jugador.ID_jugador;",fechamin,fechamax);
	
	int err=mysql_query (conn, consulta);
	
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	char lista [500];
	strcpy(lista,"");
	int cont=0;
	char jugador[20];
	
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		sprintf(buff2, "14/%d/0",nform);
	}
	else 
	{	
		while(row!=NULL)
		{
			cont++;
			sprintf(lista,"%s%s-%s-",lista,row[0],row[1]);
			strcpy(jugador,row[1]);
			
			row = mysql_fetch_row (resultado);
			
			if(atoi(row[2])==atoi(row[3]))
				sprintf(lista,"%s%s-%s/",lista,row[1],jugador);
			else
				sprintf(lista,"%s%s-%s/",lista,row[1],row[1]);
			
			row = mysql_fetch_row (resultado);
		}
	}	
	
	sprintf(buff2,"14/%d/%d/%s",nform,cont,lista);		
}

void *AtenderCliente( void *socket)
{
	MYSQL *conn;	
	//creamos una conexión al servidor MYSQL
	conn=mysql_init(NULL);
	if(conn==NULL)
	{
		printf("Error al crear la conexión: %u %s\n",
			   mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	
	//inicializar la conexión
	//conn =mysql_real_connect(conn,"shiva2.upc.es","root","mysql","M4_juego",0,NULL,0);
	
	conn =mysql_real_connect(conn,"localhost","root","mysql","juego",0,NULL,0);
	
	if(conn==NULL)
	{
		printf("Error al iniciar la conexión: %u %s\n",
			   mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	int sock_conn, socket_invitador,socket_jugador2;
	int *s;
	s=(int *) socket;
	sock_conn=*s;
	//int sock_conn= * (int*) socket;
	
	
	int ret;
	char buff[512];
	char buff2[512];
	char notificacion [512];
	int err;
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	char consulta [200];
	char nombre[20], contrasena[20],ID_jugador[10], ID_partida[10];
	
	int terminar=0;
	while (terminar ==0)
	{
		
		// Ahora recibimos el código, que dejamos en buff
		ret=read(sock_conn,buff, sizeof(buff));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		buff[ret]='\0';
		
		//Escribimos el nombre en la consola
		
		printf ("Mensaje recibido: %s\n",buff);
		
		char *p = strtok( buff, "/");
		int codigo =  atoi (p);
		
		if (codigo == 0)
			terminar=1;
		
		else if (codigo ==1) 
			//iniciar sesion
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
			
			IniciarSesion (nombre, contrasena, conn, &listaConectados, buff2, sock_conn);
			
			printf ("%s\n", buff2);
			// Y lo enviamos
			write (sock_conn,buff2, strlen(buff2));
			strcpy(buff2,"");
		}
		
		else if (codigo==2) 
			//registrarse
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			strcpy (contrasena, p);	
			
			Registrar  (nombre, contrasena, row, resultado, conn, &listaConectados, buff2, sock_conn, ID_jugador);
			
			printf ("%s\n", buff2);
			// Y lo enviamos
			write (sock_conn,buff2, strlen(buff2));
			
			strcpy(buff2,"");
		}
		
		else if (codigo==3) 
			//record
		{
			p = strtok( NULL, "/");
			int nform=atoi(p);
			DameRecord(conn,buff2,nform);
			printf ("%s\n", buff2);
			write (sock_conn,buff2, strlen(buff2));
			strcpy(buff2,"");
		}
		
		else if (codigo==4)
			//ID de los personajes
		{
			p = strtok( NULL, "/");
			int nform=atoi(p);
			p = strtok( NULL, "/");
			strcpy (ID_partida, p);
			
			DamePersonajes (conn, buff2, ID_partida,nform);
			
			printf ("%s\n", buff2);
			// Y lo enviamos
			write (sock_conn,buff2, strlen(buff2));
			
			strcpy(buff2,"");
		}
		
		else if (codigo==5)
			//Cuantas partidas ha jugado un jugador
		{
			p = strtok( NULL, "/");
			int nform=atoi(p);
			p = strtok( NULL, "/");
			int id=atoi(p);
			
			DamePartidasJugadas(conn, buff2, id,nform);
			
			printf ("%s\n", buff2);
			write (sock_conn,buff2, strlen(buff2));
			
			strcpy(buff2,"");
		}
		
		else if (codigo == 7)
			// cuando el usuario invita a otra persona
			// el cleinte envia un mensaje al servidor con el formato:
			// 7/nombre de la persona a la que quiere invitar
		{
			char jugador2 [20];
			p = strtok( NULL, "/");
			strcpy (jugador2, p);
			
			pthread_mutex_lock(&mutex);
			socket_jugador2 = Damesocket(&listaConectados,jugador2);
			pthread_mutex_unlock(&mutex);
			
			printf("%d, %s\n",socket_jugador2,nombre);
			
			// creamos el mensaje que le llegara al invitado
			// que consiste en 7/nombre del usuario que invita
			sprintf (buff2,"7/%s/%s",nombre,ID_jugador);
			
			// enviamos el socket solo a la persona que queremos invitar
			write (socket_jugador2,buff2, strlen(buff2));
			printf("%s\n",buff2);
			strcpy(buff2,"");
		}
		
		else if (codigo == 8)
			// cuando invitan al cliente
			// el cliente envia un mensaje al servidor con el formato:
			// 8/nombre de la persona que le ha invitado/respuesta
		{
			char jugador2 [20];
			p = strtok( NULL, "/");
			strcpy (jugador2, p);
			p = strtok( NULL, "/");
			char respuesta[1];
			strcpy (respuesta, p);
			
			char buff3[512];
			
			pthread_mutex_lock(&mutex);
			int socket_jugador2 = Damesocket(&listaConectados,jugador2);
			pthread_mutex_unlock(&mutex);
			
			// creamos el mensaje que le llegara a la persona que invita
			// que consiste en 8/respuesta
			
			
			if (strcmp(respuesta,"1")==0)
				//acepta la invitacion
				//guardamos variables ID_partida e ID_oponente
			{
				pthread_mutex_lock(&mutex);
				int ID_partida=PonPartida(&listaPartidas, &listaConectados, conn, nombre, jugador2, sock_conn);
				pthread_mutex_unlock(&mutex);
				sprintf (buff2,"8/%d/%s",ID_partida,nombre);
				sprintf(buff3,"8/%d/%s",ID_partida,jugador2);
				write(sock_conn,buff3,strlen(buff3));
				
				printf("ID partida 2: %d\n",ID_partida);
			}
			else 
				//No ha aceptado la invitación
			{
				sprintf (buff2,"8/%s/%s",respuesta,nombre);
			}
			
			//enviamos el socket solo a la persona que ha hecho la invitacion
			write (socket_jugador2,buff2, strlen(buff2));
			printf("buff2: %s\n buff3: %s\n",buff2,buff3);
			strcpy(buff2,"");
		}
		else if(codigo==9)
			// enviar mensajes por el chat
		{
			p = strtok( NULL, "/");
			int ID= atoi(p);
			p = strtok( NULL, "/");
			char mensaje[400];
			strcpy (mensaje, p);
			int socket;
			sprintf(buff2,"9/%d/%s",ID,mensaje);
			for (int j =0; j<listaPartidas.num;j++)
				if(listaPartidas.partida[j].partida==ID)
					if(strcmp(nombre,listaPartidas.partida[j].jugador1)==0)
						socket=Damesocket(&listaConectados,listaPartidas.partida[j].jugador2);
					else
						socket=Damesocket(&listaConectados,listaPartidas.partida[j].jugador1);
			
			write (socket,buff2, strlen(buff2));
			printf("%s\n",buff2);
		}
		
		else if (codigo==10)
			//el cliente ha ganado
		{
			p = strtok( NULL, "/");
			int id=atoi(p);
			p = strtok( NULL, "/");
			char nombre_ganador [20];
			p = strtok( NULL, "/");
			int dia=atoi(p);
			p = strtok( NULL, "/");
			int mes=atoi(p);
			p = strtok( NULL, "/");
			int ano=atoi(p);
			p = strtok( NULL, "/");
			char hora[11];
			strcpy(hora,p);
			p = strtok( NULL, "/");
			int duracion=atoi(p);
			pthread_mutex_lock(&mutex);
			GuardarPartida(&listaPartidas,conn,nombre,id,dia,mes,ano,duracion,hora);
			EliminarPartida(&listaPartidas,id);
			pthread_mutex_unlock(&mutex);
		}
		
		else if (codigo == 11)
			//el cliente selecciona un personaje
		{
			p = strtok( NULL, "/");
			int id=atoi(p);
			p = strtok( NULL, "/");
			int id_personaje=atoi(p);
			int socket=0;
			
			pthread_mutex_lock(&mutex);
			int err=GuardarPersonaje(&listaPartidas,nombre,id,id_personaje,socket);
			pthread_mutex_unlock(&mutex);
			
			if (err==0)
			{
				sprintf(buff2,"11/%d/0",id);
				write(sock_conn,buff2,strlen(buff2));
			}
			else
			{
				sprintf(buff2,"11/%d/1",id);
				write(socket,buff2,strlen(buff2));
			}
		}
		
		else if (codigo == 12)
			//el cliente intenta adivinar el personaje del oponente
		{
			p = strtok( NULL, "/");
			int id=atoi(p);
			p = strtok( NULL, "/");
			int id_personaje=atoi(p);
			
			char buff3[512];
			int socket;
			
			pthread_mutex_lock(&mutex);
			AdivinarPersonaje(&listaPartidas,nombre,id,id_personaje,buff2,buff3);
			
			for (int j =0; j<listaPartidas.num;j++)
				if(listaPartidas.partida[j].partida==id)
				if(strcmp(nombre,listaPartidas.partida[j].jugador1)==0)
					socket=Damesocket(&listaConectados,listaPartidas.partida[j].jugador2);
				else
					socket=Damesocket(&listaConectados,listaPartidas.partida[j].jugador1);
			
			pthread_mutex_unlock(&mutex);
			
			write(sock_conn,buff2,strlen(buff2));
			write(socket,buff3,strlen(buff3));
			printf("%s\n%s\n",buff2,buff3);
		}

		else if (codigo==13)
			//el cliente pide sus resultados con un jugador
		{
			p = strtok( NULL, "/");
			int nform=atoi(p);
			p = strtok( NULL, "/");
			p = strtok( NULL, "/");
			int id=atoi(p);
			
			DameMisResultadosCon(conn,id,nform,buff2,nombre);
			
			write(sock_conn,buff2,strlen(buff2));
		}
		
		else if (codigo==14)
			//el cliente pide las partidas jugadas en un periodo determinado
		{
			p = strtok( NULL, "/");
			int nform=atoi(p);
			p = strtok( NULL, "/");
			int dia=atoi(p);
			p = strtok( NULL, "/");
			int mes=atoi(p);
			p = strtok( NULL, "/");
			int ano=atoi(p);
			char fechamin[11];
			
			if((dia<10)&&(mes<10))
				sprintf(fechamin,"0%d/0%d/%d",dia,mes,ano);
			else if((dia<10)&&(mes>=10))
				sprintf(fechamin,"0%d/%d/%d",dia,mes,ano);
			else if((dia>=10)&&(mes<10))
				sprintf(fechamin,"%d/0%d/%d",dia,mes,ano);
			else
				sprintf(fechamin,"%d/%d/%d",dia,mes,ano);
			
			p = strtok( NULL, "/");
			nform=atoi(p);
			p = strtok( NULL, "/");
			dia=atoi(p);
			p = strtok( NULL, "/");
			mes=atoi(p);
			p = strtok( NULL, "/");
			ano=atoi(p);
			char fechamax[11];
			if((dia<10)&&(mes<10))
				sprintf(fechamax,"0%d/0%d/%d",dia,mes,ano);
			else if((dia<10)&&(mes>=10))
				sprintf(fechamax,"0%d/%d/%d",dia,mes,ano);
			else if((dia>=10)&&(mes<10))
				sprintf(fechamax,"%d/0%d/%d",dia,mes,ano);
			else
				sprintf(fechamax,"%d/%d/%d",dia,mes,ano);
			
			DamePartidasFecha(conn,fechamin,fechamax,nform,buff2);
			
			write(sock_conn,buff2,strlen(buff2));			
		}
			
		else if(codigo==15)
			//jugador abandona la partida
		{
			p = strtok( NULL, "/");
			int id=atoi(p);
			int socket;
			
			for (int j =0; j<listaPartidas.num;j++)
			{
				if(listaPartidas.partida[j].partida==id)
				{
					if(strcmp(nombre,listaPartidas.partida[j].jugador1)==0)
						socket=Damesocket(&listaConectados,listaPartidas.partida[j].jugador2);
					else
						socket=Damesocket(&listaConectados,listaPartidas.partida[j].jugador1);
				}
			}
			
			sprintf(buff2,"15/%d",id);
			write(socket,buff2,strlen(buff2));
		}
		
	}
	
	pthread_mutex_lock(&mutex); //no me interrumpas ahora
	
	//eliminamos al usuario de la lista de conectados 
	int eliminar= EliminarConectados (&listaConectados, nombre);
	EliminarSocket(sockets,sock_conn);
	
	pthread_mutex_unlock(&mutex); //ya puedes interrumpirme

	
	if (eliminar==0)
		printf("Se ha eliminado a %s de la lista de conectados",nombre);
	else
		printf("Error al eliminar a %s de la lista de conectados",nombre);
	
	//Envia la lista de conectados actualizada a todos los usuarios
	char conectados[512];
	Dameconectados (&listaConectados, conectados);
	sprintf(notificacion,"6/%s",conectados);
	
	printf("%s\n",notificacion);
	
	//notificar a todos los clientes conectados
	for(int j =0; j<num_sockets;j++)
	{
		write(sockets[j],notificacion,strlen(notificacion));
	}
	strcpy(notificacion,"");
	//Desconectamos al usuario del servidor
	strcpy(buff2,"");
	close(sock_conn);
	mysql_close(conn);
}

int main(int argc, char *argv[])
{
	listaConectados.num=0;
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 
	serv_adr.sin_port = htons(port);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	pthread_t thread[100];
	num_sockets=0;
	
	for(;;)
	{ //bucle infinito
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		//Bucle de atención al cliente
		
		// Se acabo el servicio para este cliente
		sockets[num_sockets] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread[num_sockets], NULL, AtenderCliente,&sockets[num_sockets]);
		num_sockets++;
	}
	

	exit(0);
}

