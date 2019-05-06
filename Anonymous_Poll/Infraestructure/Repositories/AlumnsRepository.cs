using System;
using System.Collections.Generic;
using System.IO;
using Anonymous_Poll.Infraestructure.Interfaces;
using Anonymous_Poll.Models;
using System.Linq;


namespace Anonymous_Poll.Infraestructure.Repositories
{
    public class AlumnsRepository : I_AlumnsRepository
    {
        private List<Alumn> Alumns = null;

        public AlumnsRepository()
        {
            this.processFile();
        }

        public string search(InputCase inputCase)
        {
            IEnumerable<Alumn> found = this.Alumns.Where(

                alumn =>

                    alumn.Age == inputCase.Age &&
                    alumn.AcademicYear == inputCase.AcademicYear &&
                    alumn.Gender == inputCase.Gender &&
                    alumn.Studies == inputCase.Studies

                );

            if (found.Count() > 0)

                return found.OrderBy(alumn => alumn.Name).Select(alumn => alumn.Name).Aggregate((x, y) => x + ", " + y);

            return null;
        }

        public List<Alumn> getAlumns()
        {
            return this.Alumns;
        }

        public void processFile()
        {
            this.Alumns = new List<Alumn>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data/Data.txt");
            StreamReader reader = new StreamReader(path);
            string[] rows = reader.ReadToEnd().Split(new char[] { '\n' });
            string[] values = null;
            foreach (string row in rows)
            {
                values = row.Split(new char[] { ',' });
                this.Alumns.Add(new Alumn()
                {
                    Age = Convert.ToUInt16(values[2]),
                    Name = values[0],
                    Gender = Convert.ToChar(values[1]),
                    Studies = values[3],
                    AcademicYear = Convert.ToUInt16(values[4])
                });
            }
        }
    }
}
