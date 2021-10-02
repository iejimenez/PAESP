﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Models
{
    public class Data
    {
       
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Data() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Data _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static Data GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Data();
            }
            return _instance;
        }


        public List<Usuario> Usuarios = new List<Usuario>();

        public List<Preinscripcion> Preinscripciones = new List<Preinscripcion>();
         

        public Usuario getUsuario(string tipo, string identificacion)
        {
            Usuario userBd = Usuarios.Where(s => s.TipodeIdentificacion == tipo && s.Cedula == identificacion).FirstOrDefault();
            return userBd;
        }

        public void AddUsuario(Usuario usuario)
        {
            this.Usuarios.Add(usuario);
            Guid g = Guid.NewGuid();
            usuario.Id = Guid.NewGuid().ToString();
        }

        public Preinscripcion getPreinscripcion(string iduser)
        {
            return Preinscripciones.Where(p => p.IdPersona == iduser).Select(s => new Preinscripcion() {
                IdPersona = s.IdPersona, 
                FechaDePreInscripcion = s.FechaDePreInscripcion,
                IdPresinscripcion = s.IdPresinscripcion,
                NumeroRecibo = s.NumeroRecibo,
                Persona = Usuarios.Where(u=>u.Id == s.IdPersona).FirstOrDefault()
            }).FirstOrDefault();
        }

        public void AddPreinscripcion(Preinscripcion preinscripcion)
        {
            this.AddUsuario(preinscripcion.Persona);
            preinscripcion.IdPersona = preinscripcion.Persona.Id;
            Guid g = Guid.NewGuid();
            preinscripcion.IdPresinscripcion = Guid.NewGuid().ToString();
            this.Preinscripciones.Add(preinscripcion);
        }

        public void LimpiarUsuario()
        {
            this.Usuarios.Clear();
        }
    }
}
