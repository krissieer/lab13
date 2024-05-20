using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public class JournalEntry
    {
        /// <summary>
        /// Название коллекции
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Тип изменения
        /// </summary>
        public string TypeChange { get; set; }
        /// <summary>
        /// Данные изменяемого объекта
        /// </summary>
        public string ObjectData { get; set; }

        public JournalEntry(string name, string type, string obj)
        {
            Name = name;
            TypeChange = type;
            ObjectData = obj;
        }

        public override string ToString()
        {
            return $"КОЛЛЕКЦИЯ: {Name}. ТИП ИЗМЕНЕНИЯ: {TypeChange}. ОБЪЕКТ: {ObjectData}";
        }
    }
}
