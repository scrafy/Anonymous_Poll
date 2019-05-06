using System;
using System.Collections.Generic;
using Anonymous_Poll.Models;

namespace Anonymous_Poll.Infraestructure.Interfaces
{
    public interface I_AlumnsRepository
    {
        List<Alumn> getAlumns();
        string search(InputCase inputCase);
        void processFile();

    }
}
