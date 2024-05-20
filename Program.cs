using ClassLibraryLab10;
using ClassLibraryMyCollection;
using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.Marshalling;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab13
{
    public class Program
    {
        static void Delete(MusicalInstrument item, MyObservableCollection<MusicalInstrument> collection)
        {
            if (collection.Contains(item))
            {
                collection.Remove(item);
                Console.WriteLine($"Элемент {item} удален");
            }
            else
                Console.WriteLine($"Элемента ' {item} ' нет в таблице");
        }

        static void RemoveElement(MyObservableCollection<MusicalInstrument> collection)
        {
            if (collection.Count <= 0 || collection == null)
                Console.WriteLine("Таблица пуста");
            else
            {
                int choice;
                bool isCorrect;
                Console.WriteLine("1. Музыкальные инструменты");
                Console.WriteLine("2. Гитары");
                Console.WriteLine("3. Электрогитары");
                Console.WriteLine("4. Фортепиано");
                Console.WriteLine();

                do
                {
                    isCorrect = int.TryParse(Console.ReadLine(), out choice);
                    if (!isCorrect || choice < 0) Console.WriteLine("Неверный ввод. Попробуйте еще раз");
                } while (!isCorrect || choice < 0);

                switch (choice)
                {
                    case 1:
                        MusicalInstrument m = new MusicalInstrument();
                        m.Init();
                        Delete(m, collection);
                        break;
                    case 2:
                        Guitar g = new Guitar();
                        g.Init();
                        Delete(g, collection);
                        break;
                    case 3:
                        ElectricGuitar e = new ElectricGuitar();
                        e.Init();
                        Delete(e, collection);
                        break;
                    case 4:
                        Piano p = new Piano();
                        p.Init();
                        Delete(p, collection);
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            MyObservableCollection<MusicalInstrument> c1 = new MyObservableCollection<MusicalInstrument>(10);
            MyObservableCollection<MusicalInstrument> c2 = new MyObservableCollection<MusicalInstrument>(10);
            Console.WriteLine(" === КОЛЛЕКЦИЯ №1 И КОЛЛЕКЦИЯ №2 СОЗДАНЫ ===");

            Journal journal1= new Journal();
            Journal journal2 = new Journal();

            int ans;

            c1.collectionCountChanged += journal1.WrireRecord; //подписка журнала 1 на событие добавления/удаления в коллекции 1
            c1.collectionReferenceChanged += journal1.WrireRecord;//подписка журнала 1 на событие изменения в коллекции 1
            c1.collectionReferenceChanged += journal2.WrireRecord; //подписка журнала 2 на событие изменения в коллекции 1
            c2.collectionReferenceChanged += journal2.WrireRecord;//подписка журнала 2 на событие изменения в коллекции 2

            do
            {
                
                Console.WriteLine();
                Console.WriteLine("1. Печать коллекции 1");
                Console.WriteLine("2. Печать коллекции 2");
                Console.WriteLine("3. Добавление элемента в коллекцию 1");
                Console.WriteLine("4. Добавление элемента в коллекцию 2");
                Console.WriteLine("5. Удаление элемента из коллекции 1");
                Console.WriteLine("6. Удаление элемента из коллекции 2");
                Console.WriteLine("7. Изменение элементов коллекции 1");
                Console.WriteLine("8. Изменение элементов коллекции 2");
                Console.WriteLine("9. Печать журналов");
                Console.WriteLine("0. Закончить работу");
                Console.WriteLine();

                bool isConvert;
                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out ans);
                    if (!isConvert || ans < 0) Console.WriteLine("Неверный ввод. Попробуйте еще раз");
                } while (!isConvert || ans < 0);



                switch (ans)
                {
                    case 1: // Печать коллекции 1
                        {
                            Console.WriteLine($"Коллекция 1 - {c1.CollectionName}");
                            if (c1.Count == 0)
                                Console.WriteLine("В коллекции нет элементов");
                            else
                                c1.PrintTable();
                            break;
                        }

                    case 2: // Печать коллекции 2
                        {
                            Console.WriteLine($"Коллекция 2  - {c2.CollectionName}");
                            if (c2.Count == 0)
                                Console.WriteLine("В коллекции нет элементов");
                            else
                                c2.PrintTable();
                            break;
                        }

                    case 3: //Добавление элемента в коллекцию 1
                        {
                            try
                            {
                                if (c1.Count != 0)
                                {
                                    MusicalInstrument m = new MusicalInstrument();
                                    m.IRandomInit();
                                    c1.Add(m);
                                    
                                    Console.WriteLine($"Элемент {m} добавлен в коллекцию №1");
                                }
                                else Console.WriteLine("В коллекции нет элементов");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Исключение: {ex.Message}");
                            }
                            break;
                        }

                    case 4: //Добавление элемента в коллекцию 2
                        {
                            try
                            {
                                if (c2.Count != 0)
                                {
                                    MusicalInstrument m = new MusicalInstrument();
                                    m.IRandomInit();
                                    c2.Add(m);
                                    Console.WriteLine($"Элемент {m} добавлен в коллекцию №2");
                                }
                                else Console.WriteLine("В коллекции нет элементов");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Исключение: {ex.Message}");
                            }
                            break;
                        }

                    case 5: // Удаление элемента из коллекции 1
                        {
                            Console.WriteLine(" === Удаление элемента из Коллекции №1 === ");
                            RemoveElement(c1);
                            
                            break;
                        }

                    case 6: //  Удаление элемента из коллекции 2
                        {
                            Console.WriteLine(" === Удаление элемента из Коллекции №2 === ");
                            RemoveElement(c2);
                            break;
                        }

                    case 7: //Изменение элементов коллекции 1
                        {
                            Console.WriteLine(" === Изменение элемента Коллекции №1 === ");
                            try
                            {
                                if (c1.Count != 0)
                                {
                                    Console.WriteLine("Введите навзание: ");
                                    string name = Console.ReadLine();
                                    MusicalInstrument m = new MusicalInstrument();
                                    m.IRandomInit();
                                    m.Name += "NEW";
                                    c1[name] = m;
                                    Console.WriteLine($"Элемент с именем {name} заменен на элемент {m}");
                                }
                                else Console.WriteLine("В Коллекции 1 нет элементов");
                            }
                            catch (Exception ex) { Console.WriteLine("Исключение: " + ex.Message); }
                            break;
                        }

                    case 8: //Изменение элементов коллекции 2
                        {
                            Console.WriteLine(" === Изменение элемента Коллекции №2 === ");
                            try
                            {
                                if (c2.Count != 0)
                                {
                                    Console.WriteLine("Введите навзание: ");
                                    string name = Console.ReadLine();
                                    MusicalInstrument m = new MusicalInstrument();
                                    m.IRandomInit();
                                    m.Name += "NEW";
                                    c2[name] = m;
                                    Console.WriteLine($"Элемент с именем {name} заменен на элемент {m}");
                                }
                                else Console.WriteLine("В Коллекции 2 нет элементов");
                            }
                            catch (Exception ex) { Console.WriteLine("Исключение: " + ex.Message); }
                            break;
                        }

                    case 9: // Печать журналов
                        {
                            Console.WriteLine($"Журнал 1 для коллекции {c1.CollectionName}");
                            journal1.PrintJornal();
                            Console.WriteLine();
                            Console.WriteLine($"Журнал 2 для коллекций {c1.CollectionName} и {c2.CollectionName}");
                            journal2.PrintJornal();
                            break;
                        }
                }

            } while (ans != 0);
        }
    }
}
