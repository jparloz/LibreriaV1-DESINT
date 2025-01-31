﻿using LibreriaV3._1.Modelo;
using System;

public class Estanteria
{   	   
    //Propiedades
    //Limite de registros en el array
    const int max_Reg = 5;
    //Array normal con objetos Libro dentro y un valor maximo de la variable max_reg
    Libro[] libros = new Libro[max_Reg];
    //Reg es el contador de registros, que nos sirve para saber la cantidad de libros almacenados
    private int reg = 0;
    //Variable que uso, para moverme entre el array, y no crearla a nivel local de m�todo

    /// <summary>
    ///  <para>
    ///        Introducimos por parametros un libro previamente creado.
    ///  </para>
    ///    
    ///  <para>
	///        Comprobamos que no exista o que el array no esté lleno y si se cumple todo lo introducimos
    ///  </para>
    /// 
    /// </summary>
    /// <param name="libro">Admite parámetro del tipo Libro</param>
    /// <returns>
    /// Devolvera valores de : 1 en caso de libro introducido <br />
    ///       -1 en caso de que el libro ya exista<br/>
    ///       0 en caso de que el array este lleno
    /// </returns>
    public int insertarLibro(Libro libro)
    {
        int estado;
        if (reg < max_Reg)
        {
            if (posicionLibro(libro.Titulo) == -1)
            {
                libros[reg] = (Libro)libro;
                estado = 1;
                reg++;
            }
            else
            {
                estado = -1;
            }
        }
        else
        {
            estado = 0;
        }

        return estado;
    }

     /**
	 * Introducimos por parametros un libro previamente creado.
	 * Comprobamos que no exista o que el array no est� lleno y si se cumple todo lo introducimos
	 * @param libro
	 * @return Devolvera valores de : 1 en caso de libro introducido
	 * 								 -1 en caso de que el libro ya exista
	 * 								  0 en caso de que el array este lleno
	 */
    public int modificarLibro(Libro libro)
    {
        int pos = posicionLibro(libro.Titulo);
        if (pos != -1)
        {
            libros[pos] = (Libro)libro;
        }
        return pos;
    }

    /**
	 * Entra por parametros una String con un titulo, y te devuelve el objeto libro exacto
	 * @param nombre
	 * @return
	 */
    public Libro buscarLibro(String nombre)
    {
        int loc = 0;
        while (loc < max_Reg)
        {
            if (libros[loc] != null)
            {
                if (libros[loc].Titulo.Equals(nombre))
                {
                    return libros[loc];
                }
            }
            loc++;
        }
        return null;
    }


    /**
	 * 
	 * @param nombre
	 * @return 1 en caso de borrar el libro, 0 en caso de error
	 */
    /*
	 * Puesto que para borrar necesito una posici�n exacta, llamo al metodo buscarLibro que me la devuelve a 
	 * trav�s de un nombre
	 */
    public int borrarLibro(String nombre)
    {
        int loc = posicionLibro(nombre);

        libros[loc] = libros[reg - 1];
        reg--;

        return 1;
    }

    /// <summary>
    ///     Introduce un nombre de un libro por parametros y lo busca
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns>La posición del libro, en caso de que esté, o -1 si no está</returns>
    private int posicionLibro(String nombre)
    {
        int loc = 0;
        /*
		 * Uso 2 metodos para buscar libro, puesto que para cargarlo en pantalla es simple sabiendo el libro
		 * Pero para borrarlo, en un array normal, necesito la posici�n exacta, con lo cual para no repetir el mismo
		 * codigo en "BorrarLibro", monto 2 metodos.
		 */
        while (loc < max_Reg)
        {
            if (libros[loc] != null)
            {
                if (nombre.Equals(libros[loc].Titulo))
                {
                    return loc;
                }

                loc++;
            }
            else loc++;
        }

        return -1;
    }


}
