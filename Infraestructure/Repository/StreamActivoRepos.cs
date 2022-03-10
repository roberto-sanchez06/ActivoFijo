using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class StreamActivoRepos : IActivoModel 
    {
        //private FileStream fileStream;
        private StreamReader binaryReader;
        private StreamWriter binaryWriter;
        private string filename = "activo.dat";

        public StreamActivoRepos()
        {
        }

        public void Add(Activo t)
        {
            try
            {
                //el using se encarga de cerrar todos los flujo, ya que si no cerramos el puerto no no s va a permitir acceder 
                using (FileStream fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write))
                {
                    binaryWriter = new StreamWriter(fileStream);
                    binaryWriter.Write(t.Id);
                    binaryWriter.Write(t.Nombre);
                    binaryWriter.Write(t.VidaUtil);
                    binaryWriter.Write(t.Valor);
                    binaryWriter.Write(t.ValorResidual);
                }
            }
            catch (IOException)
            {

                throw;
            }
        }

        public void Delete(Activo t)
        {
            throw new NotImplementedException();
        }

        public Activo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Activo> Read()
        {
            List<Activo> activos = new List<Activo>();
            try
            {
                //el using se encarga de cerrar todos los flujo, ya que si no cerramos el puerto no no s va a permitir acceder 
                using (FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    binaryReader = new StreamReader(fileStream);
                    BinaryReader br = new BinaryReader(binaryReader.BaseStream);
                    while (!binaryReader.EndOfStream)
                    {
                        activos.Add(new Activo()
                        {
                            Id = br.ReadInt32(),
                            Nombre = br.ReadString(),
                            Valor = br.ReadDouble(),
                            VidaUtil = br.ReadInt32(),
                            ValorResidual = br.ReadDouble()
                        });
                    }

                    binaryWriter.Close();
                }
                return activos;
            }
            catch (IOException)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
