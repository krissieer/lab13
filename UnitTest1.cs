using lab13;
using ClassLibraryLab10;
using System.Xml.Linq;
namespace TestLab_13
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorMyCollrction()
        {
            MyObservableCollection<MusicalInstrument> coll = new MyObservableCollection<MusicalInstrument>(8);
            Assert.AreEqual(8, coll.Count);
        }

        [TestMethod]
        public void GetItem()
        {
            MyObservableCollection<MusicalInstrument> coll = new MyObservableCollection<MusicalInstrument>(8);
            MusicalInstrument m = new MusicalInstrument("mmm", 11);
            coll.Add(m);
            MusicalInstrument m1 = coll[m.Name];
            Assert.AreEqual(m1,m);
        }

        [TestMethod]
        public void GetItem2()
        {
            MyObservableCollection<MusicalInstrument> coll = new MyObservableCollection<MusicalInstrument>(8);
            MusicalInstrument m = new MusicalInstrument("aaaa", 11);
            coll.Add(m);
            MusicalInstrument m1 = coll[m.Name];
            Assert.AreEqual(m1, m);
        }

        [TestMethod]
        public void SetItem()
        {
            MyObservableCollection<MusicalInstrument> coll = new MyObservableCollection<MusicalInstrument>(8);
            MusicalInstrument m = new MusicalInstrument("m1", 11);
            coll.Add(m);
            MusicalInstrument m2 = new MusicalInstrument("m2", 22);
            coll[m.Name] = m2;
            Assert.IsNull(coll.FindName(m.Name));
            Assert.IsNotNull(coll.FindName(m2.Name));
        }

        [TestMethod]
        public void SetItemException()
        {
            MyObservableCollection<MusicalInstrument> coll = new MyObservableCollection<MusicalInstrument>(8);
            MusicalInstrument m = new MusicalInstrument("m1", 11);
            try
            {
                MusicalInstrument m2 = new MusicalInstrument("m2", 22);
                coll[m.Name] = m2;
            }
            catch (Exception ex)
            {
                Assert.AreEqual($"Элемента с названием {m.Name} нет в коллекции", ex.Message);
            }
        }

        [TestMethod]
        public void JournalWrireRecord()
        {
            MyObservableCollection<MusicalInstrument> coll = new MyObservableCollection<MusicalInstrument>(8);
            coll.CollectionName = "coll";
            Journal jornal = new Journal();
            coll.collectionCountChanged += jornal.WrireRecord;
            coll.collectionReferenceChanged += jornal.WrireRecord;
            MusicalInstrument m = new MusicalInstrument("m1", 11);
            coll.Add(m);
            MusicalInstrument m2 = new MusicalInstrument("m2", 22);
            coll[m.Name] = m2;
            Assert.IsNull(coll.FindName(m.Name));
            Assert.IsNotNull(coll.FindName(m2.Name));
            Assert.IsNotNull(jornal);
        }

        [TestMethod]
        public void JournalEntryToString()
        {
            JournalEntry j = new JournalEntry("coll", "Добавление", "item");
            Assert.AreEqual("КОЛЛЕКЦИЯ: coll. ТИП ИЗМЕНЕНИЯ: Добавление. ОБЪЕКТ: item", j.ToString());
        }

        [TestMethod]
        public void JournalPrint()
        {
            MyObservableCollection<MusicalInstrument> coll = new MyObservableCollection<MusicalInstrument>(2);
            coll.CollectionName = "coll";
            Journal jornal = new Journal();
            coll.collectionCountChanged += jornal.WrireRecord;
            MusicalInstrument m = new MusicalInstrument("m1", 11);
            coll.Add(m);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                jornal.PrintJornal();
                string expected = $"КОЛЛЕКЦИЯ: coll. ТИП ИЗМЕНЕНИЯ: Добавление. ОБЪЕКТ: {m}" + Environment.NewLine;
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void JournalPrintEmpty()
        {
            Journal jornal = new Journal();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                jornal.PrintJornal();
                string expected = "Журнал пустой" + Environment.NewLine;
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}