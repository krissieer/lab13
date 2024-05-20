using ClassLibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public class Journal
    {
        List<JournalEntry> jornal = new List<JournalEntry>();

        public void WrireRecord(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry element = new JournalEntry(((MyObservableCollection<MusicalInstrument>)source).CollectionName, args.TypeChange, args.ChangedObject.ToString());
            jornal.Add(element);
        }

        public void PrintJornal()
        {
            if (jornal.Count == 0)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }
            foreach (JournalEntry item in jornal)
            {
                Console.WriteLine(item);
            }   

        }
    }
}
