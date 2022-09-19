using System;
class Juego
{
    static int[,] tablero;
    static char[] turno = {' ','X','O'};
    static int jugador=1;
    static bool estado=false;
    static int contIA=0;
    static void Main()
    {
        tablero = new int[3, 3];
        InicioPartida();
        do
        {
            DibujarTablero();
            if (jugador==2)
            {
                Console.Write("Pensando.");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(".");
                }                
            }
                
            VerificarTurno();
            EstadoJuego();
        }
        while (!estado);
    }
    private static string JugadaIA()
    {
        if (((tablero[0, 1] == tablero[0, 2]) && (tablero[0, 0] == 0)) || ((tablero[1, 1] == tablero[2, 2]) && (tablero[0, 0] == 0)) || ((tablero[1, 0] == tablero[2, 0]) && (tablero[0, 0] == 0)))
            return "11";
        if (((tablero[0, 0] == tablero[0, 2]) && (tablero[0, 1] == 0)) || ((tablero[1, 1] == tablero[2, 1]) && (tablero[0, 1] == 0)))
            return "12";
        if (((tablero[0, 0] == tablero[0, 1]) && (tablero[0, 2] == 0)) || ((tablero[2, 0] == tablero[1, 1]) && (tablero[0, 2] == 0)) || ((tablero[2, 2] == tablero[1, 2]) && (tablero[0, 2] == 0)))
            return "13";

        if (((tablero[1, 1] == tablero[1, 2]) && (tablero[1, 0] == 0)) || ((tablero[0, 0] == tablero[2, 0]) && (tablero[1, 0] == 0)))
            return "21";
        if (((tablero[0, 0] == tablero[2, 2]) && (tablero[1, 1] == 0)) || ((tablero[2, 0] == tablero[0, 2]) && (tablero[1, 1] == 0)))
            return "22";
        if (((tablero[0, 1] == tablero[2, 1]) && (tablero[1, 1] == 0)) || ((tablero[1, 0] == tablero[1, 2]) && (tablero[1, 1] == 0)))
            return "22";
        if (((tablero[1, 0] == tablero[1, 1]) && (tablero[1, 2] == 0)) || ((tablero[0, 2] == tablero[2, 2]) && (tablero[1, 2] == 0)))
            return "23";

        if (((tablero[0, 0] == tablero[1, 0]) && (tablero[2, 0] == 0)) || ((tablero[2, 1] == tablero[2, 2]) && (tablero[2, 0] == 0)) || ((tablero[1, 1] == tablero[0, 2]) && (tablero[2, 0] == 0)))
            return "31";
        if (((tablero[0, 1] == tablero[1, 1]) && (tablero[2, 1] == 0)) || ((tablero[2, 0] == tablero[2, 2]) && (tablero[2, 1] == 0)))
            return "32";
        if (((tablero[0, 2] == tablero[1, 2]) && (tablero[2, 2] == 0)) || ((tablero[2, 0] == tablero[2, 1]) && (tablero[2, 2] == 0)) || ((tablero[0, 0] == tablero[1, 1]) && (tablero[2, 2] == 0)))
            return "33";
        return "0";
    }
    private static void InicioPartida()
    {
        Console.WriteLine("┌───────────────────────────┐");
        Console.WriteLine("│ QUIEN INICIA EL JUEGO     │");
        Console.WriteLine("├───────────────────────────┤");
        Console.WriteLine("│ HUMANO   -->  1           │");
        Console.WriteLine("│ IA       -->  2           │");
        Console.WriteLine("└───────────────────────────┘");
        Console.Write("ELIJA SU OPCION:");
        jugador = Convert.ToInt32(Console.ReadLine());
    }

    private static void DibujarTablero()
    {
        Console.Clear();
        Console.WriteLine("       A   B   C");
        Console.WriteLine("     ┌───┬───┬───┐");
        for (int i = 0; i <= 2; i++)
        {
            Console.Write("   "+(i+1) + " │");
            for (int j = 0; j <=2; j++)
            {
            //Console.Write(turno[tablero[i,j]]+ " │");
            Console.Write(" "+turno[tablero[i,j]] + " │");
            }
            Console.WriteLine();
            if (i<2)
            Console.WriteLine("     ├───┼───┼───┤");
            else
            Console.WriteLine("     └───┴───┴───┘");
        }
    }
    private static void VerificarTurno()
    {
        int x = 0, y = 0;
        char z;
        bool casilla = false;
        var ia = new Random();
        string iaJugada;

        while (!casilla)
        {
            if (turno[jugador] == 'O')
                Console.WriteLine("      JUGADOR IA:");
            else
                Console.WriteLine("      JUGADOR HUMANO:");
            Console.Write("      Ingrese Fila:");
            if (turno[jugador] == 'O')
            {
                if(contIA<2)
                x = ia.Next(1, 4);
                else
                {
                    iaJugada = JugadaIA();
                    if(iaJugada!="0")
                    {
                        x = iaJugada[0];
                        x = x - 48;
                        y = iaJugada[1];
                        y = y - 48;
                    }
                    else
                    {
                        iaJugada=ultimaJugada();
                        x = iaJugada[0];
                        x = x - 48;
                        y = iaJugada[1];
                        y = y - 48;
                    }
                }                
                Console.WriteLine(x);
                x -= 1;
            }
            else
            {
                x = Convert.ToInt32(Console.ReadLine()) - 1;
            }            
            Console.Write("      Ingrese Columna:");

            if (turno[jugador] == 'O')
            {
                if (contIA < 2)
                {
                    y = ia.Next(1, 4);
                    contIA += 1;
                }                
                switch (y)
                {
                    case 1:
                        Console.WriteLine('A');
                        break;
                    case 2:
                        Console.WriteLine('B');
                        break;
                    case 3:
                        Console.WriteLine('C');
                        break;
                }
                y -= 1;
            }
            else
            {
                z = Convert.ToChar(Console.ReadLine());
                switch (z)
                {
                    case 'A' or 'a':
                        y = 0;
                        break;
                    case 'B' or 'b':
                        y = 1;
                        break;
                    case 'C' or 'c':
                        y = 2;
                        break;
                }
            }           
            if ((x >= 0 && x < 3) && (y >= 0 && y < 3) && tablero[x, y] == 0)
                casilla = true;
            else
            {
                Console.WriteLine("      CASILLA YA UTILIZADA.......Presione una tecla para continuar!!!");
                contIA -= 1;
                Console.ReadKey();
                DibujarTablero();
            }                
        }        
        tablero[x, y] = jugador;
    }

    private static string ultimaJugada()
    {
        if (tablero[0, 0] == 0)
            return "11";
        if (tablero[0, 1] == 0)
            return "12";
        if (tablero[0, 2] == 0)
            return "13";
        if (tablero[1, 0] == 0)
            return "21";
        if (tablero[1, 1] == 0)
            return "22";
        if (tablero[1, 2] == 0)
            return "23";
        if (tablero[2, 0] == 0)
            return "31";
        if (tablero[2, 1] == 0)
            return "32";
        else
            return "33";
    }

    private static void EstadoJuego()
    {
        bool juegoTerminado = false;
        for (int i = 0; i < 3; i++)
        {
            if (
                ((tablero[i, 0] == tablero[i, 1]) &&
                (tablero[i, 1] == tablero[i, 2]) &&
                (tablero[i, 2] == jugador)) ||
                ((tablero[0, i] == tablero[1, i]) &&
                (tablero[1, i] == tablero[2, i]) &&
                (tablero[2, i] == jugador))
                )
                juegoTerminado = true;
        }
        if(((tablero[0, 0] == tablero[1,1]) &&
            (tablero[1, 1] == tablero[2, 2]) &&
            (tablero[2, 2] == jugador)) ||
            ((tablero[0,2] == tablero[1,1]) &&
            (tablero[1, 1] == tablero[2, 0]) &&
            (tablero[2,0] == jugador)))
            juegoTerminado=true;
        if (juegoTerminado)
            {
            DibujarTablero();
            if (turno[jugador]=='O')
                Console.WriteLine("      Felicidades!!! Gano IA COMPUTADOR");
            else
                Console.WriteLine("      Felicidades!!! Gano HUMANO");
            estado = true;
            }
        else
        {
            int cantidadTurns = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (tablero[i, j] == 0)
                        cantidadTurns++;
            if (cantidadTurns == 0)
            {
                DibujarTablero();
                Console.WriteLine("    ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡  Empate  !!!!!!!!!!!!!!!!");
                Console.Read();
                estado = true;
            }
        }
        if (jugador == 1)
            jugador = 2;
        else
            jugador = 1;
            
        //CambioJugador(jugador);
        
    }

    private static void CambioJugador(int jugador)
    {
        if (jugador == 1)
            jugador = 2;
        else
            jugador = 1;
    }
}
