﻿using System;
using System.Collections.Generic;
using System.Linq;
using Calculus;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Unidad1
{
    public class Actividad1 : Entrada
    {
        //public static float funcion(float x)
        //{
        //    return (float)(8 * x - 7); //----------> 8X - 7
        //    //return (float)((Math.Pow(x, 3) + 5)); ---> X^3 + 5
        //    //return (float)((Math.Pow(x,3)) - (5 * x) + 6); -----------> X^3 - 5X + 6
        //    //return (float)((Math.Pow(x, 5)) + (4 * (Math.Pow(x, 2))) + x - 5);  --------> x^5 + 4x^2 + x -5

        //    //return 0;

        //}


        private static Resultado Analizador(string func)
        {
            Resultado nuevo = new Resultado(0, 0, 0, true, "");
            double fx;
            Calculo AnalizadorDeFuncion = new Calculo();
            if (!AnalizadorDeFuncion.Sintaxis(func, 'x'))
            {
                nuevo.SePudo = false;
                nuevo.Mensaje = "Expresion no valida";
            }
            return nuevo;
        }

        private static float Fx(string func, double x)
        {
            double f = 0;
            Calculo funcion = new Calculo();
            if (funcion.Sintaxis(func, 'x'))
                f = funcion.EvaluaFx(x);
            return (float)f;
        }

        public static Resultado Biseccion(string func, int citer, double tole, float xi, float xd)
        {
            Resultado nuevo = Analizador(func);
            if (nuevo.SePudo)
            {
                double operacion = Fx(func,xi) * Fx(func,xd);
                if (operacion < 0)
                {
                    bool band = false; float error = 0;
                    int contador = 0;
                    float xant = 0;
                    float xr = (xi + xd) / 2;
                    if ((xi + xd) == 0)
                        error = 1;
                    else
                        error = Math.Abs((xr - xant) / xr);
                    while ((Math.Abs(Fx(func,xr)) >= tole || Math.Abs(Fx(func, xr)) == 0) && contador < citer && 
                        error > tole && band == false)
                    {
                        contador += 1;
                        xr = (xi + xd) / 2;
                        if ((xi + xd) == 0)
                            error = 1;
                        else
                            error = Math.Abs((xr - xant) / xr);
                        if (Math.Abs(Fx(func,xr)) < tole || contador > citer || error < tole)
                        {
                            nuevo.Solucion = xr;
                            nuevo.Iter = contador;
                            if (Math.Abs(Fx(func, xr)) < tole)
                                nuevo.Tole = Math.Abs(Fx(func, xr));
                            else
                                nuevo.Tole = error;
                            band = true;
                        }
                        else
                        {
                            if (Fx(func,xi) * Fx(func,xr) < 0)
                            {
                                xd = xr;
                            }
                            else
                            {
                                xi = xr;
                            }
                            xant = xr;
                        }
                    }
                }
                else
                {
                    if (operacion == 0)
                    {
                        if (Fx(func,xi) == 0)
                            nuevo.Solucion = xi;

                        else
                            nuevo.Solucion = xd;
                    }
                    else
                    {
                        nuevo.SePudo = false;
                        nuevo.Mensaje = "Limite Derecho o Izquierdo incorrectos, por favor ingreselos nuevamente";
                    }

                }
            }
            return nuevo;
        }

        public static Resultado ReglaFalsa(string func, int citer, double tole, float xi, float xd)
        {
            Resultado nuevo = Analizador(func);
            if (nuevo.SePudo)
            {
                double operacion = Fx(func,xi) * Fx(func,xd);
                if (operacion < 0)
                {
                    bool band = false; float error = 0;
                    int contador = 0;
                    float xant = 0;
                    float xr = ((-(Fx(func,xd)) * xi) + (Fx(func,xi) * xd)) / (Fx(func,xi) - Fx(func,xd));
                    if ((xi + xd) == 0)
                        error = 1;
                    else
                        error = Math.Abs((xr - xant) / xr);
                    while ((Math.Abs(Fx(func, xr)) >= tole || Math.Abs(Fx(func, xr)) == 0) && contador < citer &&
                        error > tole && band == false)
                    {
                        contador += 1;
                        xr = ((-Fx(func,xd) * xi) + (Fx(func,xi) * xd)) / (Fx(func,xi) - Fx(func,xd));
                        if ((xi + xd) == 0)
                            error = 1;
                        else
                            error = Math.Abs((xr - xant) / xr);
                        if (Math.Abs(Fx(func,xr)) < tole || contador > citer || error < tole)
                        {
                            nuevo.Solucion = xr;
                            nuevo.Iter = contador;
                            if (Math.Abs(Fx(func, xr)) < tole)
                                nuevo.Tole = Math.Abs(Fx(func, xr));
                            else
                                nuevo.Tole = error;
                            band = true;
                        }
                        else
                        {
                            //if (Fx(func, xi) * Fx(func, xr) < 0)
                            //{
                            //    xd = xr;
                            //}
                            //else
                            //{
                            //    xi = xr;
                            //}
                            xant = xr;
                        }
                    }
                }
                else
                {
                    if (operacion == 0)
                    {
                        if (Fx(func,xi) == 0)
                            nuevo.Solucion = xi;

                        else
                            nuevo.Solucion = xd;
                    }
                    else
                    {
                        nuevo.SePudo = false;
                        nuevo.Mensaje = "Limite Derecho o Izquierdo incorrectos, por favor ingreselos nuevamente";
                    }

                }
            }
            return nuevo;
        }

        public static Resultado Tangente(string func, int citer, double tole, float x)
        {
            Resultado nuevo = Analizador(func);
            if (nuevo.SePudo)
            {
                double operacion = Fx(func, x);
                if (operacion != 0)
                {
                    bool band = false; float error = 0;
                    int contador = 0;
                    float xant = 0;
                    float xr = x;
                    error = Math.Abs((xr - xant) / xr);
                    while ((Math.Abs(Fx(func, xr)) >= tole || Math.Abs(Fx(func, xr)) == 0) && contador < citer &&
                        error > tole && band == false)
                    {
                        contador += 1;
                        xr = xr - (Fx(func, xr)/((Fx(func, xr + (float)tole) - Fx(func, xr))/ (float)tole));
                        error = Math.Abs((xr - xant) / xr);
                        if (Math.Abs(Fx(func, xr)) < tole || contador > citer || error < tole)
                        {
                            nuevo.Solucion = xr;
                            nuevo.Iter = contador;
                            if (Math.Abs(Fx(func, xr)) < tole)
                                nuevo.Tole = Math.Abs(Fx(func, xr));
                            else
                                nuevo.Tole = error;
                            band = true;
                        }
                        else
                        { xant = xr; }
                    }
                }
                else
                { nuevo.Solucion = x; }
            }
            return nuevo;
        }
    }
}