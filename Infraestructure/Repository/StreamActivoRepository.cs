using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class StreamActivoRepository
    {
        private FileStream fileStream;
        private BinaryReader binaryReader;
        private BinaryWriter binaryWriter;
        private string filename = "Activo.dat";

        public StreamActivoRepository()
        {
        }

        public void Add(Activo t)
        {
            try
            {
                //el using se encarga de cerrar todos los flujo, ya que si no cerramos el puerto no no s va a permitir acceder 
                using (FileStream fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write))
                {
                    binaryWriter = new BinaryWriter(fileStream);
                    binaryWriter.Write(t.id);
                    binaryWriter.Write(t.nombre);
                    binaryWriter.Write(t.vidaUtil);
                    binaryWriter.Write(t.valor);
                    binaryWriter.Write(t.valorResidual);
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
                    binaryReader = new BinaryReader(fileStream);
                    //binaryReader.Write(t.id);
                    //binaryWriter.Write(t.nombre);
                    //binaryWriter.Write(t.vidaUtil);
                    //binaryWriter.Write(t.valor);
                    //binaryWriter.Write(t.valorResidual);
                }
            }
            catch (IOException)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
