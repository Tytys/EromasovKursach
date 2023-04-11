using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EromasovKursach.DataFolder
{
    internal class ContextClass
    {
        private static DBEntities context;

        public static DBEntities GetContext()
        {
            if (context == null)
            {
                context = new DBEntities();
            }
            return context;
        }
    }
}
